namespace WindowsFormsApplication1
{
    partial class coopTable
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
            this.coopdatagrid = new System.Windows.Forms.DataGridView();
            this.coEmployer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coTerm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.coopdatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // coopdatagrid
            // 
            this.coopdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coopdatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coEmployer,
            this.coDegree,
            this.coCity,
            this.coTerm});
            this.coopdatagrid.Location = new System.Drawing.Point(64, 31);
            this.coopdatagrid.Margin = new System.Windows.Forms.Padding(4);
            this.coopdatagrid.Name = "coopdatagrid";
            this.coopdatagrid.Size = new System.Drawing.Size(843, 594);
            this.coopdatagrid.TabIndex = 5;
            // 
            // coEmployer
            // 
            this.coEmployer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.coEmployer.HeaderText = "Employer";
            this.coEmployer.Name = "coEmployer";
            this.coEmployer.Width = 200;
            // 
            // coDegree
            // 
            this.coDegree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.coDegree.HeaderText = "Degree";
            this.coDegree.Name = "coDegree";
            this.coDegree.Width = 200;
            // 
            // coCity
            // 
            this.coCity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.coCity.HeaderText = "City";
            this.coCity.Name = "coCity";
            this.coCity.Width = 200;
            // 
            // coTerm
            // 
            this.coTerm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.coTerm.HeaderText = "Term";
            this.coTerm.Name = "coTerm";
            this.coTerm.Width = 200;
            // 
            // coopTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 661);
            this.Controls.Add(this.coopdatagrid);
            this.Name = "coopTable";
            this.Text = "coopTable";
            ((System.ComponentModel.ISupportInitialize)(this.coopdatagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView coopdatagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn coEmployer;
        private System.Windows.Forms.DataGridViewTextBoxColumn coDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn coCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn coTerm;
    }
}