namespace iRacing.Telemetry.Graphing.Controls
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
            this.graphLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.graphYAxisPanel = new System.Windows.Forms.Panel();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvFieldList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWarning = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxFieldList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupSelectedSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphLayoutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctxFieldList.SuspendLayout();
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
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.Location = new System.Drawing.Point(150, 0);
            this.graphPanel.Margin = new System.Windows.Forms.Padding(0);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(455, 493);
            this.graphPanel.TabIndex = 0;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint);
            this.graphPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.columnHeader1,
            this.chWarning,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvFieldList.ContextMenuStrip = this.ctxFieldList;
            this.lvFieldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFieldList.FullRowSelect = true;
            this.lvFieldList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFieldList.HideSelection = false;
            this.lvFieldList.Location = new System.Drawing.Point(0, 0);
            this.lvFieldList.Name = "lvFieldList";
            this.lvFieldList.Size = new System.Drawing.Size(400, 509);
            this.lvFieldList.TabIndex = 0;
            this.lvFieldList.UseCompatibleStateImageBehavior = false;
            this.lvFieldList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Field";
            this.columnHeader1.Width = 125;
            // 
            // chWarning
            // 
            this.chWarning.Text = "";
            this.chWarning.Width = 20;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Lap Min";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lap Max";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Lap Avg";
            // 
            // ctxFieldList
            // 
            this.ctxFieldList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.groupSelectedSeriesToolStripMenuItem});
            this.ctxFieldList.Name = "ctxFieldList";
            this.ctxFieldList.Size = new System.Drawing.Size(188, 70);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.editToolStripMenuItem.Text = "Edit Series";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // groupSelectedSeriesToolStripMenuItem
            // 
            this.groupSelectedSeriesToolStripMenuItem.Name = "groupSelectedSeriesToolStripMenuItem";
            this.groupSelectedSeriesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.groupSelectedSeriesToolStripMenuItem.Text = "Group Selected Series";
            this.groupSelectedSeriesToolStripMenuItem.Click += new System.EventHandler(this.groupSelectedSeriesToolStripMenuItem_Click);
            // 
            // TelemetryLineGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TelemetryLineGraph";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(1041, 525);
            this.graphLayoutTable.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ctxFieldList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel graphLayoutTable;
        private System.Windows.Forms.Panel graphYAxisPanel;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvFieldList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ContextMenuStrip ctxFieldList;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader chWarning;
        private System.Windows.Forms.ToolStripMenuItem groupSelectedSeriesToolStripMenuItem;
    }
}
