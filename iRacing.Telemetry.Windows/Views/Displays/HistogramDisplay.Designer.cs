namespace iRacing.Telemetry.Windows.Views.Displays
{
    partial class HistogramDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistogramDisplay));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDecreaseResolution = new System.Windows.Forms.ToolStripButton();
            this.lblResolution = new System.Windows.Forms.ToolStripLabel();
            this.btnIncreaseResolution = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hstLF = new iRacing.Telemetry.Controls.HistogramGraph();
            this.hstRF = new iRacing.Telemetry.Controls.HistogramGraph();
            this.hstLR = new iRacing.Telemetry.Controls.HistogramGraph();
            this.hstRR = new iRacing.Telemetry.Controls.HistogramGraph();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDecreaseResolution,
            this.lblResolution,
            this.btnIncreaseResolution});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(805, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDecreaseResolution
            // 
            this.btnDecreaseResolution.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDecreaseResolution.Image = ((System.Drawing.Image)(resources.GetObject("btnDecreaseResolution.Image")));
            this.btnDecreaseResolution.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDecreaseResolution.Name = "btnDecreaseResolution";
            this.btnDecreaseResolution.Size = new System.Drawing.Size(75, 22);
            this.btnDecreaseResolution.Text = "- Resolution";
            this.btnDecreaseResolution.Click += new System.EventHandler(this.btnDecreaseResolution_Click);
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = false;
            this.lblResolution.BackColor = System.Drawing.SystemColors.Control;
            this.lblResolution.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblResolution.ForeColor = System.Drawing.Color.DimGray;
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(24, 22);
            this.lblResolution.Text = "8";
            // 
            // btnIncreaseResolution
            // 
            this.btnIncreaseResolution.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnIncreaseResolution.Image = ((System.Drawing.Image)(resources.GetObject("btnIncreaseResolution.Image")));
            this.btnIncreaseResolution.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIncreaseResolution.Name = "btnIncreaseResolution";
            this.btnIncreaseResolution.Size = new System.Drawing.Size(78, 22);
            this.btnIncreaseResolution.Text = "+ Resolution";
            this.btnIncreaseResolution.Click += new System.EventHandler(this.btnIncreaseResolution_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.hstLF, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.hstRF, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.hstLR, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.hstRR, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 27);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(805, 474);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // hstLF
            // 
            this.hstLF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hstLF.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.hstLF.Corner = iRacing.Telemetry.Controls.Models.HistogramCorners.LF;
            this.hstLF.Location = new System.Drawing.Point(2, 2);
            this.hstLF.Margin = new System.Windows.Forms.Padding(1);
            this.hstLF.Model = null;
            this.hstLF.Name = "hstLF";
            this.hstLF.Size = new System.Drawing.Size(399, 234);
            this.hstLF.TabIndex = 0;
            // 
            // hstRF
            // 
            this.hstRF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hstRF.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.hstRF.Corner = iRacing.Telemetry.Controls.Models.HistogramCorners.RF;
            this.hstRF.Location = new System.Drawing.Point(403, 2);
            this.hstRF.Margin = new System.Windows.Forms.Padding(1);
            this.hstRF.Model = null;
            this.hstRF.Name = "hstRF";
            this.hstRF.Size = new System.Drawing.Size(400, 234);
            this.hstRF.TabIndex = 1;
            // 
            // hstLR
            // 
            this.hstLR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hstLR.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.hstLR.Corner = iRacing.Telemetry.Controls.Models.HistogramCorners.LR;
            this.hstLR.Location = new System.Drawing.Point(2, 238);
            this.hstLR.Margin = new System.Windows.Forms.Padding(1);
            this.hstLR.Model = null;
            this.hstLR.Name = "hstLR";
            this.hstLR.Size = new System.Drawing.Size(399, 234);
            this.hstLR.TabIndex = 2;
            // 
            // hstRR
            // 
            this.hstRR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hstRR.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.hstRR.Corner = iRacing.Telemetry.Controls.Models.HistogramCorners.RR;
            this.hstRR.Location = new System.Drawing.Point(403, 238);
            this.hstRR.Margin = new System.Windows.Forms.Padding(1);
            this.hstRR.Model = null;
            this.hstRR.Name = "hstRR";
            this.hstRR.Size = new System.Drawing.Size(400, 234);
            this.hstRR.TabIndex = 3;
            // 
            // HistogramDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(809, 503);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HistogramDisplay";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "HistogramDisplay";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.HistogramGraph hstLF;
        private Controls.HistogramGraph hstRF;
        private Controls.HistogramGraph hstLR;
        private Controls.HistogramGraph hstRR;
        private System.Windows.Forms.ToolStripButton btnDecreaseResolution;
        private System.Windows.Forms.ToolStripLabel lblResolution;
        private System.Windows.Forms.ToolStripButton btnIncreaseResolution;
    }
}