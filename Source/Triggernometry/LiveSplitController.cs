using System;
using System.IO;
using System.IO.Pipes;

namespace Triggernometry
{

    internal class LiveSplitController : IDisposable
    {

        internal bool IsConnected
        {
            get
            {
                lock (lockobj)
                {
                    if (client == null || clientWriter?.BaseStream == null)
                        return false;
                    return client.IsConnected;
                }
            }
        }

        private NamedPipeClientStream client;
        private StreamWriter clientWriter;
        private object lockobj = new object();

        internal LiveSplitController() { }

        public void Dispose()
        {
            clientWriter?.Dispose();
            client?.Dispose();
            clientWriter = null;
            client = null;
        }

        internal void Connect()
        {
            lock (lockobj)
            {
                try
                {
                    if (IsConnected == true)
                        return;
                    Dispose();
                    client = new NamedPipeClientStream(".", "LiveSplit", PipeDirection.Out, PipeOptions.Asynchronous);
                    client.Connect(3000);
                    clientWriter = new StreamWriter(client);
                    clientWriter.AutoFlush = true;
                }
                catch (Exception)
                {
                    Dispose();
                    throw;
                }
            }
        }

        internal void SendCommand(string command)
        {
            try
            {
                clientWriter.WriteLine(command);
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }
        }

        internal void StartOrSplit()
        {
            SendCommand("startorsplit");
        }

        internal void Start()
        {
            SendCommand("start");
        }

        internal void Split()
        {
            SendCommand("split");
        }

        internal void UndoSplit()
        {
            SendCommand("undosplit");
        }

        internal void SkipSplit()
        {
            SendCommand("skipsplit");
        }

        internal void Reset()
        {
            SendCommand("reset");
        }

        internal void Pause()
        {
            SendCommand("pause");
        }

        internal void Resume()
        {
            SendCommand("resume");
        }
    }
}
