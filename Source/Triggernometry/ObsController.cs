using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WebSocketSharp;

namespace Triggernometry
{

    internal class ObsController : IDisposable
    {

        internal bool IsConnected
        {
            get
            {
                lock (lockobj)
                {
                    return (WSConnection != null ? WSConnection.IsAlive : false);
                }
            }
        }

        private class AuthChallenge
        {
            public string challenge { get; set; }
            public string salt { get; set; }
            
            internal string password { get; set; }

            internal string secret
            {
                get
                {
                    string secret_string = GenerateHash(password + salt);
                    return GenerateHash(secret_string + challenge);
                }
            }

            private string GenerateHash(string data)
            {
                using (SHA256 h = SHA256.Create())
                {
                    byte[] b = Encoding.ASCII.GetBytes(data);
                    return Convert.ToBase64String(h.ComputeHash(b));
                }
            }
        }

        private WebSocket WSConnection;
        private const int maxRpcVersion = 1;
        private object lockobj = new object();
        private Dictionary<string, Action<RequestResponseOp>> respCallbacks = new Dictionary<string, Action<RequestResponseOp>>();
        private Dictionary<string, Action<RequestBatchResponseOp>> respBatchCallbacks = new Dictionary<string, Action<RequestBatchResponseOp>>();
        private Action<HelloOp> helloCallback;
        private AutoResetEvent authRespReceived = null;

        internal ObsController()
        {
            authRespReceived = new AutoResetEvent(false);
        }

        public void Dispose()
        {
            Disconnect();
            if (authRespReceived != null)
            {
                authRespReceived.Dispose();
                authRespReceived = null;
            }
        }

        private Process _obsProc;
        private DateTime _lastChecked;
        private bool _complaintAboutNotRunning = false;
        internal ObsRunningState CheckRunningState()
        {
            if (_obsProc?.HasExited == false)
            {
                return ObsRunningState.Running;
            }
            else
            {
                _obsProc = null;
                _complaintAboutNotRunning = false;
            }
            if (DateTime.Now - _lastChecked > TimeSpan.FromSeconds(5))
            {
                _lastChecked = DateTime.Now;
                _obsProc = Process.GetProcessesByName("obs64").FirstOrDefault()
                        ?? Process.GetProcessesByName("obs32").FirstOrDefault();
            }
            return _obsProc != null ? ObsRunningState.Running
                                    : _complaintAboutNotRunning ? ObsRunningState.NotRunning
                                                                : ObsRunningState.NotRunningFirstlyFound;
        }

        internal enum ObsRunningState 
        { 
            Running,
            NotRunningFirstlyFound, 
            NotRunning 
        }

        internal void Connect(string endpoint, string password)
        {
            lock (lockobj)
            {
                try
                {
                    if (IsConnected == true)
                        return;
                    WSConnection = new WebSocket(endpoint);
                    WSConnection.WaitTime = new TimeSpan(0, 0, 2);
                    WSConnection.OnMessage += WSConnection_OnMessage;
                    helloCallback = resp => { HandleHelloOp(resp, password); };
                    authRespReceived.Reset();
                    WSConnection.Connect();
                    if (authRespReceived.WaitOne(2000) == false)
                        throw new ArgumentException(I18n.Translate("internal/Action/obsconnecttimeout", "OBS WebSocket authentication timed out"));
                }
                catch (Exception)
                {
                    Disconnect();
                    throw;
                }
            }
        }

        private void HandleHelloOp(HelloOp helloData, string password)
        {
            var identify = new IdentifyOp();
            identify.rpcVersion = maxRpcVersion;
            if (helloData?.authentication?.challenge != null)
            {
                if (password != null && password.Length > 0)
                {
                    helloData.authentication.password = password;
                    identify.authentication = helloData.authentication.secret;
                }
                else
                {
                    throw new ArgumentException(I18n.Translate("internal/Action/obsauthpassword", "OBS WebSocket authentication required, you must provide a password"));
                }
            }
            identify.eventSubscriptions = 0;
            SendRequestJson(new JavaScriptSerializer().Serialize(new Message { op = (int) OpCode.Identify, d = identify }));
        }

