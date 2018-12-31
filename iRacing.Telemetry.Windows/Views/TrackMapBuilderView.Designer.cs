namespace iRacing.Telemetry.Windows.Views
{
    partial class TrackMapBuilderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackMapBuilderView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cboTrackMaps = new System.Windows.Forms.ToolStripComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstLaps = new System.Windows.Forms.CheckedListBox();
            this.v = new System.Windows.Forms.Panel();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.btnOpenTelemetryFile = new System.Windows.Forms.ToolStripButton();
            this.btnPrevLap = new System.Windows.Forms.ToolStripButton();
            this.btnNextLap = new System.Windows.Forms.ToolStripButton();
            this.btnZoomMapIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomMapOut = new System.Windows.Forms.ToolStripButton();
            this.btnDisplaySelectedLaps = new System.Windows.Forms.ToolStripButton();
            this.btnSaveImage = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lblLap = new System.Windows.Forms.Label();
            this.btnFastest = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.chkHideInOut = new System.Windows.Forms.CheckBox();
            this.btnZoomImageIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomImageOut = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.v.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(8, 512);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 42);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboTrackMaps,
            this.btnClose,
            this.toolStripSeparator4,
            this.btnOpenTelemetryFile,
            this.btnSaveImage,
            this.toolStripSeparator1,
            this.btnPrevLap,
            this.btnNextLap,
            this.toolStripSeparator2,
            this.btnZoomMapIn,
            this.btnZoomMapOut,
            this.toolStripSeparator5,
            this.btnDisplaySelectedLaps,
            this.toolStripSeparator3,
            this.btnZoomImageIn,
            this.btnZoomImageOut,
            this.toolStripSeparator8});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(8, 8);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(741, 23);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // cboTrackMaps
            // 
            this.cboTrackMaps.Name = "cboTrackMaps";
            this.cboTrackMaps.Size = new System.Drawing.Size(250, 23);
            this.cboTrackMaps.SelectedIndexChanged += new System.EventHandler(this.cboTrackMaps_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.picMap);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(8, 31);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(741, 481);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lstLaps);
            this.panel3.Controls.Add(this.v);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(8, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 465);
            this.panel3.TabIndex = 4;
            // 
            // lstLaps
            // 
            this.lstLaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLaps.FormattingEnabled = true;
            this.lstLaps.Location = new System.Drawing.Point(0, 75);
            this.lstLaps.Name = "lstLaps";
            this.lstLaps.Size = new System.Drawing.Size(200, 390);
            this.lstLaps.TabIndex = 3;
            this.lstLaps.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstLaps_ItemCheck);
            this.lstLaps.SelectedIndexChanged += new System.EventHandler(this.lstLaps_SelectedIndexChanged);
            // 
            // v
            // 
            this.v.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.v.Controls.Add(this.chkHideInOut);
            this.v.Controls.Add(this.btnSelectAll);
            this.v.Controls.Add(this.btnFastest);
            this.v.Controls.Add(this.lblLap);
            this.v.Controls.Add(this.btnClearAll);
            this.v.Dock = System.Windows.Forms.DockStyle.Top;
            this.v.Location = new System.Drawing.Point(0, 0);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(200, 75);
            this.v.TabIndex = 0;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(2, 24);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(56, 23);
            this.btnClearAll.TabIndex = 0;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // picMap
            // 
            this.picMap.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMap.Location = new System.Drawing.Point(208, 8);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(525, 465);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMap.TabIndex = 2;
            this.picMap.TabStop = false;
            // 
            // btnOpenTelemetryFile
            // 
            this.btnOpenTelemetryFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenTelemetryFile.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Open_6529;
            this.btnOpenTelemetryFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenTelemetryFile.Name = "btnOpenTelemetryFile";
            this.btnOpenTelemetryFile.Size = new System.Drawing.Size(23, 20);
            this.btnOpenTelemetryFile.Text = "Open Telemetry File";
            this.btnOpenTelemetryFile.Click += new System.EventHandler(this.btnOpenTelemetryFile_Click);
            // 
            // btnPrevLap
            // 
            this.btnPrevLap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevLap.Image = global::iRacing.Telemetry.Windows.Properties.Resources.DataContainer_MovePreviousHS;
            this.btnPrevLap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevLap.Name = "btnPrevLap";
            this.btnPrevLap.Size = new System.Drawing.Size(23, 20);
            this.btnPrevLap.Text = "<- Previous Lap";
            this.btnPrevLap.Click += new System.EventHandler(this.btnPrevLap_Click);
            // 
            // btnNextLap
            // 
            this.btnNextLap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNextLap.Image = global::iRacing.Telemetry.Windows.Properties.Resources.DataContainer_MoveNextHS;
            this.btnNextLap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNextLap.Name = "btnNextLap";
            this.btnNextLap.Size = new System.Drawing.Size(23, 20);
            this.btnNextLap.Text = "Next Lap ->";
            this.btnNextLap.Click += new System.EventHandler(this.btnNextLap_Click);
            // 
            // btnZoomMapIn
            // 
            this.btnZoomMapIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomMapIn.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Zoom_5442;
            this.btnZoomMapIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomMapIn.Name = "btnZoomMapIn";
            this.btnZoomMapIn.Size = new System.Drawing.Size(23, 20);
            this.btnZoomMapIn.Text = "Zoom Map In";
            this.btnZoomMapIn.Click += new System.EventHandler(this.btnZoomMapIn_Click);
            // 
            // btnZoomMapOut
            // 
            this.btnZoomMapOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomMapOut.Image = global::iRacing.Telemetry.Windows.Properties.Resources.ZoomOut_12927;
            this.btnZoomMapOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomMapOut.Name = "btnZoomMapOut";
            this.btnZoomMapOut.Size = new System.Drawing.Size(23, 20);
            this.btnZoomMapOut.Text = "Zoom Map Out";
            this.btnZoomMapOut.Click += new System.EventHandler(this.btnZoomMapOut_Click);
            // 
            // btnDisplaySelectedLaps
            // 
            this.btnDisplaySelectedLaps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDisplaySelectedLaps.Image = global::iRacing.Telemetry.Windows.Properties.Resources.StatusAnnotations_Play_32xMD_color;
            this.btnDisplaySelectedLaps.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisplaySelectedLaps.Name = "btnDisplaySelectedLaps";
            this.btnDisplaySelectedLaps.Size = new System.Drawing.Size(23, 20);
            this.btnDisplaySelectedLaps.Text = "Display Selected Laps";
            this.btnDisplaySelectedLaps.Click += new System.EventHandler(this.btnDisplaySelectedLaps_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveImage.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Save_6530;
            this.btnSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(23, 20);
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnClose
            // 
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::iRacing.Telemetry.Windows.Properties.Resources.CloseResults_8579;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 20);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLap
            // 
            this.lblLap.AutoSize = true;
            this.lblLap.Location = new System.Drawing.Point(3, 8);
            this.lblLap.Name = "lblLap";
            this.lblLap.Size = new System.Drawing.Size(55, 13);
            this.lblLap.TabIndex = 1;
            this.lblLap.Text = "Lap 0 of 0";
            // 
            // btnFastest
            // 
            this.btnFastest.Location = new System.Drawing.Point(64, 24);
            this.btnFastest.Name = "btnFastest";
            this.btnFastest.Size = new System.Drawing.Size(56, 23);
            this.btnFastest.TabIndex = 2;
            this.btnFastest.Text = "Fastest";
            this.btnFastest.UseVisualStyleBackColor = true;
            this.btnFastest.Click += new System.EventHandler(this.btnFastest_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(126, 24);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(68, 23);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "Check All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // chkHideInOut
            // 
            this.chkHideInOut.AutoSize = true;
            this.chkHideInOut.Checked = true;
            this.chkHideInOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHideInOut.Location = new System.Drawing.Point(6, 52);
            this.chkHideInOut.Name = "chkHideInOut";
            this.chkHideInOut.Size = new System.Drawing.Size(108, 17);
            this.chkHideInOut.TabIndex = 4;
            this.chkHideInOut.Text = "Hide In/Out Laps";
            this.chkHideInOut.UseVisualStyleBackColor = true;
            this.chkHideInOut.CheckedChanged += new System.EventHandler(this.chkHideInOut_CheckedChanged);
            // 
            // btnZoomImageIn
            // 
            this.btnZoomImageIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnZoomImageIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomImageIn.Image")));
            this.btnZoomImageIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomImageIn.Name = "btnZoomImageIn";
            this.btnZoomImageIn.Size = new System.Drawing.Size(92, 19);
            this.btnZoomImageIn.Text = "Zoom Image In";
            this.btnZoomImageIn.Click += new System.EventHandler(this.btnZoomImageIn_Click);
            // 
            // btnZoomImageOut
            // 
            this.btnZoomImageOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnZoomImageOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomImageOut.Image")));
            this.btnZoomImageOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomImageOut.Name = "btnZoomImageOut";
            this.btnZoomImageOut.Size = new System.Drawing.Size(102, 19);
            this.btnZoomImageOut.Text = "Zoom Image Out";
            this.btnZoomImageOut.Click += new System.EventHandler(this.btnZoomImageOut_Click);
            // 
            // TrackMapBuilderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrackMapBuilderView";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Track Map Builder";
            this.Load += new System.EventHandler(this.TrackMapBuilderView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.v.ResumeLayout(false);
            this.v.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOpenTelemetryFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrevLap;
        private System.Windows.Forms.ToolStripButton btnNextLap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton btnZoomMapIn;
        private System.Windows.Forms.ToolStripButton btnZoomMapOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.ToolStripButton btnSaveImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.CheckedListBox lstLaps;
        private System.Windows.Forms.ToolStripButton btnDisplaySelectedLaps;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel v;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.ToolStripComboBox cboTrackMaps;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Button btnFastest;
        private System.Windows.Forms.Label lblLap;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.CheckBox chkHideInOut;
        private System.Windows.Forms.ToolStripButton btnZoomImageIn;
        private System.Windows.Forms.ToolStripButton btnZoomImageOut;
    }
}