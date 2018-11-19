using Projection.Classes;
using RedCorona.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Projection_Library.Classes.Networking
{
    public class DisplayClient
    {
        ClientInfo client;
        Socket sock;

        public EventHandler ReceiveProjection;
        public EventHandler ReceiveMessage;
        public EventHandler ReceiveProjectionManager;

        public bool Connect(string ip, int port = 1108)
        {
            return Connect(IPAddress.Parse(ip), port);
        }

        public bool Connect(IPAddress ip, int port = 1108)
        {
            try
            {
                sock = Sockets.CreateTCPSocket(ip, port);
                client = new ClientInfo(sock, false); //Don't start receiving yet            
                client.MessageType = MessageType.CodeAndLength;
                client.OnReadMessage += Client_OnReadMessage;
                client.BeginReceive();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool Disconnect()
        {
            try
            {
                client.OnReadMessage -= Client_OnReadMessage;
                sock.Disconnect(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public void SendStr(string data)
        {
            client.SendMessage(0, Encoding.UTF8.GetBytes(data));
        }

        public string RequestName()
        {
            bool wait = true;
            string msg = string.Empty;
            Stopwatch waitWatch = new Stopwatch();
            waitWatch.Start();
            ReceiveMessage += (se, ev) =>
            {
                msg = (string)se;
                wait = false;
            };
            SendStr("RequestName");
            while (wait && waitWatch.Elapsed.Seconds < 15) ;
            waitWatch.Stop();
            waitWatch = null;
            ReceiveMessage = null;
            return msg;
        }

        public string RequestResolution()
        {
            bool wait = true;
            string msg = string.Empty;
            Stopwatch waitWatch = new Stopwatch();
            waitWatch.Start();
            ReceiveMessage += (se, ev) =>
            {
                msg = (string)se;
                wait = false;
            };
            SendStr("RequestRES");
            while (wait && waitWatch.Elapsed.Seconds < 15) ;
            waitWatch.Stop();
            waitWatch = null;
            ReceiveMessage = null;
            return msg;
        }


        public string QueryProjectionManager()
        {
            bool wait = true;
            string msg = string.Empty;
            Stopwatch waitWatch = new Stopwatch();
            waitWatch.Start();
            ReceiveMessage += (se, ev) =>
            {
                msg = (string)se;
                wait = false;
            };
            SendStr("QueryPM");
            while (wait && waitWatch.Elapsed.Seconds < 15) ;
            waitWatch.Stop();
            waitWatch = null;
            ReceiveMessage = null;
            return msg;
        }

        public ProjectionManager RequestProjectionManager()
        {
            bool wait = true;
            ProjectionManager ret = null;
            Stopwatch waitWatch = new Stopwatch();
            waitWatch.Start();
            ReceiveProjectionManager += (se, ev) =>
            {
                ret = (ProjectionManager)se;
                wait = false;
            };
            SendStr("RequestPM");
            while (wait && waitWatch.Elapsed.Seconds < 15) ;
            waitWatch.Stop();
            Console.WriteLine("Finished retrieval in {0} seconds.", waitWatch.Elapsed.Seconds);
            waitWatch = null;
            ReceiveMessage = null;
            return ret;
        }
        public void SendProjection(ProjectionObj projection)
        {            
            byte[] data = projection.Serialize();
            if (data == null || data.Length < 1)
                Console.WriteLine("Serialization failed, unable to send projection.");
            else
                client.SendMessage(2, data);            
        }

        private void Client_OnReadMessage(ClientInfo ci, uint code, byte[] bytes, int len)
        {            
            if (code == 0) //String
            {
                Console.WriteLine("Received msg from Client[" + ci.ID + "]: " + Encoding.UTF8.GetString(bytes));
                if (ReceiveMessage != null)
                    ReceiveMessage.Invoke(Encoding.UTF8.GetString(bytes), EventArgs.Empty);
            }
            else if (code == 1) //File
            {
                File.WriteAllBytes("file.txt", bytes);
            }
            else if (code == 2) //Projection
            {
                string ret = string.Empty;
                ProjectionObj projection = ProjectionObj.Deserialize(bytes);
                ReceiveProjection.Invoke(projection, EventArgs.Empty);
            }
            else if (code == 3) //ProjectionManger
            {
                ProjectionManager recManager = ProjectionManager.Deserialize(bytes);
                ReceiveProjectionManager.Invoke(recManager, EventArgs.Empty);
            }
            else
                Console.WriteLine("Unknown msg from server, disregarding...");
        }


    }
}
