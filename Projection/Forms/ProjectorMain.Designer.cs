namespace Projection
{
    partial class ProjectorMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectorMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnImportSlides = new System.Windows.Forms.Button();
            this.btnSetDefault = new System.Windows.Forms.Button();
            this.btnDeleteScreen = new System.Windows.Forms.Button();
            this.btnAddScreen = new System.Windows.Forms.Button();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsdFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.importFromSlidesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.grid = new System.Windows.Forms.DataGridView();
            this.ColConnectionStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColResolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSidebar.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSidebar.Controls.Add(this.btnImportSlides);
            this.pnlSidebar.Controls.Add(this.btnSetDefault);
            this.pnlSidebar.Controls.Add(this.btnDeleteScreen);
            this.pnlSidebar.Controls.Add(this.btnAddScreen);
            this.pnlSidebar.Controls.Add(this.btnUploadImage);
            this.pnlSidebar.Location = new System.Drawing.Point(0, 28);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(157, 351);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnImportSlides
            // 
            this.btnImportSlides.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportSlides.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportSlides.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportSlides.Image = global::Projection_Client.Properties.Resources.photo_slideshow;
            this.btnImportSlides.Location = new System.Drawing.Point(3, 227);
            this.btnImportSlides.Name = "btnImportSlides";
            this.btnImportSlides.Size = new System.Drawing.Size(150, 50);
            this.btnImportSlides.TabIndex = 1;
            this.btnImportSlides.Text = "Import Slides";
            this.btnImportSlides.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportSlides.UseVisualStyleBackColor = true;
            this.btnImportSlides.Click += new System.EventHandler(this.btnImportSlides_Click);
            // 
            // btnSetDefault
            // 
            this.btnSetDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetDefault.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetDefault.Image = global::Projection_Client.Properties.Resources.picture;
            this.btnSetDefault.Location = new System.Drawing.Point(3, 115);
            this.btnSetDefault.Name = "btnSetDefault";
            this.btnSetDefault.Size = new System.Drawing.Size(150, 50);
            this.btnSetDefault.TabIndex = 0;
            this.btnSetDefault.Text = "Set Default Projection";
            this.btnSetDefault.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetDefault.UseVisualStyleBackColor = true;
            this.btnSetDefault.Click += new System.EventHandler(this.btnSetDefault_Click);
            // 
            // btnDeleteScreen
            // 
            this.btnDeleteScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteScreen.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteScreen.Image = global::Projection_Client.Properties.Resources.clear_button;
            this.btnDeleteScreen.Location = new System.Drawing.Point(3, 59);
            this.btnDeleteScreen.Name = "btnDeleteScreen";
            this.btnDeleteScreen.Size = new System.Drawing.Size(150, 50);
            this.btnDeleteScreen.TabIndex = 0;
            this.btnDeleteScreen.Text = "Remove Screen";
            this.btnDeleteScreen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteScreen.UseVisualStyleBackColor = true;
            this.btnDeleteScreen.Click += new System.EventHandler(this.btnDeleteScreen_Click);
            // 
            // btnAddScreen
            // 
            this.btnAddScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddScreen.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddScreen.Image = global::Projection_Client.Properties.Resources.tv_screen;
            this.btnAddScreen.Location = new System.Drawing.Point(3, 3);
            this.btnAddScreen.Name = "btnAddScreen";
            this.btnAddScreen.Size = new System.Drawing.Size(150, 50);
            this.btnAddScreen.TabIndex = 0;
            this.btnAddScreen.Text = "Add Screen";
            this.btnAddScreen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddScreen.UseVisualStyleBackColor = true;
            this.btnAddScreen.Click += new System.EventHandler(this.btnAddScreen_Click);
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadImage.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.Image = global::Projection_Client.Properties.Resources.cloud_computing;
            this.btnUploadImage.Location = new System.Drawing.Point(3, 171);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(150, 50);
            this.btnUploadImage.TabIndex = 0;
            this.btnUploadImage.Text = "Create Projection";
            this.btnUploadImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnCreateProjection_Click);
            // 
            // tsMain
            // 
            this.tsMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdFile,
            this.tsbOptions,
            this.tsbAbout});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(820, 26);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsdFile
            // 
            this.tsdFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsdFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromSlidesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.tsdFile.Image = ((System.Drawing.Image)(resources.GetObject("tsdFile.Image")));
            this.tsdFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdFile.Name = "tsdFile";
            this.tsdFile.Size = new System.Drawing.Size(42, 23);
            this.tsdFile.Text = "&File";
            // 
            // importFromSlidesToolStripMenuItem
            // 
            this.importFromSlidesToolStripMenuItem.Name = "importFromSlidesToolStripMenuItem";
            this.importFromSlidesToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.importFromSlidesToolStripMenuItem.Text = "&Import From Slides";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tsbOptions
            // 
            this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbOptions.Image")));
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(62, 23);
            this.tsbOptions.Text = "Options";
            // 
            // tsbAbout
            // 
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(51, 23);
            this.tsbAbout.Text = "About";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // gridDisplays
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColConnectionStatus,
            this.ColDisplayName,
            this.ColResolution});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid.Location = new System.Drawing.Point(159, 28);
            this.grid.MultiSelect = false;
            this.grid.Name = "gridDisplays";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(661, 351);
            this.grid.TabIndex = 2;
            // 
            // ColConnectionStatus
            // 
            this.ColConnectionStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColConnectionStatus.HeaderText = "Connection Status";
            this.ColConnectionStatus.Name = "ColConnectionStatus";
            this.ColConnectionStatus.ReadOnly = true;
            this.ColConnectionStatus.Width = 120;
            // 
            // ColDisplayName
            // 
            this.ColDisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColDisplayName.HeaderText = "Display Name";
            this.ColDisplayName.Name = "ColDisplayName";
            this.ColDisplayName.ReadOnly = true;
            this.ColDisplayName.Width = 250;
            // 
            // ColResolution
            // 
            this.ColResolution.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColResolution.HeaderText = "Resolution";
            this.ColResolution.Name = "ColResolution";
            this.ColResolution.ReadOnly = true;
            // 
            // ProjectorMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 379);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "ProjectorMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectorMain_FormClosing);
            this.pnlSidebar.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripDropDownButton tsdFile;
        private System.Windows.Forms.ToolStripMenuItem importFromSlidesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnAddScreen;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnImportSlides;
        private System.Windows.Forms.Button btnDeleteScreen;
        private System.Windows.Forms.ToolStripButton tsbOptions;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnSetDefault;
        private System.Windows.Forms.DataGridViewImageColumn ColConnectionStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColResolution;
    }
}

