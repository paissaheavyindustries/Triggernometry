using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Triggernometry.Variables;

namespace Triggernometry
{

    internal class Endpoint : IDisposable
    {

        internal class Context
        {

            public HttpListener Listener { get; set; }
            public string Endpoint { get; set; }
            public bool Running { get; set; }
            public Thread CtxThread { get; set; }

        }

        internal enum StatusEnum
        {
            Unchanged,
            Starting,
            Started,
            Stopping,
            Stopped
        }

        internal RealPlugin plug { get; set; }
        internal StatusEnum Status { get; set; }
        internal string StatusDescription { get; set; } = "zzz";
        private Context curctx = null;
        internal uint ReceivedTelegrams = 0;
        internal List<Tuple<DateTime, string>> teleHistory = new List<Tuple<DateTime, string>>();

        internal delegate void StatusChangeDelegate(StatusEnum newStatus, string statusDesc);
        internal event StatusChangeDelegate OnStatusChange;

        public Endpoint()
        {
            SetStatus(StatusEnum.Stopped, null);
        }

        private void SetStatus(StatusEnum st, string desc)
        {
            bool notify = false;
            if (st != StatusEnum.Unchanged)
            {
                Status = st;
                notify = true;
            }
            if (desc != null)
            {
                StatusDescription = string.Format("[{0}] {1}", DateTime.Now, desc);
                notify = true;
            }
            if (notify == true)
            {
                if (OnStatusChange != null)
                {
                    OnStatusChange(Status, StatusDescription);
                }
            }
        }

        public void Start()
        {
            try
            {
                SetStatus(StatusEnum.Starting, null);
                HttpListener http = new HttpListener();
                http.Prefixes.Clear();
                http.Prefixes.Add(plug.cfg.HttpEndpoint);
                lock (plug.cfg.Constants)
                {
                    plug.cfg.Constants["TriggernometryEndpoint"] = new VariableScalar() { Value = plug.cfg.HttpEndpoint };
                }
                Thread th = new Thread(new ParameterizedThreadStart(ThreadProc));
                Context ctx = new Context() { Endpoint = plug.cfg.HttpEndpoint, Running = true, CtxThread = th, Listener = http };
                lock (this)
                {
                    if (curctx != null)
                    {
                        curctx.Running = false;
                        curctx.Listener.Abort();
                    }
                    curctx = ctx;
                }
                ReceivedTelegrams = 0;
                http.Start();
                th.Name = "Telesto endpoint";
                th.Start(ctx);
            }
            catch (Exception ex)
            {
                Stop();
                SetStatus(StatusEnum.Unchanged, String.Format("Exception on Start: {0} @ {1}", ex.Message, ex.StackTrace));
            }
        }

        public void Stop()
        {
            SetStatus(StatusEnum.Stopping, null);
            lock (this)
            {
                if (curctx != null)
                {
                    curctx.Running = false;
                    curctx.Listener.Abort();
                }
                curctx = null;
            }
            SetStatus(StatusEnum.Stopped, null);
        }

        public void Dispose()
        {
            Stop();
        }

        public void ThreadProc(object o)
        {
            Context ctx = (Context)o;
            HttpListener http = ctx.Listener;
            SetStatus(StatusEnum.Started, String.Format("Waiting for connections on {0}", ctx.Endpoint));
            while (ctx.Running == true && http.IsListening == true)
            {
                try
                {
                    HttpListenerContext hctx = null;
                    hctx = http.GetContext();
                    if (hctx == null)
                    {
                        continue;
                    }
                    Task t = new Task(() =>
                    {
                        try
                        {
                            HttpListenerRequest req = hctx.Request;
                            if (req.HttpMethod != "POST")
                            {
                                throw new InvalidOperationException(String.Format("Received request was not HTTP POST"));
                            }
                            string body;
                            using (StreamReader sr = new StreamReader(req.InputStream, req.ContentEncoding))
                            {
                                body = sr.ReadToEnd();
                            }
                            ReceivedTelegrams++;
                            lock (teleHistory)
                            {
                                teleHistory.Add(new Tuple<DateTime, string>(DateTime.Now, body));
                                if (teleHistory.Count > 100)
                                {
                                    teleHistory.RemoveAt(0);
                                }
                            }
                            plug.EndpointReceive(body);
                            hctx.Response.StatusCode = 200;
                        }
                        catch (Exception ex)
                        {
                            hctx.Response.StatusCode = 500;
                            SetStatus(StatusEnum.Unchanged, String.Format("Exception in Task: {0} @ {1}", ex.Message, ex.StackTrace));
                        }
                        hctx.Response.Close();
                    });
                    t.Start();
                }
                catch (Exception ex)
                {
                    SetStatus(StatusEnum.Unchanged, String.Format("Exception in ThreadProc: {0} @ {1}", ex.Message, ex.StackTrace));
                }
            }
            SetStatus(StatusEnum.Unchanged, "Thread exited");
        }

    }

}
