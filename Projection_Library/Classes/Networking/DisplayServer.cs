using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using RedCorona.Net;
using Projection.Classes.Utilities;
using static Projection.Classes.Utilities.Utility;
using System.IO;
using Projection.Classes;
using System.Windows.Forms;

namespace Projection_Library.Classes.Networking
{
    public class DisplayServer
    {
        Server server;
        public EventHandler ReceivedProjection;
        public ProjectionManager projectionManager;

        public void Start(int port = 1108)
        {
            server = new Server(port, ClientConnect);            
        }

        public void Stop()
        {
            server.Close();
        }
        public bool ClientConnect(Server server, ClientInfo client)
        {            
            client.Delimiter = "\n";            
            client.OnReadMessage += Client_OnReadMessage;
            client.MessageType = MessageType.CodeAndLength;
            return true;
        }

        private void Client_OnReadMessage(ClientInfo clientInfo, uint code, byte[] bytes, int length)
        {
            if (code == 0) //String
            {
                string msg = Encoding.UTF8.GetString(bytes);
                if (msg.Equals("RequestName"))
                {
                    string name = projectionManager.GetName();
                    clientInfo.SendMessage(0, Encoding.UTF8.GetBytes(name));
                    return;
                }
                else if(msg.Equals("RequestPM"))
                {
                    clientInfo.SendMessage(3, projectionManager.Serialize());
                    return;
                }
                else if(msg.Equals("RequestRES"))
                {
                    //Screen[] screens = Screen.AllScreens;
                    
                    int width = Screen.PrimaryScreen.WorkingArea.Width;
                    int height = Screen.PrimaryScreen.WorkingArea.Height;

                    clientInfo.SendMessage(0, Encoding.UTF8.GetBytes(width + "x" + height));
                    return;
                }
                Console.WriteLine("Received msg from Client[" + clientInfo.ID + "]: " + Encoding.UTF8.GetString(bytes));
            }
            else if (code == 1) //File
            {
                File.WriteAllBytes("file.txt", bytes);
            }
            else if (code == 2) //Projection
            {
                ProjectionObj data = ProjectionObj.Deserialize(bytes);
                if (ReceivedProjection != null)
                    ReceivedProjection.Invoke(data, EventArgs.Empty);
                Console.WriteLine("Received projection from client: " + data.scheduledDateTimes.First().Start.ToString("yyyy/MM/dd hh:mm:ss tt"));
            }
            else
            {
                Console.WriteLine("Unknown msg from Client[" + clientInfo.ID + "]");
            }
            clientInfo.SendMessage(0, Encoding.UTF8.GetBytes("Acknowledged"));
        }  
    }
   
}
