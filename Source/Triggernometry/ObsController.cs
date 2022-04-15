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

            public bool authRequired { get; set; }
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

        private class Response
        {

            public string error { get; set; }
            public string status { get; set; }

        }

        private WebSocket WSConnection;
        private object lockobj = new object();
        private string resp;
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
                    WSConnection.Connect();
                    respReceived.Reset();
                    SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "GetAuthRequired", message_id = NewMessageID() }));
                    if (respReceived.WaitOne(2000) == false)
                    {
                        throw new ArgumentException(I18n.Translate("internal/Action/obsconnecttimeout", "OBS WebSocket authentication timed out"));
                    }
                    AuthChallenge ac = (AuthChallenge)new JavaScriptSerializer().Deserialize(resp, typeof(AuthChallenge));
                    if (ac.authRequired == true)
                    {
                        if (password != null && password.Length > 0)
                        {
                            if (ac.authRequired == true)
                            {
                                ac.password = password;
                                respReceived.Reset();
                                SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "Authenticate", auth = ac.secret, message_id = NewMessageID() }));
                                if (respReceived.WaitOne(2000) == false)
                                {
                                    throw new ArgumentException(I18n.Translate("internal/Action/obsconnecttimeout", "OBS WebSocket authentication timed out"));
                                }
                                Response rp = (Response)new JavaScriptSerializer().Deserialize(resp, typeof(Response));
                                if (rp.status.ToLower() != "ok")
                                {
                                    throw new ArgumentException(I18n.Translate("internal/Action/obsconnecterror", "OBS WebSocket connection failed: {0}", rp.error));
                                }
                            }
                        }
                        else
                        {
                            throw new ArgumentException(I18n.Translate("internal/Action/obsauthpassword", "OBS WebSocket authentication required, you must provide a password"));
                        }
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
            resp = e.Data;
            respReceived.Set();
        }

        internal void SendRequest(string str)
        {
            lock (lockobj)
            {
                try
                {                    
                    str = str.Replace("request_type", "request-type");
                    str = str.Replace("message_id", "message-id");
                    str = str.Replace("scene_name", "scene-name");
                    WSConnection.Send(str);
                }
                catch (Exception)
                {
                    Disconnect();
                    throw;
                }
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
            }
        }

        internal void StartStreaming()
        {            
            SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "StartStreaming", message_id = NewMessageID() }));
        }

        internal void StopStreaming()
        {
            SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "StopStreaming", message_id = NewMessageID() }));            
        }

        internal void ToggleStreaming()
        {
            SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "StartStopStreaming", message_id = NewMessageID() }));            
        }

        internal void StartRecording()
        {
            SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "StartRecording", message_id = NewMessageID() }));            
        }

        internal void StopRecording()
        {
            SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "StopRecording", message_id = NewMessageID() }));
        }

        internal void ToggleRecording()
        {
            SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "StartStopRecording", message_id = NewMessageID() }));
        }

        internal void StartReplayBuffer()
        {
            SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "StartReplayBuffer", message_id = NewMessageID() }));
        }

        internal void StopReplayBuffer()
        {
            SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "StopReplayBuffer", message_id = NewMessageID() }));
        }

        internal void ToggleReplayBuffer()
        {
            SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "StartStopReplayBuffer", message_id = NewMessageID() }));
        }

        internal void SaveReplayBuffer()
        {
            SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "SaveReplayBuffer", message_id = NewMessageID() }));
        }

        internal void SetCurrentScene(string sceneName)
        {
            SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "SetCurrentScene", message_id = NewMessageID(), scene_name = sceneName }));
        }

        internal void ShowSource(string scenename, string sourcename)
        {
            if (scenename != null && scenename != "")
            {
                SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "SetSceneItemProperties", message_id = NewMessageID(), scene_name = scenename, item = sourcename, visible = true }));
            }
            else
            {
                SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "SetSceneItemProperties", message_id = NewMessageID(), item = sourcename, visible = true }));
            }
        }

        internal void HideSource(string scenename, string sourcename)
        {
            if (scenename != null && scenename != "")
            {
                SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "SetSceneItemProperties", message_id = NewMessageID(), scene_name = scenename, item = sourcename, visible = false }));
            }
            else
            {
                SendRequest(new JavaScriptSerializer().Serialize(new { request_type = "SetSceneItemProperties", message_id = NewMessageID(), item = sourcename, visible = false }));
            }
        }

        internal void JSONPayload(string jsonpayload)
        {
            if(jsonpayload != null && jsonpayload != "")
            {
                SendRequest(jsonpayload);
            }
        }

        protected string NewMessageID()
        {
            Guid g = Guid.NewGuid();
            return g.ToString().Replace('-', '0');
        }

    }

}
