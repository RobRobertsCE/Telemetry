namespace iRacing.Telemetry.Controls
{
    partial class HistogramGraph
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblField = new System.Windows.Forms.Label();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblField
            // 
            this.lblField.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblField.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblField.Location = new System.Drawing.Point(0, 0);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(373, 18);
            this.lblField.TabIndex = 0;
            this.lblField.Text = "label1";
            this.lblField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphPanel
            // 
            this.graphPanel.BackColor = System.Drawing.Color.Black;
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.Location = new System.Drawing.Point(0, 18);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(373, 266);
            this.graphPanel.TabIndex = 2;
            // 
            // HistogramGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.lblField);
            this.Name = "HistogramGraph";
            this.Size = new System.Drawing.Size(373, 284);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Panel graphPanel;
    }
}
