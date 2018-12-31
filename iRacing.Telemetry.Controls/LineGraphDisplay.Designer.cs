namespace iRacing.Telemetry.Controls
{
    partial class LineGraphDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineGraphDisplay));
            this.lineGraph1 = new iRacing.Telemetry.Controls.LineGraph();
            this.ctxLineGraphMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displayInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxLineGraphMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lineGraph1
            // 
            this.lineGraph1.DisplayInfo = null;
            this.lineGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineGraph1.Field = null;
            this.lineGraph1.FrameIdx = -1;
            this.lineGraph1.Frames = null;
            this.lineGraph1.LapIdx = 1;
            this.lineGraph1.Laps = null;
            this.lineGraph1.Location = new System.Drawing.Point(0, 0);
            this.lineGraph1.Name = "lineGraph1";
            this.lineGraph1.Padding = new System.Windows.Forms.Padding(8);
            this.lineGraph1.Size = new System.Drawing.Size(800, 450);
            this.lineGraph1.TabIndex = 0;
            this.lineGraph1.xAxisRange = ((System.Collections.Generic.IList<float>)(resources.GetObject("lineGraph1.xAxisRange")));
            this.lineGraph1.yAxisData = null;
            // 
            // ctxLineGraphMenu
            // 
            this.ctxLineGraphMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayInfoToolStripMenuItem});
            this.ctxLineGraphMenu.Name = "ctxLineGraphMenu";
            this.ctxLineGraphMenu.Size = new System.Drawing.Size(137, 26);
            // 
            // displayInfoToolStripMenuItem
            // 
            this.displayInfoToolStripMenuItem.Name = "displayInfoToolStripMenuItem";
            this.displayInfoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.displayInfoToolStripMenuItem.Text = "Display Info";
            this.displayInfoToolStripMenuItem.Click += new System.EventHandler(this.displayInfoToolStripMenuItem_Click);
            // 
            // LineGraphDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.ctxLineGraphMenu;
            this.Controls.Add(this.lineGraph1);
            this.KeyPreview = true;
            this.Name = "LineGraphDisplay";
            this.Text = "LineGraphDisplay";
            this.Load += new System.EventHandler(this.LineGraphDisplay_Load);
            this.ctxLineGraphMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LineGraph lineGraph1;
        private System.Windows.Forms.ContextMenuStrip ctxLineGraphMenu;
        private System.Windows.Forms.ToolStripMenuItem displayInfoToolStripMenuItem;
    }
}