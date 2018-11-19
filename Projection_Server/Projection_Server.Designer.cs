namespace Projection_Server
{
    partial class Projection_Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Projection_Server));
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.pbProject = new System.Windows.Forms.PictureBox();
            this.lblIP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbProject)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 1000;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // pbProject
            // 
            this.pbProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProject.Location = new System.Drawing.Point(0, 0);
            this.pbProject.Name = "pbProject";
            this.pbProject.Size = new System.Drawing.Size(517, 435);
            this.pbProject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProject.TabIndex = 0;
            this.pbProject.TabStop = false;
            // 
            // lblIP
            // 
            this.lblIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIP.BackColor = System.Drawing.Color.Transparent;
            this.lblIP.Location = new System.Drawing.Point(0, 404);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(517, 30);
            this.lblIP.TabIndex = 1;
            // 
            // Projection_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 435);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.pbProject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Projection_Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projection Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Projection_Server_FormClosing);
            this.Load += new System.EventHandler(this.Projection_Server_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Projection_Server_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbProject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProject;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Label lblIP;
    }
}

