namespace Projection.Forms
{
    partial class AddScreen
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
            this.lblIP = new System.Windows.Forms.Label();
            this.gbManual = new System.Windows.Forms.GroupBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.gbAuto = new System.Windows.Forms.GroupBox();
            this.lblSearchInProgress = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gridIPList = new System.Windows.Forms.DataGridView();
            this.ColCheckAdd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNickname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ipbManual = new Projection.Controls.IP_Box();
            this.gbManual.SuspendLayout();
            this.gbAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIPList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.Location = new System.Drawing.Point(8, 37);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(91, 20);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "IP Address:";
            // 
            // gbManual
            // 
            this.gbManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbManual.Controls.Add(this.btnAddToList);
            this.gbManual.Controls.Add(this.btTest);
            this.gbManual.Controls.Add(this.lblIP);
            this.gbManual.Location = new System.Drawing.Point(277, 13);
            this.gbManual.Margin = new System.Windows.Forms.Padding(4);
            this.gbManual.Name = "gbManual";
            this.gbManual.Padding = new System.Windows.Forms.Padding(4);
            this.gbManual.Size = new System.Drawing.Size(431, 120);
            this.gbManual.TabIndex = 1;
            this.gbManual.TabStop = false;
            this.gbManual.Text = "Manual";
            this.gbManual.Paint += new System.Windows.Forms.PaintEventHandler(this.gbManual_Paint);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(344, 73);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(80, 40);
            this.btnAddToList.TabIndex = 3;
            this.btnAddToList.Text = "&Add";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(7, 73);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(80, 40);
            this.btTest.TabIndex = 2;
            this.btTest.Text = "&Test";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // gbAuto
            // 
            this.gbAuto.Controls.Add(this.lblSearchInProgress);
            this.gbAuto.Controls.Add(this.btnSearch);
            this.gbAuto.Controls.Add(this.label4);
            this.gbAuto.Controls.Add(this.pbLogo);
            this.gbAuto.Location = new System.Drawing.Point(13, 12);
            this.gbAuto.Name = "gbAuto";
            this.gbAuto.Size = new System.Drawing.Size(257, 190);
            this.gbAuto.TabIndex = 0;
            this.gbAuto.TabStop = false;
            this.gbAuto.Text = "Automatic";
            this.gbAuto.Paint += new System.Windows.Forms.PaintEventHandler(this.gbAuto_Paint);
            // 
            // lblSearchInProgress
            // 
            this.lblSearchInProgress.AutoSize = true;
            this.lblSearchInProgress.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchInProgress.Location = new System.Drawing.Point(6, 159);
            this.lblSearchInProgress.Name = "lblSearchInProgress";
            this.lblSearchInProgress.Size = new System.Drawing.Size(129, 16);
            this.lblSearchInProgress.TabIndex = 5;
            this.lblSearchInProgress.Text = "Search In Progress";
            this.lblSearchInProgress.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Projection_Client.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(107, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(137, 45);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "IP Address:";
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(152, 103);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(92, 81);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // gridIPList
            // 
            this.gridIPList.AllowUserToAddRows = false;
            this.gridIPList.AllowUserToDeleteRows = false;
            this.gridIPList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridIPList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridIPList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCheckAdd,
            this.ColIP,
            this.ColNickname});
            this.gridIPList.Location = new System.Drawing.Point(12, 228);
            this.gridIPList.Name = "gridIPList";
            this.gridIPList.ReadOnly = true;
            this.gridIPList.RowHeadersVisible = false;
            this.gridIPList.Size = new System.Drawing.Size(760, 150);
            this.gridIPList.TabIndex = 4;
            // 
            // ColCheckAdd
            // 
            this.ColCheckAdd.HeaderText = "Add";
            this.ColCheckAdd.Name = "ColCheckAdd";
            this.ColCheckAdd.ReadOnly = true;
            // 
            // ColIP
            // 
            this.ColIP.HeaderText = "IP";
            this.ColIP.Name = "ColIP";
            this.ColIP.ReadOnly = true;
            this.ColIP.Width = 250;
            // 
            // ColNickname
            // 
            this.ColNickname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNickname.HeaderText = "Name";
            this.ColNickname.Name = "ColNickname";
            this.ColNickname.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(571, 384);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(201, 65);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 205);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Screens to Add:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(12, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(201, 65);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ipbManual
            // 
            this.ipbManual.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipbManual.Location = new System.Drawing.Point(383, 46);
            this.ipbManual.Margin = new System.Windows.Forms.Padding(4);
            this.ipbManual.Name = "ipbManual";
            this.ipbManual.Size = new System.Drawing.Size(312, 32);
            this.ipbManual.TabIndex = 1;
            // 
            // AddScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.ipbManual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridIPList);
            this.Controls.Add(this.gbAuto);
            this.Controls.Add(this.gbManual);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "AddScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Projection: Add Screen";
            this.gbManual.ResumeLayout(false);
            this.gbManual.PerformLayout();
            this.gbAuto.ResumeLayout(false);
            this.gbAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIPList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.GroupBox gbManual;
        private System.Windows.Forms.GroupBox gbAuto;
        private System.Windows.Forms.DataGridView gridIPList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheckAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNickname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSearchInProgress;
        private Controls.IP_Box ipbManual;
    }
}