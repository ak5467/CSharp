namespace WindowsFormsApplication1
{
    partial class resources
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
            this.resourcePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // resourcePanel
            // 
            this.resourcePanel.AutoScroll = true;
            this.resourcePanel.BackColor = System.Drawing.Color.MistyRose;
            this.resourcePanel.Location = new System.Drawing.Point(75, 42);
            this.resourcePanel.Name = "resourcePanel";
            this.resourcePanel.Size = new System.Drawing.Size(628, 591);
            this.resourcePanel.TabIndex = 0;
            // 
            // resources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 675);
            this.Controls.Add(this.resourcePanel);
            this.Name = "resources";
            this.Text = "resources";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel resourcePanel;
    }
}