        private void WSConnection_OnMessage(object sender, MessageEventArgs e)
        {
            var message = new JavaScriptSerializer().Deserialize<Message>(e.Data);
            switch ((OpCode) message.op)
            {
                case OpCode.Hello:
                    var helloData = new JavaScriptSerializer().Deserialize<Message<HelloOp>>(e.Data)?.d;
                    helloCallback(helloData);
                    break;
                case OpCode.Identified:
                    var identifiedData = new JavaScriptSerializer().Deserialize<Message<IdentifiedOp>>(e.Data)?.d;
                    if (identifiedData.negotiatedRpcVersion > maxRpcVersion)
                        throw new ArgumentException(I18n.Translate("internal/Action/obsconnectversionerror", "Your version of OBS WebSocket is not currently supported."));
                    authRespReceived.Set();
                    break;
                case OpCode.RequestResponse:
                    var resp = new JavaScriptSerializer().Deserialize<Message<RequestResponseOp>>(e.Data)?.d;
                    Action<RequestResponseOp> respCallback;
                    lock (lockobj)
                    {
                        respCallbacks.TryGetValue(resp.requestId, out respCallback);
                        respCallbacks.Remove(resp.requestId);
                    }
                    if (respCallback != null)
                        respCallback(resp);
                    break;
                case OpCode.RequestBatchResponse:
                    var respBatch = new JavaScriptSerializer().Deserialize<Message<RequestBatchResponseOp>>(e.Data)?.d;
                    Action<RequestBatchResponseOp> respBatchCallback;
                    lock (lockobj)
                    {
                        respBatchCallbacks.TryGetValue(respBatch.requestId, out respBatchCallback);
                        respBatchCallbacks.Remove(respBatch.requestId);
                    }
                    if (respBatchCallback != null)
                        respBatchCallback(respBatch);
                    break;
            }
        }

        private void SendRequestJson(string str)
        {
            try
            {
                WSConnection.Send(str);
            }
            catch (Exception)
            {
                Disconnect();
                throw;
            }
        }

        internal void Disconnect()
        {
            lock (lockobj)
            {
                if (IsConnected == false)
                    return;
                if (WSConnection != null)
                    WSConnection.Close();
                WSConnection = null;
            }
        }

        private string SendRequest(string requestType)
        {
            return SendRequest(requestType, NewMessageID(), null);
        }

        private string SendRequest(string requestType, string requestId)
        {
            return SendRequest(requestType, requestId, null);
        }

        private string SendRequest(string requestType, object requestData)
        {
            return SendRequest(requestType, NewMessageID(), requestData);
        }

        private string SendRequest(string requestType, string requestId, object requestData)
        {
            Message req = new Message { 
                op = (int) OpCode.Request, 
                d = new RequestOp { 
                    requestType = requestType, 
                    requestId = requestId, 
                    requestData = requestData 
                } 
            };
            SendRequestJson(new JavaScriptSerializer().Serialize(req));
            return requestId;
        }

        private string SendRequestBatch(object[] requests)
        {
            return SendRequestBatch(requests, NewMessageID(), false, (int) RequestBatchExecutionType.SerialRealtime);
        }

        private string SendRequestBatch(object[] requests, string requestId, bool haltOnFailure, int executionType)
        {
            Message req = new Message
            {
                op = (int) OpCode.RequestBatch,
                d = new RequestBatchOp
                {
                    requestId = requestId,
                    executionType = executionType,
                    haltOnFailure = haltOnFailure,
                    requests = requests
                }
            };
            SendRequestJson(new JavaScriptSerializer().Serialize(req));
            return requestId;
        }

        internal void StartStreaming()
        {
            SendRequest("StartStream");
        }

        internal void StopStreaming()
        {
            SendRequest("StopStream");
        }

        internal void ToggleStreaming()
        {
            SendRequest("ToggleStream");
        }

        internal void StartRecording()
        {
            SendRequest("StartRecord");
        }

        internal void StopRecording()
        {
            SendRequest("StopRecord");
        }

        internal void ToggleRecording()
        {
            SendRequest("ToggleRecord");
        }

