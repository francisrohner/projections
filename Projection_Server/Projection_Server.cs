using Projection.Classes;
using Projection.Classes.Utilities;
using Projection_Library.Classes;
using Projection_Library.Classes.Networking;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Projection_Server
{
    public partial class Projection_Server : Form
    {

        private int iterator = 0;
        private Stopwatch intervalWatch;
        private ProjectionObj currentProjection = null;
        private ProjectionManager projectionManager;
        private DisplayServer displayServer;
        private Timer transitionTimer;
        private float transitionStep;
        private Image transitionImgOne;
        private Image transitionImgTwo;

        private bool warmup;
        private int warmup_time_left = 15;

        public Projection_Server(bool debugMode = false)
        {
            InitializeComponent();
            lblIP.Parent = pbProject;
            lblIP.Font = new Font(lblIP.Font.FontFamily, 16.0f); // FontStyle.Bold, 32.0f);
            lblIP.TextAlign = ContentAlignment.MiddleCenter;
            IPAddress[] ipv4Addresses = Array.FindAll(Dns.GetHostEntry(string.Empty).AddressList,
            a => a.AddressFamily == AddressFamily.InterNetwork);
            lblIP.BackColor = Color.White;
            lblIP.Text = ipv4Addresses.Last().ToString();
            warmup = true;

            transitionTimer = new Timer()
            {
                Interval = 25
            };
            transitionStep = 0;

            if (debugMode)
            {
                StartPosition = FormStartPosition.Manual;
                Left = 0;
                Top = 0;
                Left = 2000;
                debugMode = false;
            }

            intervalWatch = new Stopwatch();
            //saveProjectionManagerWatch = new Stopwatch();
            //intervalWatch.Start();
            //saveProjectionManagerWatch.Start();

          

            //Clear out base image
            pbProject.Image = null;

            if (!debugMode)
                WindowState = FormWindowState.Maximized;
            //pbProject.Dock = DockStyle.None;

            if (!File.Exists("collection.pm"))
            {
                projectionManager = new ProjectionManager(Properties.Resources.scenic1);
                //Projection defaultProj = new Projection(DateTime.Now, DateTime.MinValue, DateTime.MaxValue)
                //{
                //    isDefault = true
                //};
            }
            else //Serialized data found
            {
                try
                {                    
                    projectionManager = ProjectionManager.Deserialize("collection.pm");
                    if (projectionManager == null)
                        throw new Exception("Failed to deserialize ProjectionManager state :(");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show(this, "There was an error loading previously scheduled projections.\nData may be corrupt.", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    projectionManager = new ProjectionManager(Properties.Resources.scenic1);
                }
            }

            displayServer = new DisplayServer();
            displayServer.projectionManager = projectionManager;
            displayServer.ReceivedProjection += ReceiveProjection;
            displayServer.Start();

            tmrUpdate.Start();
            intervalWatch.Start();
        }

        /// <summary>
        /// When a projection is received from client add it to the Projection Manger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReceiveProjection(object sender, EventArgs e)
        {
            ProjectionObj projection = (ProjectionObj)sender;
            projectionManager.AddProjection(projection);
            //Switch
            if (currentProjection.isDefault && projection.isDefault)
            {
                //currentProjection = projection;
                //DisplaySlide(projection.GetImages().First());
            }
            Save();
        }

        private void DisplaySlide(Image image)
        {
            if (pbProject.Image == null)                
                pbProject.Image = image;
            else                
                TransitionSlide(pbProject, pbProject.Image, image);
        }

        private void Projection_Server_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Close();
            //else if (e.KeyData == Keys.Left)
            //    TransitionSlide(pbProject, pbProject.Image, Image.FromFile(@"C:\Debug\Chevelle.jpg"));


        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if(warmup && --warmup_time_left <= 0)
            {
                warmup = false;
                lblIP.Hide();
            }

            if (currentProjection != null)
            {
                if (currentProjection.isDefault) //Check if scheduled projection is available
                {
                    ProjectionObj schedProj = projectionManager.GetCurrentProjection();
                    if (schedProj != null) //Scheduled Projection is Available
                    {
                        currentProjection = schedProj;
                        intervalWatch.Restart();
                        DisplaySlide(currentProjection.GetImages().First());
                    }
                    else if (!projectionManager.GetDefaultProjection().Equals(currentProjection))
                    {
                        currentProjection = projectionManager.GetDefaultProjection();
                        intervalWatch.Restart();
                        DisplaySlide(currentProjection.GetImages().First());                        
                    }
                }
                else //non-default projection
                {
                    DateTimeRange currentRange = new DateTimeRange(DateTime.Now, DateTime.Now.AddSeconds(1));
                    bool isProjCurrent = currentProjection.scheduledDateTimes.Any(range => range.Intersects(currentRange));
                    if (!isProjCurrent)
                    {
                        //Cleanup
                        //TODO_LATER make sure this won't collide with 'Save' being called when projection is being received
                        projectionManager.DeleteProjection(currentProjection);
                        Save();
                        currentProjection = null;
                        GC.Collect();
                    }              
                }

                if (currentProjection != null && currentProjection.GetImages().Count > 1)
                {
                    if (intervalWatch.Elapsed.Seconds >= currentProjection.changeInterval.Seconds)
                    {
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                        intervalWatch.Restart();
                        ++iterator;
                        if (iterator >= currentProjection.GetImages().Count)
                            iterator = 0;
                        DisplaySlide(currentProjection.GetImages()[iterator]);
                    }
                }

            }
            //Current projection marked for removal, or initialization
            if (currentProjection == null)
            {
                //Display default image or retrieve current

                currentProjection = projectionManager.GetDefaultProjection();
                intervalWatch.Restart();

                //Add dummy image so fade will be executed
                if (pbProject.Image == null)
                {
                    Bitmap bmp = new Bitmap(pbProject.Width, pbProject.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.FillRectangle(Brushes.LightGray, 0, 0, pbProject.Width, pbProject.Height);
                    pbProject.Image = bmp;
                }
                DisplaySlide(currentProjection.GetImages().First());
            }



        }


        private void TransitionRight_Tick(object sender, EventArgs e)
        {
            Bitmap stage = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(stage);
            //

            int maxStep = Width / 10;

            transitionStep += 100;
            if (transitionStep >= Width)
            {

                pbProject.Image = transitionImgTwo;
                //Unregister transition
                //Replace later

                transitionTimer.Stop();
                transitionTimer.Dispose();
                return;
            }

            g.DrawImage(transitionImgOne, new PointF(transitionStep, 0));
            g.DrawImage(transitionImgTwo, new PointF(0 - (Width - transitionStep), 0));
            pbProject.Image = stage;
            pbProject.Refresh();

        }

        private void TransitionLeft_Tick(object sender, EventArgs e)
        {
            Bitmap stage = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(stage);

            transitionStep -= 100;
            if (transitionStep <= 0)
            {                
                pbProject.Image = transitionImgTwo;
                transitionTimer.Stop();                
                transitionTimer.Dispose();
                return;
            }
            g.DrawImage(transitionImgTwo, new PointF(transitionStep, 0));
            g.DrawImage(transitionImgOne, new PointF(0 - (Width - transitionStep), 0));
            pbProject.Image = stage;
            pbProject.Refresh();
        }

        private void TransitionOut_Tick(object sender, EventArgs e)
        {
            Bitmap stage = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(stage);
            DoubleBuffered = true;

            if (transitionStep <= 0.0f)
            {
                pbProject.Image = transitionImgTwo;                
                transitionTimer.Stop();
                transitionTimer.Dispose();
                return;
            }
            g.DrawImage(transitionImgTwo, new Point(0, 0));
            Image temp = Utility.SetImageOpacity(transitionImgOne, transitionStep);
            g.DrawImage(temp, new Point(0, 0));
            pbProject.Image = stage;
            pbProject.Refresh();
            transitionStep -= 0.05f;
        }

        private void TransitionIn_Tick(object sender, EventArgs e)
        {
            try
            {
                Bitmap stage = new Bitmap(Width, Height);
                Graphics g = Graphics.FromImage(stage);
                if (transitionStep >= 1.0f)
                {
                    pbProject.Image = transitionImgTwo;                    
                    transitionTimer.Stop();
                    transitionTimer.Dispose();
                    return;
                }
                g.DrawImage(transitionImgOne, new Point(0, 0));
                Image temp = Utility.SetImageOpacity(transitionImgTwo, transitionStep);
                g.DrawImage(temp, new Point(0, 0));
                pbProject.Image = stage;
                pbProject.Refresh();
                transitionStep += 0.05f;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        void TransitionSlide(PictureBox pb, Image imgOne, Image imgTwo, char fx = 'i')
        {
            Application.DoEvents();
            if(transitionTimer != null && transitionTimer.Enabled)
            {
                Console.WriteLine("Transition already in progress");
                return;
            }
            
            Bitmap stage = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(stage);
            transitionTimer = new Timer();
            transitionTimer.Interval = 25;
            transitionImgOne = new Bitmap(imgOne, Width, Height);
            transitionImgTwo = new Bitmap(imgTwo, Width, Height);

            if (fx == 'r') //right
            {
                transitionStep = 0;
                transitionTimer.Tick += TransitionRight_Tick;
            }
            else if (fx == 'l') //left
            {
                //step = Width;
                transitionStep = Width;
                transitionTimer.Tick += TransitionLeft_Tick;
            }
            else if (fx == 'o') //fade out
            {                
                transitionStep = 1.0f;
                transitionTimer.Tick += TransitionOut_Tick;
            }
            else if (fx == 'i') //fade in
            {                
                transitionStep = 0.0f;
                transitionTimer.Tick += TransitionIn_Tick;
            }
            transitionTimer.Start();
        }
        private void Projection_Server_Load(object sender, EventArgs e)
        {
            pbProject.Size = Size;
        }
        private bool SAVE_IN_PROGRESS = false;
        public void Save()
        {
            //if (SAVE_IN_PROGRESS)
            //    return;
            while (SAVE_IN_PROGRESS) ;

            SAVE_IN_PROGRESS = true;
            try
            {
                if (File.Exists("collection.pm"))
                    File.Delete("collection.pm");
                projectionManager.Serialize("collection.pm");
            }
            catch (Exception ex)
            {
                //TODO_LATER log this
                Console.WriteLine(ex.StackTrace);
            }
            SAVE_IN_PROGRESS = false;
        }

        private void Projection_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }
      
    }
}
