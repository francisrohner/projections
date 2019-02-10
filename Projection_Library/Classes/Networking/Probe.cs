using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Projection_Library.Classes.Networking
{
    public class Probe
    {
        private int lastMinutesElapsed = -1;
        private int activeThreads;
        private readonly int MAX_ACTIVE_THREADS = 10;
        private bool abort;

        private List<string> lstRespondedIPS;

        public EventHandler IP_Found_Event;
        public EventHandler ScanFinishedEvent;

        public Probe()
        {
            lstRespondedIPS = new List<string>();
            abort = false;
        }

        public void Abort()
        {
            abort = true;
        }

        public string IncrementIP(string ip)
        {
            int lastFragment = -1;
            int secondToLastFragment = -1;

            int.TryParse(ip.Substring(ip.LastIndexOf(".") + 1), out lastFragment);
            ip = ip.Substring(0, ip.LastIndexOf("."));
            int.TryParse(ip.Substring(ip.LastIndexOf(".") + 1), out secondToLastFragment);
            ip = ip.Substring(0, ip.LastIndexOf("."));

            if (lastFragment + 1 <= 254)
                ++lastFragment;
            else
            {
                ++secondToLastFragment;
                lastFragment = 0;
            }
            return string.Format(ip + ".{0}.{1}", secondToLastFragment, lastFragment);
        }

        //private bool SpawnTestIP(string ip)
        //{
        //    return false;
        //}

        public bool TestIP(string ip, bool waitResult = false)
        {
            if (abort) return false;
            while (activeThreads > MAX_ACTIVE_THREADS) ;
            bool success = true;

            Thread thread = new Thread(new ThreadStart(() =>
            {
                ++activeThreads;
                
                try
                {
                    Ping ping = new Ping();
                    PingReply reply = ping.Send(ip, 2500);
                    if (reply.Status == IPStatus.Success)
                    {
                        //Test port
                        DisplayClient client = new DisplayClient();
                        if (!client.Connect(IPAddress.Parse(ip)))
                            success = false;
                        else
                        {
                            bool pass = false;
                            client.ReceiveMessage += new EventHandler((se, ev) =>
                            {
                                pass = true;
                            });
                            client.SendStr("test");
                            Stopwatch waitWatch = new Stopwatch();
                            waitWatch.Start();
                            while (!pass && waitWatch.ElapsedMilliseconds < 5000) ;
                            waitWatch.Stop();
                            success = pass;
                            client.Disconnect();
                        }
                    }
                    else
                        success = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    success = false;
                }

                if (success)
                {
                    Console.WriteLine("DisplayServer found at " + ip);
                    lstRespondedIPS.Add(ip);
                    if(IP_Found_Event != null)
                        IP_Found_Event.Invoke(this, new IpFoundEventArgs(ip));
                }
                else
                {
                    Console.WriteLine("DisplayServer not found at " + ip);
                }
                --activeThreads;
            }));
            thread.Start();
            if (waitResult)
                while (thread.ThreadState == System.Threading.ThreadState.Running);
            return success;
        }

        //~~5 minutes
        public List<string> Scan(string startIP, string endIP)
        {
            List<string> lstSearchIPS = new List<string>();
            lstRespondedIPS = new List<string>();
            Stopwatch diagnosticWatch = new Stopwatch();
            diagnosticWatch.Start();
            string curIP = startIP;
            while (curIP != null)
            {
                if (abort) break;
                TestIP(curIP);
                if (diagnosticWatch.Elapsed.Minutes > 0 && diagnosticWatch.Elapsed.Minutes != lastMinutesElapsed)
                {
                    lastMinutesElapsed = diagnosticWatch.Elapsed.Minutes;
                    Console.WriteLine(diagnosticWatch.Elapsed.Minutes + " minutes elapsed.");
                }
                if (curIP.Equals(endIP))
                    break;
                curIP = IncrementIP(curIP);
            }

            return lstRespondedIPS;
        }
    }
    public class IpFoundEventArgs : EventArgs
    {
        public string ip;
        public IpFoundEventArgs(string ip)
        {
            this.ip = ip;
        }

    }
}
