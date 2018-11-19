using Projection_Library.Classes;
using Projection_Library.Classes.Networking;
using Projection.Classes.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Projection.Forms
{
    public partial class AddScreen : Form
    {
        private List<string> uiUpdate;
        private System.Windows.Forms.Timer upTimer;
        private bool searchInProgress;
        private Thread searchThread;
        private Probe probe;
        private bool processingUIStrings;
        public AddScreen()
        {
            InitializeComponent();
            Icon = Icon.FromHandle(Projection_Client.Properties.Resources.tv_screen.GetHicon());
            processingUIStrings = false;
            uiUpdate = new List<string>();
            upTimer = new System.Windows.Forms.Timer();
            upTimer.Tick += tmrUpdate_Tick;
            upTimer.Interval = 1000;
            upTimer.Start();
        }




        public void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (searchInProgress)
            {
                Image img = pbLogo.Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pbLogo.Image = img;
                string sip = "Search in Progress";
                int numDots = lblSearchInProgress.Text.Count(c => c == '.');
                if (numDots < 3)
                    lblSearchInProgress.Text += ".";
                else
                    lblSearchInProgress.Text = sip;
                
            }

            if (processingUIStrings) return;
            processingUIStrings = true;
            while (uiUpdate.Count > 0)
            {
                string cur = uiUpdate[0];
                uiUpdate.RemoveAt(0);
                if (CountChars(cur) == 3) //ip
                {
                    int id = gridIPList.Rows.Add();
                    gridIPList.Rows[id].Cells[0].Value = true;
                    gridIPList.Rows[id].Cells[1].Value = cur;
                }
                else if (cur.Equals("Reset"))
                {
                    //pbLogo.Image = Properties.Resources.logo;
                    lblSearchInProgress.Text = "Search in progress";
                    lblSearchInProgress.Hide();                    
                }
                else if (cur.Contains("DialogInfo:"))
                {
                    //searchInProgress = false;
                    MessageBox.Show(this, cur.Substring("DialogInfo:".Length), "Projection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            processingUIStrings = false;
        }

        public int CountChars(string val, char c = '.')
        {
            int counter = 0;
            for (int i = 0; i < val.Length; i++)
                if (val[i] == c)
                    ++counter;
            return counter;
        }

        public void IP_Found_Handler(object sender, EventArgs e)
        {
            IpFoundEventArgs ie = (IpFoundEventArgs)e;
            uiUpdate.Add(ie.ip);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchInProgress = true;
            lblSearchInProgress.Show();
            IPAddress[] ipv4Addresses = Array.FindAll(Dns.GetHostEntry(string.Empty).AddressList,
            a => a.AddressFamily == AddressFamily.InterNetwork);
            string ip = ipv4Addresses.Last().ToString();
            string startIp = ip.Substring(0, ip.LastIndexOf(".") + 1) + "0";
            string endIp = ip.Substring(0, ip.LastIndexOf(".") + 1) + "255";
            searchThread = new Thread(new ThreadStart(() =>
           {
               probe = new Probe();
               probe.IP_Found_Event += IP_Found_Handler;
               List<string> lstStuff = probe.Scan(startIp, endIp);
              
               searchInProgress = false;
               uiUpdate.Add("Reset");
               uiUpdate.Add("DialogInfo:Finished Scan!");
           }));
            searchThread.Start();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (searchInProgress)
            {
                DialogResult dr = MessageBox.Show(this, "Search is currently in progress, would you like to cancel it?", "Projection", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                    return;
                else
                {
                    searchThread.Abort();
                    probe.Abort();
                }
            }
            List<string> ipAddresses = new List<string>();
            for (int i = 0; i < gridIPList.Rows.Count; i++)
                if (((bool)gridIPList.Rows[i].Cells[0].Value == true))
                {
                    ipAddresses.Add((string)gridIPList.Rows[i].Cells[1].Value);
                }
            Tag = ipAddresses;
            Close();
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            
            Probe manualProbe = new Probe();
            bool res = manualProbe.TestIP(ipbManual.IP, true);
            if(res)
                MessageBox.Show(this, "Found Display Server found at " + ipbManual.IP + "!", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(this, "No Display Server found at " + ipbManual.IP + ".", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void gbManual_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gb = sender as GroupBox;
            Utility.DrawGroupBox(gb, e.Graphics, Color.Black, Color.DarkBlue, true);
        }

        private void gbAuto_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gb = sender as GroupBox;
            Utility.DrawGroupBox(gb, e.Graphics, Color.Black, Color.DarkBlue, true);
        }

        bool AddGridEntry(bool add, string ip, string name)
        {
            //Check exists
            for(int i = 0; i < gridIPList.RowCount; i++)
                if (gridIPList.Rows[i].Cells[1].Value.Equals(ip))
                    return false;

            int id = gridIPList.Rows.Add();
            gridIPList.Rows[id].Cells[0].Value = add;
            gridIPList.Rows[id].Cells[1].Value = ip;
            gridIPList.Rows[id].Cells[2].Value = name;
            return true;
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            bool ret = false;
            string name = string.Empty;
            try
            {
                DisplayClient dc = new DisplayClient();
                ret = dc.Connect(ipbManual.IP);
                name = dc.RequestName();
                if (!ret)
                    throw new Exception("Error");
            }
            catch(Exception)
            {
                MessageBox.Show(this, "There was an issue connecting to this DisplayServer.", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
            ret = AddGridEntry(true, ipbManual.IP, name);
            if (!ret)
                MessageBox.Show(this, "Doh, this Display Server is already added!", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
        }
    }
}
