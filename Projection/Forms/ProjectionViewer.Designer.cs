namespace Projection.Forms
{
    partial class ProjectionViewer
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
            this.gridProjections = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumSlides = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridProjections)).BeginInit();
            this.SuspendLayout();
            // 
            // gridProjections
            // 
            this.gridProjections.AllowUserToAddRows = false;
            this.gridProjections.AllowUserToDeleteRows = false;
            this.gridProjections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProjections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProjections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColStart,
            this.ColEnd,
            this.ColNumSlides});
            this.gridProjections.Location = new System.Drawing.Point(14, 78);
            this.gridProjections.Name = "gridProjections";
            this.gridProjections.ReadOnly = true;
            this.gridProjections.RowHeadersVisible = false;
            this.gridProjections.Size = new System.Drawing.Size(491, 299);
            this.gridProjections.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(14, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 55);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(108, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 55);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(203, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 55);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ColName
            // 
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColStart
            // 
            this.ColStart.HeaderText = "Start Date/Time";
            this.ColStart.Name = "ColStart";
            this.ColStart.ReadOnly = true;
            this.ColStart.Width = 150;
            // 
            // ColEnd
            // 
            this.ColEnd.HeaderText = "End Date/Time";
            this.ColEnd.Name = "ColEnd";
            this.ColEnd.ReadOnly = true;
            this.ColEnd.Width = 150;
            // 
            // ColNumSlides
            // 
            this.ColNumSlides.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNumSlides.HeaderText = "No. Slides";
            this.ColNumSlides.Name = "ColNumSlides";
            this.ColNumSlides.ReadOnly = true;
            // 
            // ProjectionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 391);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridProjections);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProjectionViewer";
            this.Text = "ProjectionViewer";
            ((System.ComponentModel.ISupportInitialize)(this.gridProjections)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridProjections;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumSlides;
    }
}