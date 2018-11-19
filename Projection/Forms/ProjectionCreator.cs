using Projection_Library.Classes;
using Projection.Classes;
using Projection.Classes.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projection.Forms
{
    public partial class ProjectionCreator : Form
    {
        public ProjectionCreator()
        {
            InitializeComponent();
            Icon = Icon.FromHandle(Projection_Client.Properties.Resources.projector.GetHicon());
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now.AddHours(1);

        }

        public ProjectionCreator(List<string> images)
        {
            InitializeComponent();
            Icon = Icon.FromHandle(Projection_Client.Properties.Resources.projector.GetHicon());
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now.AddHours(1);
            foreach(string file in images)
                AddFile(file);
        }


        private void ProjectionCreator_Load(object sender, EventArgs e)
        {
            //double minutes = (double)nudTotalMinutes.Value;            
            //TimeSpan ts = new TimeSpan(0, (int)nudTotalMinutes.Value, 0);
            //DateTime ret = dtpEnd.Value.Date.Add(ts);
            //dtpEnd.Value = ret;
            //Console.WriteLine();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (String.IsNullOrEmpty(ofd.FileName))
                return; //msg??
            AddFile(ofd.FileName);

        }

        private void AddFile(string filePath)
        {
            int id = gridContent.Rows.Add();
            gridContent.Rows[id].Cells[0].Value = filePath;
            double numBytes = File.ReadAllBytes(filePath).Length;
            double numMB = numBytes / 1048576;
            string mbValue = string.Empty;            
            mbValue = string.Format("{0:N}MB", numMB);            
            gridContent.Rows[id].Cells[1].Value = mbValue;            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridContent.RowCount < 1)
            {
                MessageBox.Show(this, "Doh, there are no images to remove!", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            gridContent.Rows.RemoveAt(gridContent.SelectedRows[0].Index);
        }



        private void btnView_Click(object sender, EventArgs e)
        {
            if (gridContent.RowCount < 1)
            {
                MessageBox.Show(this, "Doh, there are no images to remove!", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Form vForm = new Form();
                PictureBox vBox = new PictureBox();
                vForm.Icon = Icon.FromHandle(Projection_Client.Properties.Resources.picture.GetHicon());
                vBox.SizeMode = PictureBoxSizeMode.StretchImage;
                vForm.Controls.Add(vBox);
                vBox.Image = Image.FromFile((string)gridContent.SelectedRows[0].Cells[0].Value);
                vBox.Dock = DockStyle.Fill;
                vForm.StartPosition = FormStartPosition.CenterParent;
                vForm.Size = new Size(500, 500);
                vForm.KeyPreview = true;
                vForm.Text = "PhotoViewer -- Press Any Key To Exit";
                vForm.KeyUp += (se, ev) =>
                {
                    vForm.Close();
                };
                vForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(this, "There was an issue viewing the image.", "Projection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            double minutes = (dtpEnd.Value - dtpStart.Value).TotalMinutes;
            if (minutes > 0 && minutes != (double)nudTotalMinutes.Value)
                nudTotalMinutes.Value = (decimal)minutes;

        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            double minutes = (dtpEnd.Value - dtpStart.Value).TotalMinutes;
            if (minutes > 0 && minutes != (double)nudTotalMinutes.Value)
                nudTotalMinutes.Value = (decimal)minutes;
        }

        private void nudTotalMinutes_ValueChanged(object sender, EventArgs e)
        {
            //double minutes = (double)nudTotalMinutes.Value;
            //TimeSpan ts = new TimeSpan(0, (int)nudTotalMinutes.Value, 0);
            //DateTime ret = dtpEnd.Value.Date.Add(ts);
            dtpEnd.Value = dtpStart.Value.AddMinutes((double)nudTotalMinutes.Value);
            //dtpEnd.Value = ret;
        }

        private void gbStartAndDuration_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gb = sender as GroupBox;
            Utility.DrawGroupBox(gb, e.Graphics, Color.Black, Color.DarkBlue, true);
        }

        private void gbEnd_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gb = sender as GroupBox;
            Utility.DrawGroupBox(gb, e.Graphics, Color.Black, Color.DarkBlue, true);
        }

        private void gbContent_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gb = sender as GroupBox;
            Utility.DrawGroupBox(gb, e.Graphics, Color.Black, Color.DarkBlue, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ProjectionObj proj = new ProjectionObj(dtpStart.Value, dtpEnd.Value);
            for(int i = 0; i < gridContent.RowCount; i++)
            {
                string file = (string)gridContent.Rows[i].Cells[0].Value;
                proj.AddSlide(file);
            }
            proj.title = Constants.DEFAULT_TITLE;
            Tag = proj;
            Close();
        }
    }
}
