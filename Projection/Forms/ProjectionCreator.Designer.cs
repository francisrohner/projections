namespace Projection.Forms
{
    partial class ProjectionCreator
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
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudTotalMinutes = new System.Windows.Forms.NumericUpDown();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.gridContent = new System.Windows.Forms.DataGridView();
            this.ColFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnView = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbStartAndDuration = new System.Windows.Forms.GroupBox();
            this.gbEnd = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalMinutes)).BeginInit();
            this.gbContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContent)).BeginInit();
            this.gbStartAndDuration.SuspendLayout();
            this.gbEnd.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy/MM/dd hh:mm tt";
            this.dtpStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(7, 26);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(228, 26);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(308, 26);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(71, 18);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Duration:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(547, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minutes";
            // 
            // nudTotalMinutes
            // 
            this.nudTotalMinutes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotalMinutes.Location = new System.Drawing.Point(386, 23);
            this.nudTotalMinutes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudTotalMinutes.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTotalMinutes.Name = "nudTotalMinutes";
            this.nudTotalMinutes.Size = new System.Drawing.Size(154, 26);
            this.nudTotalMinutes.TabIndex = 1;
            this.nudTotalMinutes.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudTotalMinutes.ValueChanged += new System.EventHandler(this.nudTotalMinutes_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy/MM/dd hh:mm tt";
            this.dtpEnd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(7, 26);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(228, 26);
            this.dtpEnd.TabIndex = 2;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.gridContent);
            this.gbContent.Controls.Add(this.btnView);
            this.gbContent.Controls.Add(this.btnDelete);
            this.gbContent.Controls.Add(this.btnAdd);
            this.gbContent.Location = new System.Drawing.Point(12, 195);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(618, 211);
            this.gbContent.TabIndex = 2;
            this.gbContent.TabStop = false;
            this.gbContent.Text = "Content";
            this.gbContent.Paint += new System.Windows.Forms.PaintEventHandler(this.gbContent_Paint);
            // 
            // gridContent
            // 
            this.gridContent.AllowDrop = true;
            this.gridContent.AllowUserToAddRows = false;
            this.gridContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColFileName,
            this.ColumnSize});
            this.gridContent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridContent.Location = new System.Drawing.Point(6, 25);
            this.gridContent.MultiSelect = false;
            this.gridContent.Name = "gridContent";
            this.gridContent.RowHeadersVisible = false;
            this.gridContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridContent.Size = new System.Drawing.Size(479, 180);
            this.gridContent.TabIndex = 3;
            // 
            // ColFileName
            // 
            this.ColFileName.HeaderText = "File Name";
            this.ColFileName.Name = "ColFileName";
            this.ColFileName.Width = 250;
            // 
            // ColumnSize
            // 
            this.ColumnSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSize.HeaderText = "Size";
            this.ColumnSize.Name = "ColumnSize";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(491, 113);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(121, 38);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(491, 69);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 38);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(491, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 38);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gbStartAndDuration
            // 
            this.gbStartAndDuration.Controls.Add(this.dtpStart);
            this.gbStartAndDuration.Controls.Add(this.lblDuration);
            this.gbStartAndDuration.Controls.Add(this.nudTotalMinutes);
            this.gbStartAndDuration.Controls.Add(this.label1);
            this.gbStartAndDuration.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStartAndDuration.Location = new System.Drawing.Point(12, 12);
            this.gbStartAndDuration.Name = "gbStartAndDuration";
            this.gbStartAndDuration.Size = new System.Drawing.Size(618, 67);
            this.gbStartAndDuration.TabIndex = 0;
            this.gbStartAndDuration.TabStop = false;
            this.gbStartAndDuration.Text = "Start Date/Time and Duration";
            this.gbStartAndDuration.Paint += new System.Windows.Forms.PaintEventHandler(this.gbStartAndDuration_Paint);
            // 
            // gbEnd
            // 
            this.gbEnd.Controls.Add(this.dtpEnd);
            this.gbEnd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEnd.Location = new System.Drawing.Point(12, 112);
            this.gbEnd.Name = "gbEnd";
            this.gbEnd.Size = new System.Drawing.Size(618, 77);
            this.gbEnd.TabIndex = 1;
            this.gbEnd.TabStop = false;
            this.gbEnd.Text = "End Date and Time";
            this.gbEnd.Paint += new System.Windows.Forms.PaintEventHandler(this.gbEnd_Paint);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(490, 412);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(140, 38);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 412);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 38);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProjectionCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 460);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbEnd);
            this.Controls.Add(this.gbStartAndDuration);
            this.Controls.Add(this.gbContent);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProjectionCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Projection Creator";
            this.Load += new System.EventHandler(this.ProjectionCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalMinutes)).EndInit();
            this.gbContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridContent)).EndInit();
            this.gbStartAndDuration.ResumeLayout(false);
            this.gbStartAndDuration.PerformLayout();
            this.gbEnd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTotalMinutes;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.GroupBox gbStartAndDuration;
        private System.Windows.Forms.GroupBox gbEnd;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView gridContent;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.Button btnView;
    }
}