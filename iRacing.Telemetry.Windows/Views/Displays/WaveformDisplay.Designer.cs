using iRacing.Telemetry.Controls;

namespace iRacing.Telemetry.Windows.Views.Displays
{
    partial class WaveformDisplay
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
            iRacing.Telemetry.Controls.Models.LineGraphModel lineGraphModel1 = new iRacing.Telemetry.Controls.Models.LineGraphModel();
            iRacing.Telemetry.Controls.Models.LineGraphDataModel lineGraphDataModel1 = new iRacing.Telemetry.Controls.Models.LineGraphDataModel();
            this.waveformDisplayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editSelectedSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedMarginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seriesGroupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.summaryColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._graph = new iRacing.Telemetry.Controls.TelemetryLineGraph();
            this.waveformDisplayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // waveformDisplayContextMenu
            // 
            this.waveformDisplayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSelectedSeriesToolStripMenuItem,
            this.editFieldsToolStripMenuItem,
            this.editSelectedMarginsToolStripMenuItem,
            this.seriesGroupingToolStripMenuItem,
            this.toolStripMenuItem1,
            this.summaryColumnsToolStripMenuItem});
            this.waveformDisplayContextMenu.Name = "waveformDisplayContextMenu";
            this.waveformDisplayContextMenu.Size = new System.Drawing.Size(188, 142);
            // 
            // editSelectedSeriesToolStripMenuItem
            // 
            this.editSelectedSeriesToolStripMenuItem.Enabled = false;
            this.editSelectedSeriesToolStripMenuItem.Name = "editSelectedSeriesToolStripMenuItem";
            this.editSelectedSeriesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.editSelectedSeriesToolStripMenuItem.Text = "Edit Selected Series";
            this.editSelectedSeriesToolStripMenuItem.Click += new System.EventHandler(this.editSelectedSeriesToolStripMenuItem_Click);
            // 
            // editFieldsToolStripMenuItem
            // 
            this.editFieldsToolStripMenuItem.Name = "editFieldsToolStripMenuItem";
            this.editFieldsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.editFieldsToolStripMenuItem.Text = "Add/Remove Series";
            this.editFieldsToolStripMenuItem.Click += new System.EventHandler(this.addRemoveSeriesToolStripMenuItem_Click);
            // 
            // editSelectedMarginsToolStripMenuItem
            // 
            this.editSelectedMarginsToolStripMenuItem.Enabled = false;
            this.editSelectedMarginsToolStripMenuItem.Name = "editSelectedMarginsToolStripMenuItem";
            this.editSelectedMarginsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.editSelectedMarginsToolStripMenuItem.Text = "Edit Selected Margins";
            this.editSelectedMarginsToolStripMenuItem.Click += new System.EventHandler(this.editSelectedMarginsToolStripMenuItem_Click);
            // 
            // seriesGroupingToolStripMenuItem
            // 
            this.seriesGroupingToolStripMenuItem.Enabled = false;
            this.seriesGroupingToolStripMenuItem.Name = "seriesGroupingToolStripMenuItem";
            this.seriesGroupingToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.seriesGroupingToolStripMenuItem.Text = "Group Selected Series";
            this.seriesGroupingToolStripMenuItem.Click += new System.EventHandler(this.seriesGroupingToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 6);
            // 
            // summaryColumnsToolStripMenuItem
            // 
            this.summaryColumnsToolStripMenuItem.Name = "summaryColumnsToolStripMenuItem";
            this.summaryColumnsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.summaryColumnsToolStripMenuItem.Text = "Summary Columns";
            this.summaryColumnsToolStripMenuItem.Click += new System.EventHandler(this.summaryColumnsToolStripMenuItem_Click);
            // 
            // _graph
            // 
            this._graph.CanShowGroupingMenu = false;
            this._graph.CanShowMarginsEditorMenu = false;
            this._graph.CanShowSeriesEditorMenu = false;
            this._graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this._graph.Location = new System.Drawing.Point(0, 0);
            this._graph.Name = "_graph";
            this._graph.Padding = new System.Windows.Forms.Padding(8);
            this._graph.Size = new System.Drawing.Size(541, 450);
            this._graph.TabIndex = 1;
            this._graph.TelemetryData = lineGraphDataModel1;
            // 
            // WaveformDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 450);
            this.ContextMenuStrip = this.waveformDisplayContextMenu;
            this.Controls.Add(this._graph);
            this.KeyPreview = true;
            this.Name = "WaveformDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Waveform";
            this.waveformDisplayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip waveformDisplayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editFieldsToolStripMenuItem;
        private TelemetryLineGraph _graph;
        private System.Windows.Forms.ToolStripMenuItem seriesGroupingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summaryColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectedSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editSelectedMarginsToolStripMenuItem;
    }
}