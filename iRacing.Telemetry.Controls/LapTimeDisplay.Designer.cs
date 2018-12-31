namespace iRacing.Telemetry.Controls
{
    partial class LapTimeDisplay
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
            this.lstLapTimes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstLapTimes
            // 
            this.lstLapTimes.BackColor = System.Drawing.Color.Black;
            this.lstLapTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLapTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLapTimes.ForeColor = System.Drawing.Color.White;
            this.lstLapTimes.FormattingEnabled = true;
            this.lstLapTimes.ItemHeight = 16;
            this.lstLapTimes.Items.AddRange(new object[] {
            "12.345",
            "67.890"});
            this.lstLapTimes.Location = new System.Drawing.Point(0, 0);
            this.lstLapTimes.Name = "lstLapTimes";
            this.lstLapTimes.Size = new System.Drawing.Size(261, 199);
            this.lstLapTimes.TabIndex = 0;
            // 
            // LapTimeDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 199);
            this.Controls.Add(this.lstLapTimes);
            this.Name = "LapTimeDisplay";
            this.Text = "Lap Times";
            this.Load += new System.EventHandler(this.LapTimeDisplay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstLapTimes;
    }
}