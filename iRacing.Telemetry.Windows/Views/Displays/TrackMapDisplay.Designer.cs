namespace iRacing.Telemetry.Windows.Views.Displays
{
    partial class TrackMapDisplay
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstLaps = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkHidenOutLaps = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnFastestLap = new System.Windows.Forms.Button();
            this.lblLaps = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnZoomImageIn = new System.Windows.Forms.ToolStripButton();
            this.btnResetZoom = new System.Windows.Forms.ToolStripButton();
            this.btnZoomImageOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnToggleLapViews = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel1.Controls.Add(this.lstLaps);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(634, 422);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstLaps
            // 
            this.lstLaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLaps.FormattingEnabled = true;
            this.lstLaps.Location = new System.Drawing.Point(4, 99);
            this.lstLaps.Name = "lstLaps";
            this.lstLaps.Size = new System.Drawing.Size(202, 319);
            this.lstLaps.TabIndex = 2;
            this.lstLaps.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstLaps_ItemCheck);
            this.lstLaps.SelectedIndexChanged += new System.EventHandler(this.lstLaps_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkHidenOutLaps);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.lblLaps);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.panel1.Size = new System.Drawing.Size(202, 95);
            this.panel1.TabIndex = 1;
            // 
            // chkHidenOutLaps
            // 
            this.chkHidenOutLaps.BackColor = System.Drawing.Color.Black;
            this.chkHidenOutLaps.Checked = true;
            this.chkHidenOutLaps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHidenOutLaps.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkHidenOutLaps.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkHidenOutLaps.Location = new System.Drawing.Point(0, 61);
            this.chkHidenOutLaps.Name = "chkHidenOutLaps";
            this.chkHidenOutLaps.Size = new System.Drawing.Size(202, 29);
            this.chkHidenOutLaps.TabIndex = 5;
            this.chkHidenOutLaps.Text = "Hide In/Out Laps";
            this.chkHidenOutLaps.UseVisualStyleBackColor = false;
            this.chkHidenOutLaps.CheckedChanged += new System.EventHandler(this.chkHidenOutLaps_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnClearAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectAll, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFastestLap, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(202, 43);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(3, 3);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(50, 37);
            this.btnClearAll.TabIndex = 1;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Location = new System.Drawing.Point(149, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(50, 37);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnFastestLap
            // 
            this.btnFastestLap.Location = new System.Drawing.Point(67, 3);
            this.btnFastestLap.Name = "btnFastestLap";
            this.btnFastestLap.Size = new System.Drawing.Size(68, 37);
            this.btnFastestLap.TabIndex = 2;
            this.btnFastestLap.Text = "Fastest Lap";
            this.btnFastestLap.UseVisualStyleBackColor = true;
            this.btnFastestLap.Click += new System.EventHandler(this.btnFastestLap_Click);
            // 
            // lblLaps
            // 
            this.lblLaps.BackColor = System.Drawing.SystemColors.Control;
            this.lblLaps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLaps.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLaps.Location = new System.Drawing.Point(0, 0);
            this.lblLaps.Name = "lblLaps";
            this.lblLaps.Size = new System.Drawing.Size(202, 18);
            this.lblLaps.TabIndex = 0;
            this.lblLaps.Text = "Lap 0 of 0 to 0";
            this.lblLaps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.picMap);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(404, 406);
            this.panel2.TabIndex = 1;
            // 
            // picMap
            // 
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMap.Location = new System.Drawing.Point(0, 25);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(404, 381);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMap.TabIndex = 0;
            this.picMap.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZoomImageIn,
            this.btnResetZoom,
            this.btnZoomImageOut,
            this.toolStripSeparator1,
            this.btnToggleLapViews});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(404, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnZoomImageIn
            // 
            this.btnZoomImageIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomImageIn.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Zoom_5442;
            this.btnZoomImageIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomImageIn.Name = "btnZoomImageIn";
            this.btnZoomImageIn.Size = new System.Drawing.Size(23, 22);
            this.btnZoomImageIn.Text = "Zoom Image In";
            this.btnZoomImageIn.Click += new System.EventHandler(this.btnZoomImageIn_Click);
            // 
            // btnResetZoom
            // 
            this.btnResetZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnResetZoom.Image = global::iRacing.Telemetry.Windows.Properties.Resources.ZoomToWidth;
            this.btnResetZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResetZoom.Name = "btnResetZoom";
            this.btnResetZoom.Size = new System.Drawing.Size(23, 22);
            this.btnResetZoom.Text = "Reset Zoom";
            this.btnResetZoom.Click += new System.EventHandler(this.btnResetZoom_Click);
            // 
            // btnZoomImageOut
            // 
            this.btnZoomImageOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomImageOut.Image = global::iRacing.Telemetry.Windows.Properties.Resources.ZoomOut_12927;
            this.btnZoomImageOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomImageOut.Name = "btnZoomImageOut";
            this.btnZoomImageOut.Size = new System.Drawing.Size(23, 22);
            this.btnZoomImageOut.Text = "Zoom Image Out";
            this.btnZoomImageOut.Click += new System.EventHandler(this.btnZoomImageOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnToggleLapViews
            // 
            this.btnToggleLapViews.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToggleLapViews.Image = global::iRacing.Telemetry.Windows.Properties.Resources.SplitScreenVertically_12973;
            this.btnToggleLapViews.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToggleLapViews.Name = "btnToggleLapViews";
            this.btnToggleLapViews.Size = new System.Drawing.Size(23, 22);
            this.btnToggleLapViews.Text = "Toggle Lap Views";
            this.btnToggleLapViews.Click += new System.EventHandler(this.btnToggleLapViews_Click);
            // 
            // TrackMapDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 422);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TrackMapDisplay";
            this.Text = "TrackMapDisplay";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLaps;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnFastestLap;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox lstLaps;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkHidenOutLaps;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnZoomImageIn;
        private System.Windows.Forms.ToolStripButton btnZoomImageOut;
        private System.Windows.Forms.ToolStripButton btnResetZoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnToggleLapViews;
    }
}