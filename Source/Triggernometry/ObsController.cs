using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private WebSocket WSConnection;
        private object lockobj = new object();

        public void Dispose()
        {
            Disconnect();
        }

        internal ObsController()
        {            
        }

        internal void Connect()
        {
            lock (lockobj)
            {
                try
                {
                    if (IsConnected == true)
                    {
                        return;
                    }
                    WSConnection = new WebSocket(@"ws://127.0.0.1:4444");
                    WSConnection.WaitTime = new TimeSpan(0, 0, 2);
                    WSConnection.OnMessage += WSConnection_OnMessage;
                    WSConnection.Connect();
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
            //throw new NotImplementedException();
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