        internal void RestartRecording()
        {
            var messageId = NewMessageID();
            lock (lockobj)
            {
                respBatchCallbacks.Add(messageId, resp =>
                {
                    var responseData = (Dictionary<string, object>) resp.results[2]["responseData"];
                    var isRecording = (bool)responseData["outputActive"];
                    if (isRecording)
                        RestartRecording();
                    else
                        StartRecording();
                });
            }

            var stopRequest = new RequestOp[3];
            stopRequest[0] = new RequestOp { requestType = "StopRecord" };
            stopRequest[1] = new RequestOp { requestType = "Sleep", requestData = new { sleepMillis = 200 } };
            stopRequest[2] = new RequestOp { requestType = "GetRecordStatus" };
            SendRequestBatch(stopRequest, messageId, false, (int)RequestBatchExecutionType.SerialRealtime);
        }

        internal void RestartRecordingIfActive()
        {
            var messageId = NewMessageID();
            lock (lockobj)
            { 
                respCallbacks.Add(messageId, resp =>
                {
                    var isRecording = (bool)resp.responseData["outputActive"];
                    if (isRecording)
                        RestartRecording();
                });
            }
            SendRequest("GetRecordStatus", messageId);
        }

        internal void PauseRecording()
        {
            SendRequest("PauseRecord");
        }

        internal void ResumeRecording()
        {
            SendRequest("ResumeRecord");
        }

        internal void ToggleRecordPause()
        {
            SendRequest("ToggleRecordPause");
        }

        internal void StartReplayBuffer()
        {
            SendRequest("StartReplayBuffer");
        }

        internal void StopReplayBuffer()
        {
            SendRequest("StopReplayBuffer");
        }

        internal void ToggleReplayBuffer()
        {
            SendRequest("ToggleReplayBuffer");
        }

        internal void SaveReplayBuffer()
        {
            SendRequest("SaveReplayBuffer");
        }

        internal void SetCurrentScene(string sceneName)
        {
            SendRequest("SetCurrentProgramScene", new { sceneName = sceneName });
        }

        internal void ShowHideSource(string scenename, string sourcename, bool sceneItemEnabled)
        {
            var messageId = NewMessageID();
            lock (lockobj)
            {
                respCallbacks.Add(messageId, resp =>
                {
                    var sceneItemId = (int) resp.responseData["sceneItemId"];
                    SendRequest("SetSceneItemEnabled", new { sceneName = scenename, sceneItemId = sceneItemId, sceneItemEnabled = sceneItemEnabled });
                });
            }
            SendRequest("GetSceneItemId", messageId, new { sceneName = scenename, sourceName = sourcename });
        }

        internal void JSONPayload(string jsonpayload)
        {
            if(jsonpayload != null && jsonpayload != "")
                SendRequestJson(jsonpayload);
        }

        private string NewMessageID()
        {
            Guid g = Guid.NewGuid();
            return g.ToString();
        }

        private class Message
        {
            public int op { get; set; }
            public object d { get; set; }
        }

        private class Message<T>
        {
            public int op { get; set; }
            public T d { get; set; }
        }

        private class HelloOp
        {
            public string obsWebSocketVersion { get; set; }
            public int rpcVersion { get; set; }
            public AuthChallenge authentication { get; set; }
        }

        private class IdentifyOp
        {
            public int rpcVersion { get; set; }
            public string authentication { get; set; }
            public int eventSubscriptions { get; set; }
        }

        private class IdentifiedOp
        {
            public int negotiatedRpcVersion { get; set; }
        }

        private class RequestOp
        {
            public string requestType { get; set; }
            public string requestId { get; set; }
            public object requestData { get; set; }
        }

        private class RequestResponseOp
        {
            public string requestType { get; set; }
            public string requestId { get; set; }
            public Dictionary<string, object> requestStatus { get; set; }
            public Dictionary<string, object> responseData { get; set; }
        }

        private class RequestBatchOp
        {
            public string requestId { get; set; }
            public bool haltOnFailure { get; set; }
            public int executionType { get; set; }
            public object[] requests { get; set; }
        }

        private class RequestBatchResponseOp
        {
            public string requestId { get; set; }
            public Dictionary<string, object>[] results { get; set; }
        }

        private enum OpCode
        {
            Hello = 0,
            Identify = 1,
            Identified = 2,
            Request = 6,
            RequestResponse = 7,
            RequestBatch = 8,
            RequestBatchResponse = 9,
        }

        private enum RequestBatchExecutionType
        {
            None = -1,
            SerialRealtime = 0,
            SerialFrame = 1,
            Parallel = 2,
        }
    }
}
