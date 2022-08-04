using System;
using System.Collections.Generic;
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
        private object lockobj = new object();
        private RequestResponseOp resp;
        private RequestBatchResponseOp respBatch;
        private List<string> lockedMsgIds = new List<string>();
        private const int maxRpcVersion = 1;
        private string password;
        private AutoResetEvent respReceived = null;

        internal ObsController()
        {
            respReceived = new AutoResetEvent(false);
        }

        public void Dispose()
        {
            Disconnect();
            if (respReceived != null)
            {
                respReceived.Dispose();
                respReceived = null;
            }
        }

        internal void Connect(string endpoint, string password)
        {
            lock (lockobj)
            {
                try
                {
                    if (IsConnected == true)
                    {
                        return;
                    }                    
                    WSConnection = new WebSocket(endpoint);
                    WSConnection.WaitTime = new TimeSpan(0, 0, 2);
                    WSConnection.OnMessage += WSConnection_OnMessage;
                    this.password = password;
                    WSConnection.Connect();
                    respReceived.Reset();
                    if (respReceived.WaitOne(2000) == false)
                    {
                        throw new ArgumentException(I18n.Translate("internal/Action/obsconnecttimeout", "OBS WebSocket authentication timed out"));
                    }
                }
                catch (Exception)
                {
                    Disconnect();
                    throw;
                }
            }
        }

        private void WSConnection_OnMessage(object sender, MessageEventArgs e)
        {
            var message = new JavaScriptSerializer().Deserialize<Message>(e.Data);
            switch ((OpCode) message.op)
            {
                case OpCode.Hello:
                    var helloData = new JavaScriptSerializer().Deserialize<Message<HelloOp>>(e.Data)?.d;
                    respReceived.Reset();
                    var identify = new IdentifyOp();
                    identify.rpcVersion = maxRpcVersion;
                    if (helloData?.authentication?.challenge != null)
                    {
                        if (this.password != null && this.password.Length > 0) 
                        {
                            helloData.authentication.password = this.password;
                            identify.authentication = helloData.authentication.secret;
                            this.password = null;
                        }
                        else
                        {
                            throw new ArgumentException(I18n.Translate("internal/Action/obsauthpassword", "OBS WebSocket authentication required, you must provide a password"));
                        }
                    }
                    identify.eventSubscriptions = 0;
                    SendRequestJson(new JavaScriptSerializer().Serialize(new Message { op = (int) OpCode.Identify, d = identify }));
                    break;
                case OpCode.Identified:
                    var identifiedData = new JavaScriptSerializer().Deserialize<Message<IdentifiedOp>>(e.Data)?.d;
                    if (identifiedData.negotiatedRpcVersion > maxRpcVersion)
                    {
                        throw new ArgumentException(I18n.Translate("internal/Action/obsconnectversionerror", "Your version of OBS WebSocket is not currently supported."));
                    }
                    respReceived.Set();
                    break;
                case OpCode.RequestResponse:
                    lock (lockobj)
                    {
                        resp = new JavaScriptSerializer().Deserialize<Message<RequestResponseOp>>(e.Data)?.d;
                        if (lockedMsgIds.Contains(resp.requestId))
                        {
                            respReceived.Set();
                        }
                        else
                        {
                            respReceived.Reset();
                        }
                    }
                    break;
                case OpCode.RequestBatchResponse:
                    lock (lockobj)
                    {
                        respBatch = new JavaScriptSerializer().Deserialize<Message<RequestBatchResponseOp>>(e.Data)?.d;
                        if (lockedMsgIds.Contains(respBatch.requestId))
                        {
                            respReceived.Set();
                        }
                        else
                        {
                            respReceived.Reset();
                        }
                    }
                    break;
            }
        }

        internal void SendRequestJson(string str)
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
                {
                    return;
                }
                if (WSConnection != null)
                {
                    WSConnection.Close();
                }                
                WSConnection = null;
                password = null;
            }
        }

        internal string SendRequest(string requestType)
        {
            return SendRequest(requestType, NewMessageID(), null);
        }

        internal string SendRequest(string requestType, string requestId)
        {
            return SendRequest(requestType, requestId, null);
        }

        internal string SendRequest(string requestType, object requestData)
        {
            return SendRequest(requestType, NewMessageID(), requestData);
        }

        internal string SendRequest(string requestType, string requestId, object requestData)
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

        internal string SendRequestBatch(object[] requests)
        {
            return SendRequestBatch(requests, NewMessageID(), false, (int) RequestBatchExecutionType.SerialRealtime);
        }

        internal string SendRequestBatch(object[] requests, string requestId, bool haltOnFailure, int executionType)
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
            var isRecording = true;
            var sleepMillis = 150;
            while (isRecording)
            {
                respReceived.Reset();
                var messageId = NewMessageID();
                lock (lockobj)
                {
                    lockedMsgIds.Add(messageId);
                }
                var stopRequest = new RequestOp[3];
                stopRequest[0] = new RequestOp { requestType = "StopRecord" };
                stopRequest[1] = new RequestOp { requestType = "Sleep", requestData = new { sleepMillis = sleepMillis } };
                stopRequest[2] = new RequestOp { requestType = "GetRecordStatus" };
                SendRequestBatch(stopRequest, messageId, false, (int) RequestBatchExecutionType.SerialRealtime);

                if (respReceived.WaitOne(sleepMillis + 1500) == false)
                {
                    respReceived.Reset();
                    throw new ArgumentException(I18n.Translate("internal/Action/obsconnecttimeout", "OBS WebSocket timed out"));
                }
                lock (lockobj)
                {
                    lockedMsgIds.Remove(messageId);
                }
                sleepMillis *= 2;

                try
                {
                    var responseData = (Dictionary<string, object>)respBatch.results[2]["responseData"];
                    isRecording = (bool) responseData["outputActive"];
                }
                catch (Exception)
                {
                    respReceived.Reset();
                    StartRecording();
                    Disconnect();
                    throw;
                }
            }

            respReceived.Reset();
            StartRecording();
        }

        internal void RestartRecordingIfActive()
        {
            var messageId = NewMessageID();
            lock (lockobj)
            { 
                lockedMsgIds.Add(messageId);
            }
            SendRequest("GetRecordStatus", messageId);
            if (respReceived.WaitOne(2000) == false)
            {
                respReceived.Reset();
                throw new ArgumentException(I18n.Translate("internal/Action/obsconnecttimeout", "OBS WebSocket timed out"));
            }
            lock (lockobj)
            {
                lockedMsgIds.Remove(messageId);
            }

            try
            {
                if (resp.requestId.Equals(messageId))
                {
                    var isRecording = (bool) resp.responseData["outputActive"];
                    if (isRecording)
                        RestartRecording();
                }
                respReceived.Reset();
            }
            catch (Exception)
            {
                respReceived.Reset();
                Disconnect();
                throw;
            }
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
                lockedMsgIds.Add(messageId);
            }
            SendRequest("GetSceneItemId", messageId, new { sceneName = scenename, sourceName = sourcename });
            if (respReceived.WaitOne(2000) == false)
            {
                respReceived.Reset();
                throw new ArgumentException(I18n.Translate("internal/Action/obsconnecttimeout", "OBS WebSocket timed out"));
            }

            try
            {
                if (resp.requestId.Equals(messageId))
                {
                    var sceneItemId = (int) resp.responseData["sceneItemId"];
                    SendRequest("SetSceneItemEnabled", new { sceneName = scenename, sceneItemId = sceneItemId, sceneItemEnabled = sceneItemEnabled });
                }
                respReceived.Reset();
            }
            catch (Exception)
            {
                respReceived.Reset();
                Disconnect();
                throw;
            }
        }

        internal void JSONPayload(string jsonpayload)
        {
            if(jsonpayload != null && jsonpayload != "")
            {
                SendRequestJson(jsonpayload);
            }
        }

        protected string NewMessageID()
        {
            Guid g = Guid.NewGuid();
            return g.ToString().Replace('-', '0');
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
