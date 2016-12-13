namespace WindowsFormsApplication1
{
    partial class empTable
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
            this.empdatagrid = new System.Windows.Forms.DataGridView();
            this.emEmployer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emTerm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emstartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.empdatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // empdatagrid
            // 
            this.empdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empdatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emEmployer,
            this.emDegree,
            this.emCity,
            this.emTerm,
            this.emstartDate});
            this.empdatagrid.Location = new System.Drawing.Point(28, 25);
            this.empdatagrid.Margin = new System.Windows.Forms.Padding(4);
            this.empdatagrid.Name = "empdatagrid";
            this.empdatagrid.Size = new System.Drawing.Size(1042, 594);
            this.empdatagrid.TabIndex = 4;
            // 
            // emEmployer
            // 
            this.emEmployer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.emEmployer.HeaderText = "Employer";
            this.emEmployer.Name = "emEmployer";
            this.emEmployer.Width = 200;
            // 
            // emDegree
            // 
            this.emDegree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.emDegree.HeaderText = "Degree";
            this.emDegree.Name = "emDegree";
            this.emDegree.Width = 200;
            // 
            // emCity
            // 
            this.emCity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.emCity.HeaderText = "City";
            this.emCity.Name = "emCity";
            this.emCity.Width = 200;
            // 
            // emTerm
            // 
            this.emTerm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.emTerm.HeaderText = "Title";
            this.emTerm.Name = "emTerm";
            this.emTerm.Width = 200;
            // 
            // emstartDate
            // 
            this.emstartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.emstartDate.HeaderText = "Start Date";
            this.emstartDate.Name = "emstartDate";
            this.emstartDate.ReadOnly = true;
            this.emstartDate.Width = 200;
            // 
            // empTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 655);
            this.Controls.Add(this.empdatagrid);
            this.Name = "empTable";
            this.Text = "empTable";
            ((System.ComponentModel.ISupportInitialize)(this.empdatagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView empdatagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn emEmployer;
        private System.Windows.Forms.DataGridViewTextBoxColumn emDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn emCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn emTerm;
        private System.Windows.Forms.DataGridViewTextBoxColumn emstartDate;
    }
}