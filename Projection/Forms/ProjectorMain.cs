using Projection_Library.Classes.Networking;
using Projection.Classes;
using Projection.Forms;
#if MSO_BUILD
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
#endif
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Projection
{
    public partial class ProjectorMain : Form
    {

        private Color backColor, foreColor;
        public ProjectorMain()
        {
            InitializeComponent();
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            InitGrid();
            Icon = Icon.FromHandle(Projection_Client.Properties.Resources.projector.GetHicon());
            //AddDisplay("192.168.1.154");
            if (File.Exists("screens.txt"))
            {
                string[] lines = File.ReadAllLines("screens.txt");
                foreach (string ip in lines)
                {
                    if (String.IsNullOrEmpty(ip)) continue;
                    AddDisplay(ip);
                }
            }
#if MSO_BUILD == false
            btnImportSlides.Visible = false;
#endif
        }

        private void InitGrid()
        {
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;
            grid.MouseClick += GridDisplays_MouseClick;
            grid.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            backColor = grid.DefaultCellStyle.SelectionBackColor;
            foreColor = grid.DefaultCellStyle.ForeColor;
            grid.DefaultCellStyle.SelectionBackColor = grid.DefaultCellStyle.BackColor;
            grid.DefaultCellStyle.SelectionForeColor = grid.DefaultCellStyle.ForeColor;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToResizeColumns = false;
        }

        private void GridDisplays_MouseClick(object sender, MouseEventArgs e)
        {
            grid.DefaultCellStyle.SelectionBackColor = backColor;
            grid.DefaultCellStyle.SelectionForeColor = foreColor;
        }

        private void GridDisplays_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
                grid.SelectedRows[0].Selected = false;
            grid.ClearSelection();
        }

        private void AddDisplay(string ip)//string name, Image img)
        {
            for (int i = 0; i < grid.RowCount; i++)
                if (grid.Rows[i].Tag.Equals(ip))
                    return;


            int id = grid.Rows.Add();
            string name = "--Offline--";
            string resolution = "--Offline--";

            //Connection Test
            Probe probe = new Probe();
            bool isConnected = probe.TestIP(ip, true);
            grid.Rows[id].Tag = ip;
            if (isConnected)
            {
                grid.Rows[id].Cells[0].Value = Projection_Client.Properties.Resources.connected_sm;
                DisplayClient dc = new DisplayClient();
                dc.Connect(ip);
                name = dc.RequestName();
                resolution = dc.RequestResolution();
                dc.Disconnect();
            }
            else
                grid.Rows[id].Cells[0].Value = Projection_Client.Properties.Resources.disconnected_sm;
            //gridDisplays.Rows[id].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.Rows[id].Cells[1].Value = name;
            grid.Rows[id].Cells[2].Value = resolution;
            //gridDisplays.Rows[id].Tag
            File.AppendAllText("screens.txt", ip + "\n");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddScreen_Click(object sender, EventArgs e)
        {
            AddScreen addScreen = new AddScreen();
            addScreen.ShowDialog(this);
            if (addScreen.Tag == null)
                return;
            List<string> ips = (List<string>)addScreen.Tag;
            foreach (string ip in ips)
                AddDisplay(ip);
                //Console.WriteLine(ip);
        }

        private void SendImageToIP(string ip, Image img)
        {
            try
            {
                DisplayClient sender = new DisplayClient();
                sender.Connect(IPAddress.Parse(ip));
                ProjectionObj proj = new ProjectionObj(DateTime.Now, DateTime.Now.AddHours(1))
                {
                    isDefault = true
                };
                proj.AddSlide(img);
                sender.SendProjection(proj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        //Note, this will have to set default image based on which client
        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            if (grid.RowCount == 0)
            {
                MessageBox.Show(this, "Please add a screen first using 'Add Screen'!", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else 
            {
                if(grid.SelectedRows.Count == 0)
                {
                    MessageBox.Show(this, "Please select a screen first.", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string ip = (string)grid.Rows[0].Tag;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JPG File|*.jpg|PNG File|*.png|TIF File|*.tif";
                if (ofd.ShowDialog() == DialogResult.Cancel) return;
                SendImageToIP(ip, new Bitmap(ofd.FileName));
            }
        }

        private void btnDeleteScreen_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to delete this screen?", "Projector", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (grid.SelectedRows.Count < 1)
                    return;
                if (grid.SelectedRows.Count == 0) return;
                string removalIp = (string)grid.SelectedRows[0].Tag;
                grid.Rows.Remove(grid.SelectedRows[0]);
                string[] screens = File.ReadAllLines("screens.txt");
                List<string> screens_out = new List<string>();
                foreach (string ip in screens)
                    if (!ip.Equals(removalIp))
                        screens_out.Add(ip);
                File.WriteAllLines("screens.txt", screens_out.ToArray());
            }
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            (new AboutForm()).ShowDialog(this);
        }

        private string GetIPFromName(string name)
        {
            return null;
        }


        private void btnImportSlides_Click(object sender, EventArgs e)
        {
            #if MSO_BUILD
            if (gridDisplays.RowCount == 0)
            {
                MessageBox.Show(this, "Please add a screen first using 'Add Screen'!", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            //Ret: Name,WidthxHeight,IP
            string screen = ShowSelector();
            if (screen == null)
                return;
            string[] splData = screen.Split(',');
            int width = int.Parse(splData[1].Split('x')[0]);
            int height = int.Parse(splData[1].Split('x')[1]);
            string ip = splData[2];

            if (screen == null)
                return;
            
            //string selScreenRes = screen.Substring(screen.IndexOf("[") + 1);
            //selScreenRes = selScreenRes.Substring(0, selScreenRes.Length - 1);
            //int width = int.Parse(selScreenRes.Split('x')[0]);
            //int height = int.Parse(selScreenRes.Split('x')[1]);

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Power Point|*.pptx|All Files|*.*";
            ofd.ShowDialog();
            if (String.IsNullOrEmpty(ofd.FileName)) return;
            ApplicationClass pptApp = new ApplicationClass();

            Presentation pres = pptApp.Presentations.Open(ofd.FileName, MsoTriState.msoFalse,
MsoTriState.msoFalse, MsoTriState.msoFalse);

            List<string> files = new List<string>();
            for (int i = 1; i <= pres.Slides.Count; i++)
            {
                string file = Environment.CurrentDirectory + @"\slide" + i + ".png";
                files.Add(file);
                pres.Slides[i].Export(file, "PNG", width, height);
            }
            ProjectionCreator pc = new ProjectionCreator(files);
            pc.ShowDialog(this);
            if (pc.Tag == null)
                return;
            Projection proj = (Projection)pc.Tag;            
            DisplayClient client = new DisplayClient();
            client.Connect(ip);
            client.SendProjection(proj);
            client.Disconnect();
            client = null;
            //MessageBox.Show(client.RequestProjectionManager().GetName());
            #endif
        }


        private void ProjectorMain_FormClosing(object sender, FormClosingEventArgs e)
        {            

        }

        string ShowSelector()
        {
            List<string> screens = new List<string>();
            for (int i = 0; i < grid.RowCount; i++)
                screens.Add(grid.Rows[i].Cells[1].Value + "," + grid.Rows[i].Cells[2].Value + "," + grid.Rows[i].Tag.ToString());
            ScreenSelector ss = new ScreenSelector(screens);
            ss.ShowDialog(this);
            if (ss.Tag == null)
                return null;
            string ret = (string)ss.Tag;            
            return ret;
        }

        private void btnCreateProjection_Click(object sender, EventArgs e)
        {

            if(grid.RowCount == 0)
            {
                MessageBox.Show(this, "Please add a screen first using 'Add Screen'!", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProjectionCreator pc = new ProjectionCreator();
            pc.ShowDialog(this);
            ProjectionObj projection = (ProjectionObj)pc.Tag;
            if (projection == null)
                return;
            //Ret: Name,Resolution,IP
            string data = ShowSelector();
            if (data == null)
                return;
            string[] splData = data.Split(',');
            string ip = splData[2];

            DisplayClient client = new DisplayClient();
            client.Connect(ip);
            client.SendProjection(projection);
            client.Disconnect();
            client = null;
            
        }
    }
}
