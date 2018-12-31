using System.Windows.Forms;

namespace iRacing.Telemetry.TestApp
{
    partial class TelemetryTestForm : Form
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
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("col0");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn2 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("col1");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelemetryTestForm));
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTrackName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVehicleName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSessionTypeName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAirTemp = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTrackTemp = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTrackState = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTimeOfDay = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWeather = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFieldListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lapTimesDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineGraphDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsMainToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnLapBack = new System.Windows.Forms.ToolStripButton();
            this.btnFrameBack = new System.Windows.Forms.ToolStripButton();
            this.btnFrameForward = new System.Windows.Forms.ToolStripButton();
            this.btnLapForward = new System.Windows.Forms.ToolStripButton();
            this.tslLap = new System.Windows.Forms.ToolStripLabel();
            this.tslFrame = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslMinLaps = new System.Windows.Forms.ToolStripLabel();
            this.tslMaxLaps = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripInfo = new System.Windows.Forms.ToolStrip();
            this.lblProject = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblSession = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblSetupName = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.mnuMainMenu.SuspendLayout();
            this.tlsMainToolStrip.SuspendLayout();
            this.toolStripInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraDataSource1
            // 
            ultraDataColumn1.DataType = typeof(int);
            ultraDataColumn2.DataType = typeof(int);
            this.ultraDataSource1.Band.Columns.AddRange(new object[] {
            ultraDataColumn1,
            ultraDataColumn2});
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTrackName,
            this.lblVehicleName,
            this.lblSessionTypeName,
            this.lblAirTemp,
            this.lblTrackTemp,
            this.lblTrackState,
            this.lblTimeOfDay,
            this.lblWeather});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1221, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTrackName
            // 
            this.lblTrackName.AutoSize = false;
            this.lblTrackName.Name = "lblTrackName";
            this.lblTrackName.Size = new System.Drawing.Size(250, 17);
            this.lblTrackName.Text = "[track name]";
            this.lblTrackName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVehicleName
            // 
            this.lblVehicleName.AutoSize = false;
            this.lblVehicleName.Name = "lblVehicleName";
            this.lblVehicleName.Size = new System.Drawing.Size(250, 17);
            this.lblVehicleName.Text = "[vehicle name]";
            this.lblVehicleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSessionTypeName
            // 
            this.lblSessionTypeName.AutoSize = false;
            this.lblSessionTypeName.Name = "lblSessionTypeName";
            this.lblSessionTypeName.Size = new System.Drawing.Size(150, 17);
            this.lblSessionTypeName.Text = "[session type]";
            this.lblSessionTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAirTemp
            // 
            this.lblAirTemp.AutoSize = false;
            this.lblAirTemp.Name = "lblAirTemp";
            this.lblAirTemp.Size = new System.Drawing.Size(125, 17);
            this.lblAirTemp.Text = "[air temp]";
            this.lblAirTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrackTemp
            // 
            this.lblTrackTemp.AutoSize = false;
            this.lblTrackTemp.BackColor = System.Drawing.Color.White;
            this.lblTrackTemp.Name = "lblTrackTemp";
            this.lblTrackTemp.Size = new System.Drawing.Size(125, 17);
            this.lblTrackTemp.Text = "[track temp]";
            this.lblTrackTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrackState
            // 
            this.lblTrackState.AutoSize = false;
            this.lblTrackState.Name = "lblTrackState";
            this.lblTrackState.Size = new System.Drawing.Size(200, 17);
            this.lblTrackState.Text = "[track state]";
            this.lblTrackState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimeOfDay
            // 
            this.lblTimeOfDay.AutoSize = false;
            this.lblTimeOfDay.Name = "lblTimeOfDay";
            this.lblTimeOfDay.Size = new System.Drawing.Size(1, 17);
            this.lblTimeOfDay.Text = "[time of day]";
            this.lblTimeOfDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = false;
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(256, 17);
            this.lblWeather.Text = "[weather]";
            this.lblWeather.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sessionToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.MdiWindowListItem = this.windowToolStripMenuItem;
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(1221, 24);
            this.mnuMainMenu.TabIndex = 5;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.closeProjectToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveProjectToolStripMenuItem,
            this.saveProjectAsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newProjectToolStripMenuItem.Text = "&New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openProjectToolStripMenuItem.Text = "&Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // closeProjectToolStripMenuItem
            // 
            this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
            this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.closeProjectToolStripMenuItem.Text = "&Close Project";
            this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveProjectToolStripMenuItem.Text = "&Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // saveProjectAsToolStripMenuItem
            // 
            this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            this.saveProjectAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveProjectAsToolStripMenuItem.Text = "Save Project &As...";
            this.saveProjectAsToolStripMenuItem.Click += new System.EventHandler(this.saveProjectAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.closeToolStripMenuItem1,
            this.toolStripMenuItem4,
            this.saveFieldListToolStripMenuItem});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.sessionToolStripMenuItem.Text = "&Session";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.openToolStripMenuItem1.Text = "&Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Enabled = false;
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.closeToolStripMenuItem1.Text = "&Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(144, 6);
            // 
            // saveFieldListToolStripMenuItem
            // 
            this.saveFieldListToolStripMenuItem.Name = "saveFieldListToolStripMenuItem";
            this.saveFieldListToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveFieldListToolStripMenuItem.Text = "Save Field List";
            this.saveFieldListToolStripMenuItem.Click += new System.EventHandler(this.saveFieldListToolStripMenuItem_Click);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.displayToolStripMenuItem.Text = "&Display";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lapTimesDisplayToolStripMenuItem,
            this.lineGraphDisplayToolStripMenuItem});
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem1.Text = "New...";
            // 
            // lapTimesDisplayToolStripMenuItem
            // 
            this.lapTimesDisplayToolStripMenuItem.Name = "lapTimesDisplayToolStripMenuItem";
            this.lapTimesDisplayToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.lapTimesDisplayToolStripMenuItem.Text = "Lap Times Display";
            this.lapTimesDisplayToolStripMenuItem.Click += new System.EventHandler(this.lapTimesDisplayToolStripMenuItem_Click);
            // 
            // lineGraphDisplayToolStripMenuItem
            // 
            this.lineGraphDisplayToolStripMenuItem.Name = "lineGraphDisplayToolStripMenuItem";
            this.lineGraphDisplayToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.lineGraphDisplayToolStripMenuItem.Text = "Line Graph Display";
            this.lineGraphDisplayToolStripMenuItem.Click += new System.EventHandler(this.lineGraphDisplayToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileHorizontallyToolStripMenuItem,
            this.tileVerticallyToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem,
            this.toolStripMenuItem2});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // tileHorizontallyToolStripMenuItem
            // 
            this.tileHorizontallyToolStripMenuItem.Name = "tileHorizontallyToolStripMenuItem";
            this.tileHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileHorizontallyToolStripMenuItem.Text = "Tile Horizontally";
            this.tileHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontallyToolStripMenuItem_Click);
            // 
            // tileVerticallyToolStripMenuItem
            // 
            this.tileVerticallyToolStripMenuItem.Name = "tileVerticallyToolStripMenuItem";
            this.tileVerticallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileVerticallyToolStripMenuItem.Text = "Tile Vertically";
            this.tileVerticallyToolStripMenuItem.Click += new System.EventHandler(this.tileVerticallyToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.arrangeIconsToolStripMenuItem.Text = "Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.arrangeIconsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 6);
            // 
            // tlsMainToolStrip
            // 
            this.tlsMainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLapBack,
            this.btnFrameBack,
            this.btnFrameForward,
            this.btnLapForward,
            this.tslLap,
            this.tslFrame,
            this.toolStripSeparator1,
            this.tslMinLaps,
            this.tslMaxLaps,
            this.toolStripSeparator2});
            this.tlsMainToolStrip.Location = new System.Drawing.Point(0, 49);
            this.tlsMainToolStrip.Name = "tlsMainToolStrip";
            this.tlsMainToolStrip.Size = new System.Drawing.Size(1221, 25);
            this.tlsMainToolStrip.TabIndex = 7;
            this.tlsMainToolStrip.Text = "toolStrip1";
            // 
            // btnLapBack
            // 
            this.btnLapBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLapBack.Image = ((System.Drawing.Image)(resources.GetObject("btnLapBack.Image")));
            this.btnLapBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLapBack.Name = "btnLapBack";
            this.btnLapBack.Size = new System.Drawing.Size(32, 22);
            this.btnLapBack.Text = "<<-";
            this.btnLapBack.Click += new System.EventHandler(this.btnLapBack_Click);
            // 
            // btnFrameBack
            // 
            this.btnFrameBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFrameBack.Image = ((System.Drawing.Image)(resources.GetObject("btnFrameBack.Image")));
            this.btnFrameBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFrameBack.Name = "btnFrameBack";
            this.btnFrameBack.Size = new System.Drawing.Size(24, 22);
            this.btnFrameBack.Text = "<-";
            this.btnFrameBack.Click += new System.EventHandler(this.btnFrameBack_Click);
            // 
            // btnFrameForward
            // 
            this.btnFrameForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFrameForward.Image = ((System.Drawing.Image)(resources.GetObject("btnFrameForward.Image")));
            this.btnFrameForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFrameForward.Name = "btnFrameForward";
            this.btnFrameForward.Size = new System.Drawing.Size(24, 22);
            this.btnFrameForward.Text = "->";
            this.btnFrameForward.Click += new System.EventHandler(this.btnFrameForward_Click);
            // 
            // btnLapForward
            // 
            this.btnLapForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLapForward.Image = ((System.Drawing.Image)(resources.GetObject("btnLapForward.Image")));
            this.btnLapForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLapForward.Name = "btnLapForward";
            this.btnLapForward.Size = new System.Drawing.Size(32, 22);
            this.btnLapForward.Text = "->>";
            this.btnLapForward.Click += new System.EventHandler(this.btnLapForward_Click);
            // 
            // tslLap
            // 
            this.tslLap.Name = "tslLap";
            this.tslLap.Size = new System.Drawing.Size(30, 22);
            this.tslLap.Text = "lap#";
            // 
            // tslFrame
            // 
            this.tslFrame.Name = "tslFrame";
            this.tslFrame.Size = new System.Drawing.Size(45, 22);
            this.tslFrame.Text = "frame#";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslMinLaps
            // 
            this.tslMinLaps.Name = "tslMinLaps";
            this.tslMinLaps.Size = new System.Drawing.Size(52, 22);
            this.tslMinLaps.Text = "min laps";
            // 
            // tslMaxLaps
            // 
            this.tslMaxLaps.Name = "tslMaxLaps";
            this.tslMaxLaps.Size = new System.Drawing.Size(53, 22);
            this.tslMaxLaps.Text = "max laps";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripInfo
            // 
            this.toolStripInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProject,
            this.toolStripSeparator4,
            this.lblSession,
            this.toolStripSeparator3,
            this.lblSetupName});
            this.toolStripInfo.Location = new System.Drawing.Point(0, 24);
            this.toolStripInfo.Name = "toolStripInfo";
            this.toolStripInfo.Size = new System.Drawing.Size(1221, 25);
            this.toolStripInfo.TabIndex = 9;
            this.toolStripInfo.Text = "toolStrip2";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = false;
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(300, 22);
            this.lblProject.Text = "[project]";
            this.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = false;
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(300, 22);
            this.lblSession.Text = "[session]";
            this.lblSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblSetupName
            // 
            this.lblSetupName.AutoSize = false;
            this.lblSetupName.Name = "lblSetupName";
            this.lblSetupName.Size = new System.Drawing.Size(300, 22);
            this.lblSetupName.Text = "[setup name]";
            this.lblSetupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TelemetryTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tlsMainToolStrip);
            this.Controls.Add(this.toolStripInfo);
            this.Controls.Add(this.mnuMainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMainMenu;
            this.Name = "TelemetryTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telemetry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelemetryTestForm_FormClosing);
            this.Load += new System.EventHandler(this.TelemetryTestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.tlsMainToolStrip.ResumeLayout(false);
            this.tlsMainToolStrip.PerformLayout();
            this.toolStripInfo.ResumeLayout(false);
            this.toolStripInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTrackName;
        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel lblVehicleName;
        private System.Windows.Forms.ToolStripStatusLabel lblSessionTypeName;
        private System.Windows.Forms.ToolStripStatusLabel lblTrackState;
        private System.Windows.Forms.ToolStripStatusLabel lblTimeOfDay;
        private System.Windows.Forms.ToolStripStatusLabel lblWeather;
        private System.Windows.Forms.ToolStripStatusLabel lblAirTemp;
        private System.Windows.Forms.ToolStripStatusLabel lblTrackTemp;
        private System.Windows.Forms.ToolStrip tlsMainToolStrip;
        private System.Windows.Forms.ToolStripButton btnLapBack;
        private System.Windows.Forms.ToolStripButton btnFrameBack;
        private System.Windows.Forms.ToolStripButton btnFrameForward;
        private System.Windows.Forms.ToolStripButton btnLapForward;
        private System.Windows.Forms.ToolStripLabel tslLap;
        private System.Windows.Forms.ToolStripLabel tslFrame;
        private System.Windows.Forms.ToolStripLabel tslMaxLaps;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslMinLaps;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lapTimesDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineGraphDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStrip toolStripInfo;
        private System.Windows.Forms.ToolStripLabel lblProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblSession;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblSetupName;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem saveFieldListToolStripMenuItem;
    }
}

