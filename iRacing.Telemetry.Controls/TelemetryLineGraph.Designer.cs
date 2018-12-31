namespace iRacing.Telemetry.Controls
{
    partial class TelemetryLineGraph
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelemetryLineGraph));
            this.graphLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.graphYAxisPanel = new System.Windows.Forms.Panel();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvFieldList = new System.Windows.Forms.ListView();
            this.chField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLapMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLapMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLapAvg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLapStdDev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSessionMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSessionMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSessionAvg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSessionStdDev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgFieldsList = new System.Windows.Forms.ImageList(this.components);
            this.graphLayoutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphLayoutTable
            // 
            this.graphLayoutTable.BackColor = System.Drawing.Color.Black;
            this.graphLayoutTable.ColumnCount = 2;
            this.graphLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.graphLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.graphLayoutTable.Controls.Add(this.graphYAxisPanel, 0, 0);
            this.graphLayoutTable.Controls.Add(this.graphPanel, 1, 0);
            this.graphLayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphLayoutTable.Location = new System.Drawing.Point(8, 8);
            this.graphLayoutTable.Margin = new System.Windows.Forms.Padding(0);
            this.graphLayoutTable.Name = "graphLayoutTable";
            this.graphLayoutTable.RowCount = 1;
            this.graphLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.graphLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 493F));
            this.graphLayoutTable.Size = new System.Drawing.Size(605, 493);
            this.graphLayoutTable.TabIndex = 0;
            // 
            // graphYAxisPanel
            // 
            this.graphYAxisPanel.BackColor = System.Drawing.Color.Black;
            this.graphYAxisPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphYAxisPanel.Location = new System.Drawing.Point(0, 0);
            this.graphYAxisPanel.Margin = new System.Windows.Forms.Padding(0);
            this.graphYAxisPanel.Name = "graphYAxisPanel";
            this.graphYAxisPanel.Size = new System.Drawing.Size(150, 493);
            this.graphYAxisPanel.TabIndex = 2;
            this.graphYAxisPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphYAxisPanel_Paint);
            // 
            // graphPanel
            // 
            this.graphPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.graphPanel.BackColor = System.Drawing.Color.Black;
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.Location = new System.Drawing.Point(150, 0);
            this.graphPanel.Margin = new System.Windows.Forms.Padding(0);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(455, 493);
            this.graphPanel.TabIndex = 0;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(8, 8);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvFieldList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.graphLayoutTable);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1025, 509);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 1;
            // 
            // lvFieldList
            // 
            this.lvFieldList.BackColor = System.Drawing.Color.Black;
            this.lvFieldList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chField,
            this.chValue,
            this.chLapMin,
            this.chLapMax,
            this.chLapAvg,
            this.chLapStdDev,
            this.chSessionMin,
            this.chSessionMax,
            this.chSessionAvg,
            this.chSessionStdDev});
            this.lvFieldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFieldList.FullRowSelect = true;
            this.lvFieldList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFieldList.HideSelection = false;
            this.lvFieldList.LargeImageList = this.imgFieldsList;
            this.lvFieldList.Location = new System.Drawing.Point(0, 0);
            this.lvFieldList.Name = "lvFieldList";
            this.lvFieldList.Size = new System.Drawing.Size(400, 509);
            this.lvFieldList.SmallImageList = this.imgFieldsList;
            this.lvFieldList.StateImageList = this.imgFieldsList;
            this.lvFieldList.TabIndex = 0;
            this.lvFieldList.UseCompatibleStateImageBehavior = false;
            this.lvFieldList.View = System.Windows.Forms.View.Details;
            this.lvFieldList.SelectedIndexChanged += new System.EventHandler(this.lvFieldList_SelectedIndexChanged);
            // 
            // chField
            // 
            this.chField.Text = "";
            this.chField.Width = 125;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            // 
            // chLapMin
            // 
            this.chLapMin.Text = "LMin";
            this.chLapMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chLapMax
            // 
            this.chLapMax.Text = "LMax";
            this.chLapMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chLapAvg
            // 
            this.chLapAvg.Text = "LAvg";
            this.chLapAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chLapStdDev
            // 
            this.chLapStdDev.Text = "LStdDev";
            this.chLapStdDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chSessionMin
            // 
            this.chSessionMin.Text = "SMin";
            this.chSessionMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chSessionMax
            // 
            this.chSessionMax.Text = "SMax";
            this.chSessionMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chSessionAvg
            // 
            this.chSessionAvg.Text = "SAvg";
            this.chSessionAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chSessionStdDev
            // 
            this.chSessionStdDev.Text = "SStdDev";
            this.chSessionStdDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // imgFieldsList
            // 
            this.imgFieldsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFieldsList.ImageStream")));
            this.imgFieldsList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgFieldsList.Images.SetKeyName(0, "TracePointDisabled_6597_32x.png");
            this.imgFieldsList.Images.SetKeyName(1, "TracePointEnabled_6596_32x.png");
            // 
            // TelemetryLineGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "TelemetryLineGraph";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(1041, 525);
            this.Load += new System.EventHandler(this.LineGraph_Load);
            this.SizeChanged += new System.EventHandler(this.TelemetryLineGraph_SizeChanged);
            this.graphLayoutTable.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel graphLayoutTable;
        private System.Windows.Forms.Panel graphYAxisPanel;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvFieldList;
        private System.Windows.Forms.ColumnHeader chField;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.ColumnHeader chLapMin;
        private System.Windows.Forms.ColumnHeader chLapMax;
        private System.Windows.Forms.ColumnHeader chLapAvg;
        private System.Windows.Forms.ColumnHeader chLapStdDev;
        private System.Windows.Forms.ColumnHeader chSessionMin;
        private System.Windows.Forms.ColumnHeader chSessionMax;
        private System.Windows.Forms.ColumnHeader chSessionAvg;
        private System.Windows.Forms.ColumnHeader chSessionStdDev;
        private System.Windows.Forms.ImageList imgFieldsList;
    }
}
