using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Views
{
    public partial class MdiParentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiParentForm));
            this.mnuMainViewMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveDisplayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldDefinitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackMapBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.loadSavedSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lapTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waveformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.saveDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsMainViewToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNewProject = new System.Windows.Forms.ToolStripButton();
            this.btnOpenProject = new System.Windows.Forms.ToolStripButton();
            this.btnCloseProject = new System.Windows.Forms.ToolStripButton();
            this.btnSaveProject = new System.Windows.Forms.ToolStripButton();
            this.btnSaveProjectAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenSession = new System.Windows.Forms.ToolStripButton();
            this.btnCloseSession = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewLapTimesDisplay = new System.Windows.Forms.ToolStripButton();
            this.btnNewWaveformDisplay = new System.Windows.Forms.ToolStripButton();
            this.btnNewHistogramDisplay = new System.Windows.Forms.ToolStripButton();
            this.btnNewTrackMapDisplay = new System.Windows.Forms.ToolStripButton();
            this.btnSetupDisplay = new System.Windows.Forms.ToolStripButton();
            this.btnSessionDetailsDisplay = new System.Windows.Forms.ToolStripButton();
            this.btnSaveDisplay = new System.Windows.Forms.ToolStripButton();
            this.btnOpenDisplay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFieldDefinitions = new System.Windows.Forms.ToolStripButton();
            this.btnFunctionEditor = new System.Windows.Forms.ToolStripButton();
            this.btnTrackMapBuilder = new System.Windows.Forms.ToolStripButton();
            this.btnOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCascade = new System.Windows.Forms.ToolStripButton();
            this.btnTileHorizontally = new System.Windows.Forms.ToolStripButton();
            this.btnTileVertically = new System.Windows.Forms.ToolStripButton();
            this.btnArrangeIcons = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.staMainViewStatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblProjectName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSession = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSetup = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVehicle = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTrack = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsSessionToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnFirstLap = new System.Windows.Forms.ToolStripButton();
            this.btnPreviousLap = new System.Windows.Forms.ToolStripButton();
            this.lblSessionLaps = new System.Windows.Forms.ToolStripLabel();
            this.btnNextLap = new System.Windows.Forms.ToolStripButton();
            this.btnLastLap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFastestLap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnResetZoom = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMainViewMenu.SuspendLayout();
            this.tlsMainViewToolStrip.SuspendLayout();
            this.staMainViewStatusStrip.SuspendLayout();
            this.tlsSessionToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMainViewMenu
            // 
            this.mnuMainViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.sessionToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.mnuMainViewMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainViewMenu.MdiWindowListItem = this.windowToolStripMenuItem;
            this.mnuMainViewMenu.Name = "mnuMainViewMenu";
            this.mnuMainViewMenu.Size = new System.Drawing.Size(1310, 24);
            this.mnuMainViewMenu.TabIndex = 0;
            this.mnuMainViewMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.closeProjectToolStripMenuItem,
            this.toolStripMenuItem3,
            this.saveProjectToolStripMenuItem,
            this.saveProjectAsToolStripMenuItem,
            this.toolStripMenuItem4,
            this.saveDisplayToolStripMenuItem1,
            this.loadDisplayToolStripMenuItem,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources._077_AddFile_24x24_72;
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newProjectToolStripMenuItem.Text = "&New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Open_6529;
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openProjectToolStripMenuItem.Text = "&Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // closeProjectToolStripMenuItem
            // 
            this.closeProjectToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Close_65191;
            this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
            this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeProjectToolStripMenuItem.Text = "&Close Project";
            this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Save_6530;
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveProjectToolStripMenuItem.Text = "&Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // saveProjectAsToolStripMenuItem
            // 
            this.saveProjectAsToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.SaveFileDialogControl_703;
            this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            this.saveProjectAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveProjectAsToolStripMenuItem.Text = "Save Project &As...";
            this.saveProjectAsToolStripMenuItem.Click += new System.EventHandler(this.saveProjectAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(177, 6);
            // 
            // saveDisplayToolStripMenuItem1
            // 
            this.saveDisplayToolStripMenuItem1.Name = "saveDisplayToolStripMenuItem1";
            this.saveDisplayToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.saveDisplayToolStripMenuItem1.Text = "Save Display";
            this.saveDisplayToolStripMenuItem1.Click += new System.EventHandler(this.saveDisplayToolStripMenuItem1_Click);
            // 
            // loadDisplayToolStripMenuItem
            // 
            this.loadDisplayToolStripMenuItem.Name = "loadDisplayToolStripMenuItem";
            this.loadDisplayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadDisplayToolStripMenuItem.Text = "Open Display";
            this.loadDisplayToolStripMenuItem.Click += new System.EventHandler(this.loadDisplayToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Cut_6523;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Copy_6524;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Paste_6520;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Clearallrequests_8816;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fieldDefinitionsToolStripMenuItem,
            this.functionEditorToolStripMenuItem,
            this.trackMapBuilderToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // fieldDefinitionsToolStripMenuItem
            // 
            this.fieldDefinitionsToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.FieldsHeader_16x;
            this.fieldDefinitionsToolStripMenuItem.Name = "fieldDefinitionsToolStripMenuItem";
            this.fieldDefinitionsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.fieldDefinitionsToolStripMenuItem.Text = "&Field Definitions";
            this.fieldDefinitionsToolStripMenuItem.Click += new System.EventHandler(this.fieldDefinitionsItem_Click);
            // 
            // functionEditorToolStripMenuItem
            // 
            this.functionEditorToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Function_32;
            this.functionEditorToolStripMenuItem.Name = "functionEditorToolStripMenuItem";
            this.functionEditorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.functionEditorToolStripMenuItem.Text = "Function Editor";
            this.functionEditorToolStripMenuItem.Click += new System.EventHandler(this.functionEditorItem_Click);
            // 
            // trackMapBuilderToolStripMenuItem
            // 
            this.trackMapBuilderToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.EllipseElement_10707;
            this.trackMapBuilderToolStripMenuItem.Name = "trackMapBuilderToolStripMenuItem";
            this.trackMapBuilderToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.trackMapBuilderToolStripMenuItem.Text = "Track Map Builder";
            this.trackMapBuilderToolStripMenuItem.Click += new System.EventHandler(this.trackMapBuilderItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.ProcessWindow_6545_32;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsItem_Click);
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeSessionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveSessionToolStripMenuItem,
            this.toolStripMenuItem5,
            this.loadSavedSessionToolStripMenuItem,
            this.toolStripMenuItem11});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.sessionToolStripMenuItem.Text = "&Session";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.OpenFileDialog_692;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "&Open Session";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeSessionToolStripMenuItem
            // 
            this.closeSessionToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.CloseResults_8579;
            this.closeSessionToolStripMenuItem.Name = "closeSessionToolStripMenuItem";
            this.closeSessionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeSessionToolStripMenuItem.Text = "&Close Session";
            this.closeSessionToolStripMenuItem.Click += new System.EventHandler(this.closeSessionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveSessionToolStripMenuItem
            // 
            this.saveSessionToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.SaveSelection_5630;
            this.saveSessionToolStripMenuItem.Name = "saveSessionToolStripMenuItem";
            this.saveSessionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveSessionToolStripMenuItem.Text = "&Save Session";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(177, 6);
            // 
            // loadSavedSessionToolStripMenuItem
            // 
            this.loadSavedSessionToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.OpenFileDialog_692;
            this.loadSavedSessionToolStripMenuItem.Name = "loadSavedSessionToolStripMenuItem";
            this.loadSavedSessionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadSavedSessionToolStripMenuItem.Text = "&Load Saved Session";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(177, 6);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lapTimesToolStripMenuItem,
            this.waveformToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.trackMapToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.sessionDetailsToolStripMenuItem,
            this.toolStripMenuItem6,
            this.saveDisplayToolStripMenuItem,
            this.openDisplayToolStripMenuItem,
            this.toolStripMenuItem8});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.displayToolStripMenuItem.Text = "&Display";
            // 
            // lapTimesToolStripMenuItem
            // 
            this.lapTimesToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Timer_709;
            this.lapTimesToolStripMenuItem.Name = "lapTimesToolStripMenuItem";
            this.lapTimesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.lapTimesToolStripMenuItem.Text = "&Lap Times";
            this.lapTimesToolStripMenuItem.Click += new System.EventHandler(this.lapTimesToolStripMenuItem_Click);
            // 
            // waveformToolStripMenuItem
            // 
            this.waveformToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.StackedAreaSeries_12693;
            this.waveformToolStripMenuItem.Name = "waveformToolStripMenuItem";
            this.waveformToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.waveformToolStripMenuItem.Text = "&Waveform";
            this.waveformToolStripMenuItem.Click += new System.EventHandler(this.waveformToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.StackedColumnSeries_12695;
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.histogramToolStripMenuItem.Text = "&Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // trackMapToolStripMenuItem
            // 
            this.trackMapToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.MapTileLayer_16x;
            this.trackMapToolStripMenuItem.Name = "trackMapToolStripMenuItem";
            this.trackMapToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.trackMapToolStripMenuItem.Text = "Track &Map";
            this.trackMapToolStripMenuItem.Click += new System.EventHandler(this.trackMapToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.PropertyIcon;
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.setupToolStripMenuItem.Text = "&Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // sessionDetailsToolStripMenuItem
            // 
            this.sessionDetailsToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.asset_treeView_12x12_on;
            this.sessionDetailsToolStripMenuItem.Name = "sessionDetailsToolStripMenuItem";
            this.sessionDetailsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.sessionDetailsToolStripMenuItem.Text = "Session &Details";
            this.sessionDetailsToolStripMenuItem.Click += new System.EventHandler(this.sessionDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(150, 6);
            // 
            // saveDisplayToolStripMenuItem
            // 
            this.saveDisplayToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.SaveFormDesignHS;
            this.saveDisplayToolStripMenuItem.Name = "saveDisplayToolStripMenuItem";
            this.saveDisplayToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveDisplayToolStripMenuItem.Text = "Save Display";
            this.saveDisplayToolStripMenuItem.Click += new System.EventHandler(this.saveDisplayToolStripMenuItem_Click);
            // 
            // openDisplayToolStripMenuItem
            // 
            this.openDisplayToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.OpenSelectedItemHS;
            this.openDisplayToolStripMenuItem.Name = "openDisplayToolStripMenuItem";
            this.openDisplayToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.openDisplayToolStripMenuItem.Text = "Open Display...";
            this.openDisplayToolStripMenuItem.Click += new System.EventHandler(this.openDisplayToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(150, 6);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.cascadeToolStripMenuItem,
            this.tileHorizontallyToolStripMenuItem,
            this.tileVerticallyToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem,
            this.toolStripMenuItem7});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 6);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Query_16xLG;
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // tileHorizontallyToolStripMenuItem
            // 
            this.tileHorizontallyToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.SplitScreenHorizontally_12972;
            this.tileHorizontallyToolStripMenuItem.Name = "tileHorizontallyToolStripMenuItem";
            this.tileHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileHorizontallyToolStripMenuItem.Text = "Tile &Horizontally";
            this.tileHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontallyToolStripMenuItem_Click);
            // 
            // tileVerticallyToolStripMenuItem
            // 
            this.tileVerticallyToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.SplitScreenVertically_12973;
            this.tileVerticallyToolStripMenuItem.Name = "tileVerticallyToolStripMenuItem";
            this.tileVerticallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileVerticallyToolStripMenuItem.Text = "Tile &Vertically";
            this.tileVerticallyToolStripMenuItem.Click += new System.EventHandler(this.tileVerticallyToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Arrange_16xLG;
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.arrangeIconsToolStripMenuItem.Text = "Arrange &Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.arrangeIconsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(157, 6);
            // 
            // tlsMainViewToolStrip
            // 
            this.tlsMainViewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewProject,
            this.btnOpenProject,
            this.btnCloseProject,
            this.btnSaveProject,
            this.btnSaveProjectAs,
            this.toolStripSeparator4,
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnOpenSession,
            this.btnCloseSession,
            this.toolStripSeparator2,
            this.btnNewLapTimesDisplay,
            this.btnNewWaveformDisplay,
            this.btnNewHistogramDisplay,
            this.btnNewTrackMapDisplay,
            this.btnSetupDisplay,
            this.btnSessionDetailsDisplay,
            this.btnSaveDisplay,
            this.btnOpenDisplay,
            this.toolStripSeparator3,
            this.btnFieldDefinitions,
            this.btnFunctionEditor,
            this.btnTrackMapBuilder,
            this.btnOptions,
            this.toolStripSeparator9,
            this.btnCascade,
            this.btnTileHorizontally,
            this.btnTileVertically,
            this.btnArrangeIcons,
            this.toolStripSeparator5});
            this.tlsMainViewToolStrip.Location = new System.Drawing.Point(0, 24);
            this.tlsMainViewToolStrip.Name = "tlsMainViewToolStrip";
            this.tlsMainViewToolStrip.Size = new System.Drawing.Size(1310, 25);
            this.tlsMainViewToolStrip.TabIndex = 1;
            this.tlsMainViewToolStrip.Text = "toolStrip1";
            // 
            // btnNewProject
            // 
            this.btnNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewProject.Image = global::iRacing.Telemetry.Windows.Properties.Resources._077_AddFile_24x24_72;
            this.btnNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(23, 22);
            this.btnNewProject.Text = "New Project";
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenProject.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Open_6529;
            this.btnOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(23, 22);
            this.btnOpenProject.Text = "Open Project";
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // btnCloseProject
            // 
            this.btnCloseProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCloseProject.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Close_65191;
            this.btnCloseProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseProject.Name = "btnCloseProject";
            this.btnCloseProject.Size = new System.Drawing.Size(23, 22);
            this.btnCloseProject.Text = "Close Project";
            this.btnCloseProject.Click += new System.EventHandler(this.btnCloseProject_Click);
            // 
            // btnSaveProject
            // 
            this.btnSaveProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveProject.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Save_6530;
            this.btnSaveProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveProject.Name = "btnSaveProject";
            this.btnSaveProject.Size = new System.Drawing.Size(23, 22);
            this.btnSaveProject.Text = "Save Project";
            this.btnSaveProject.Click += new System.EventHandler(this.btnSaveProject_Click);
            // 
            // btnSaveProjectAs
            // 
            this.btnSaveProjectAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveProjectAs.Image = global::iRacing.Telemetry.Windows.Properties.Resources.SaveFileDialogControl_703;
            this.btnSaveProjectAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveProjectAs.Name = "btnSaveProjectAs";
            this.btnSaveProjectAs.Size = new System.Drawing.Size(23, 22);
            this.btnSaveProjectAs.Text = "Save Project As...";
            this.btnSaveProjectAs.Click += new System.EventHandler(this.btnSaveProjectAs_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCut
            // 
            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCut.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Cut_6523;
            this.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(23, 22);
            this.btnCut.Text = "Cut";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Copy_6524;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(23, 22);
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Paste_6520;
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(23, 22);
            this.btnPaste.Text = "Paste";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Clearallrequests_8816;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOpenSession
            // 
            this.btnOpenSession.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOpenSession.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenSession.Image = global::iRacing.Telemetry.Windows.Properties.Resources.OpenFileDialog_692;
            this.btnOpenSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenSession.Name = "btnOpenSession";
            this.btnOpenSession.Size = new System.Drawing.Size(23, 22);
            this.btnOpenSession.Text = "Open Session";
            this.btnOpenSession.Click += new System.EventHandler(this.btnOpenSession_Click);
            // 
            // btnCloseSession
            // 
            this.btnCloseSession.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCloseSession.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCloseSession.Image = global::iRacing.Telemetry.Windows.Properties.Resources.CloseResults_8579;
            this.btnCloseSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseSession.Name = "btnCloseSession";
            this.btnCloseSession.Size = new System.Drawing.Size(23, 22);
            this.btnCloseSession.Text = "Close Session";
            this.btnCloseSession.Click += new System.EventHandler(this.btnCloseSession_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNewLapTimesDisplay
            // 
            this.btnNewLapTimesDisplay.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnNewLapTimesDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewLapTimesDisplay.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Timer_709;
            this.btnNewLapTimesDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewLapTimesDisplay.Name = "btnNewLapTimesDisplay";
            this.btnNewLapTimesDisplay.Size = new System.Drawing.Size(23, 22);
            this.btnNewLapTimesDisplay.Text = "New Lap Times Display";
            this.btnNewLapTimesDisplay.Click += new System.EventHandler(this.btnNewLapTimesDisplay_Click);
            // 
            // btnNewWaveformDisplay
            // 
            this.btnNewWaveformDisplay.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnNewWaveformDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewWaveformDisplay.Image = global::iRacing.Telemetry.Windows.Properties.Resources.StackedAreaSeries_12693;
            this.btnNewWaveformDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewWaveformDisplay.Name = "btnNewWaveformDisplay";
            this.btnNewWaveformDisplay.Size = new System.Drawing.Size(23, 22);
            this.btnNewWaveformDisplay.Text = "New Waveform";
            this.btnNewWaveformDisplay.Click += new System.EventHandler(this.btnNewWaveformDisplay_Click);
            // 
            // btnNewHistogramDisplay
            // 
            this.btnNewHistogramDisplay.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnNewHistogramDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewHistogramDisplay.Image = global::iRacing.Telemetry.Windows.Properties.Resources.StackedColumnSeries_12695;
            this.btnNewHistogramDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewHistogramDisplay.Name = "btnNewHistogramDisplay";
            this.btnNewHistogramDisplay.Size = new System.Drawing.Size(23, 22);
            this.btnNewHistogramDisplay.Text = "New Histogram";
            this.btnNewHistogramDisplay.Click += new System.EventHandler(this.btnNewHistogramDisplay_Click);
            // 
            // btnNewTrackMapDisplay
            // 
            this.btnNewTrackMapDisplay.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnNewTrackMapDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewTrackMapDisplay.Image = global::iRacing.Telemetry.Windows.Properties.Resources.MapTileLayer_16x;
            this.btnNewTrackMapDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewTrackMapDisplay.Name = "btnNewTrackMapDisplay";
            this.btnNewTrackMapDisplay.Size = new System.Drawing.Size(23, 22);
            this.btnNewTrackMapDisplay.Text = "New Track Map";
            this.btnNewTrackMapDisplay.Click += new System.EventHandler(this.btnNewTrackMapDisplay_Click);
            // 
            // btnSetupDisplay
            // 
            this.btnSetupDisplay.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnSetupDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetupDisplay.Image = global::iRacing.Telemetry.Windows.Properties.Resources.PropertyIcon;
            this.btnSetupDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetupDisplay.Name = "btnSetupDisplay";
            this.btnSetupDisplay.Size = new System.Drawing.Size(23, 22);
            this.btnSetupDisplay.Text = "New Setup Display";
            this.btnSetupDisplay.Click += new System.EventHandler(this.btnSetupDisplay_Click);
            // 
            // btnSessionDetailsDisplay
            // 
            this.btnSessionDetailsDisplay.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnSessionDetailsDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSessionDetailsDisplay.Image = global::iRacing.Telemetry.Windows.Properties.Resources.asset_treeView_12x12_on;
            this.btnSessionDetailsDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSessionDetailsDisplay.Name = "btnSessionDetailsDisplay";
            this.btnSessionDetailsDisplay.Size = new System.Drawing.Size(23, 22);
            this.btnSessionDetailsDisplay.Text = "New Session Details";
            this.btnSessionDetailsDisplay.Click += new System.EventHandler(this.btnSessionDetailsDisplay_Click);
            // 
            // btnSaveDisplay
            // 
            this.btnSaveDisplay.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSaveDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveDisplay.Image = global::iRacing.Telemetry.Windows.Properties.Resources.SaveFormDesignHS;
            this.btnSaveDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveDisplay.Name = "btnSaveDisplay";
            this.btnSaveDisplay.Size = new System.Drawing.Size(23, 22);
            this.btnSaveDisplay.Text = "Save Display";
            this.btnSaveDisplay.Click += new System.EventHandler(this.btnSaveDisplay_Click);
            // 
            // btnOpenDisplay
            // 
            this.btnOpenDisplay.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnOpenDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenDisplay.Image = global::iRacing.Telemetry.Windows.Properties.Resources.OpenSelectedItemHS;
            this.btnOpenDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenDisplay.Name = "btnOpenDisplay";
            this.btnOpenDisplay.Size = new System.Drawing.Size(23, 22);
            this.btnOpenDisplay.Text = "Open Display...";
            this.btnOpenDisplay.Click += new System.EventHandler(this.btnOpenDisplay_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFieldDefinitions
            // 
            this.btnFieldDefinitions.BackColor = System.Drawing.SystemColors.Info;
            this.btnFieldDefinitions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFieldDefinitions.Image = global::iRacing.Telemetry.Windows.Properties.Resources.FieldsHeader_16x;
            this.btnFieldDefinitions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFieldDefinitions.Name = "btnFieldDefinitions";
            this.btnFieldDefinitions.Size = new System.Drawing.Size(23, 22);
            this.btnFieldDefinitions.Text = "Field Definitions";
            this.btnFieldDefinitions.Click += new System.EventHandler(this.fieldDefinitionsItem_Click);
            // 
            // btnFunctionEditor
            // 
            this.btnFunctionEditor.BackColor = System.Drawing.SystemColors.Info;
            this.btnFunctionEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFunctionEditor.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Function_32;
            this.btnFunctionEditor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFunctionEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFunctionEditor.Name = "btnFunctionEditor";
            this.btnFunctionEditor.Size = new System.Drawing.Size(23, 22);
            this.btnFunctionEditor.Text = "Function Editor";
            this.btnFunctionEditor.Click += new System.EventHandler(this.functionEditorItem_Click);
            // 
            // btnTrackMapBuilder
            // 
            this.btnTrackMapBuilder.BackColor = System.Drawing.SystemColors.Info;
            this.btnTrackMapBuilder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrackMapBuilder.Image = global::iRacing.Telemetry.Windows.Properties.Resources.EllipseElement_10707;
            this.btnTrackMapBuilder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrackMapBuilder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrackMapBuilder.Name = "btnTrackMapBuilder";
            this.btnTrackMapBuilder.Size = new System.Drawing.Size(23, 22);
            this.btnTrackMapBuilder.Text = "Track Map Builder";
            this.btnTrackMapBuilder.Click += new System.EventHandler(this.trackMapBuilderItem_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.BackColor = System.Drawing.SystemColors.Info;
            this.btnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOptions.Image = global::iRacing.Telemetry.Windows.Properties.Resources.ProcessWindow_6545_32;
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(23, 22);
            this.btnOptions.Text = "Options";
            this.btnOptions.Click += new System.EventHandler(this.optionsItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCascade
            // 
            this.btnCascade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCascade.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Query_16xLG;
            this.btnCascade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCascade.Name = "btnCascade";
            this.btnCascade.Size = new System.Drawing.Size(23, 22);
            this.btnCascade.Text = "Cascade";
            // 
            // btnTileHorizontally
            // 
            this.btnTileHorizontally.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTileHorizontally.Image = global::iRacing.Telemetry.Windows.Properties.Resources.SplitScreenHorizontally_12972;
            this.btnTileHorizontally.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTileHorizontally.Name = "btnTileHorizontally";
            this.btnTileHorizontally.Size = new System.Drawing.Size(23, 22);
            this.btnTileHorizontally.Text = "Tile Horizontally";
            // 
            // btnTileVertically
            // 
            this.btnTileVertically.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTileVertically.Image = global::iRacing.Telemetry.Windows.Properties.Resources.SplitScreenVertically_12973;
            this.btnTileVertically.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTileVertically.Name = "btnTileVertically";
            this.btnTileVertically.Size = new System.Drawing.Size(23, 22);
            this.btnTileVertically.Text = "Tile Vertically";
            // 
            // btnArrangeIcons
            // 
            this.btnArrangeIcons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnArrangeIcons.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Arrange_16xLG;
            this.btnArrangeIcons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArrangeIcons.Name = "btnArrangeIcons";
            this.btnArrangeIcons.Size = new System.Drawing.Size(23, 22);
            this.btnArrangeIcons.Text = "Arrange Icons";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // staMainViewStatusStrip
            // 
            this.staMainViewStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProjectName,
            this.lblSession,
            this.lblSetup,
            this.lblVehicle,
            this.lblTrack});
            this.staMainViewStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.staMainViewStatusStrip.Name = "staMainViewStatusStrip";
            this.staMainViewStatusStrip.Size = new System.Drawing.Size(1310, 22);
            this.staMainViewStatusStrip.TabIndex = 2;
            this.staMainViewStatusStrip.Text = "statusStrip1";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = false;
            this.lblProjectName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblProjectName.Image = global::iRacing.Telemetry.Windows.Properties.Resources.MasterPage_6478_32x;
            this.lblProjectName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(250, 17);
            this.lblProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = false;
            this.lblSession.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblSession.Image = global::iRacing.Telemetry.Windows.Properties.Resources.DatabaseProject_7342_16x;
            this.lblSession.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(250, 17);
            this.lblSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = false;
            this.lblSetup.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblSetup.Image = global::iRacing.Telemetry.Windows.Properties.Resources.PropertyIcon;
            this.lblSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(250, 17);
            this.lblSetup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVehicle
            // 
            this.lblVehicle.AutoSize = false;
            this.lblVehicle.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblVehicle.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Guage_32xLG;
            this.lblVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVehicle.Name = "lblVehicle";
            this.lblVehicle.Size = new System.Drawing.Size(250, 17);
            this.lblVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrack
            // 
            this.lblTrack.AutoSize = false;
            this.lblTrack.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblTrack.Image = global::iRacing.Telemetry.Windows.Properties.Resources.EllipseElement_10707;
            this.lblTrack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(250, 17);
            this.lblTrack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlsSessionToolStrip
            // 
            this.tlsSessionToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFirstLap,
            this.btnPreviousLap,
            this.lblSessionLaps,
            this.btnNextLap,
            this.btnLastLap,
            this.toolStripSeparator7,
            this.btnFastestLap,
            this.toolStripSeparator6,
            this.btnZoomIn,
            this.btnResetZoom,
            this.btnZoomOut,
            this.toolStripSeparator8});
            this.tlsSessionToolStrip.Location = new System.Drawing.Point(0, 49);
            this.tlsSessionToolStrip.Name = "tlsSessionToolStrip";
            this.tlsSessionToolStrip.Size = new System.Drawing.Size(1310, 25);
            this.tlsSessionToolStrip.TabIndex = 4;
            this.tlsSessionToolStrip.Text = "toolStrip1";
            // 
            // btnFirstLap
            // 
            this.btnFirstLap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirstLap.Image = global::iRacing.Telemetry.Windows.Properties.Resources.DataContainer_MoveFirstHS;
            this.btnFirstLap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirstLap.Name = "btnFirstLap";
            this.btnFirstLap.Size = new System.Drawing.Size(23, 22);
            this.btnFirstLap.Text = "First Lap";
            this.btnFirstLap.Click += new System.EventHandler(this.btnFirstLap_Click);
            // 
            // btnPreviousLap
            // 
            this.btnPreviousLap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPreviousLap.Image = global::iRacing.Telemetry.Windows.Properties.Resources.DataContainer_MovePreviousHS;
            this.btnPreviousLap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreviousLap.Name = "btnPreviousLap";
            this.btnPreviousLap.Size = new System.Drawing.Size(23, 22);
            this.btnPreviousLap.Text = "Previous Lap";
            this.btnPreviousLap.Click += new System.EventHandler(this.btnPreviousLap_Click);
            // 
            // lblSessionLaps
            // 
            this.lblSessionLaps.BackColor = System.Drawing.SystemColors.Info;
            this.lblSessionLaps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblSessionLaps.Name = "lblSessionLaps";
            this.lblSessionLaps.Size = new System.Drawing.Size(58, 22);
            this.lblSessionLaps.Text = "Lap 0 of 0";
            this.lblSessionLaps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNextLap
            // 
            this.btnNextLap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNextLap.Image = global::iRacing.Telemetry.Windows.Properties.Resources.DataContainer_MoveNextHS;
            this.btnNextLap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNextLap.Name = "btnNextLap";
            this.btnNextLap.Size = new System.Drawing.Size(23, 22);
            this.btnNextLap.Text = "Next Lap";
            this.btnNextLap.Click += new System.EventHandler(this.btnNextLap_Click);
            // 
            // btnLastLap
            // 
            this.btnLastLap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLastLap.Image = global::iRacing.Telemetry.Windows.Properties.Resources.DataContainer_MoveLastHS;
            this.btnLastLap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLastLap.Name = "btnLastLap";
            this.btnLastLap.Size = new System.Drawing.Size(23, 22);
            this.btnLastLap.Text = "Last Lap";
            this.btnLastLap.Click += new System.EventHandler(this.btnLastLap_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFastestLap
            // 
            this.btnFastestLap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFastestLap.Image = global::iRacing.Telemetry.Windows.Properties.Resources.command_link_16x16;
            this.btnFastestLap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFastestLap.Name = "btnFastestLap";
            this.btnFastestLap.Size = new System.Drawing.Size(23, 22);
            this.btnFastestLap.Text = "Fastest Lap";
            this.btnFastestLap.Click += new System.EventHandler(this.btnFastestLap_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomIn.Image = global::iRacing.Telemetry.Windows.Properties.Resources.Zoom_5442;
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(23, 22);
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
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
            // btnZoomOut
            // 
            this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOut.Image = global::iRacing.Telemetry.Windows.Properties.Resources.ZoomOut_12927;
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(23, 22);
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // MdiParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1310, 450);
            this.Controls.Add(this.tlsSessionToolStrip);
            this.Controls.Add(this.staMainViewStatusStrip);
            this.Controls.Add(this.tlsMainViewToolStrip);
            this.Controls.Add(this.mnuMainViewMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnuMainViewMenu;
            this.Name = "MdiParentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telemetry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MdiParentForm_FormClosing);
            this.Load += new System.EventHandler(this.MdiParentForm_Load);
            this.mnuMainViewMenu.ResumeLayout(false);
            this.mnuMainViewMenu.PerformLayout();
            this.tlsMainViewToolStrip.ResumeLayout(false);
            this.tlsMainViewToolStrip.PerformLayout();
            this.staMainViewStatusStrip.ResumeLayout(false);
            this.staMainViewStatusStrip.PerformLayout();
            this.tlsSessionToolStrip.ResumeLayout(false);
            this.tlsSessionToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        public ToolStripMenuItem exitToolStripMenuItem;
        public ToolStripMenuItem openToolStripMenuItem;
        public ToolStripMenuItem closeSessionToolStripMenuItem;
        public ToolStripSeparator toolStripMenuItem1;
        public ToolStripMenuItem saveSessionToolStripMenuItem;
        public ToolStripMenuItem loadSavedSessionToolStripMenuItem;
        public ToolStripSeparator toolStripMenuItem2;
        public ToolStripMenuItem newProjectToolStripMenuItem;
        public ToolStripMenuItem openProjectToolStripMenuItem;
        public ToolStripMenuItem closeProjectToolStripMenuItem;
        public ToolStripSeparator toolStripMenuItem3;
        public ToolStripMenuItem saveProjectToolStripMenuItem;
        public ToolStripMenuItem saveProjectAsToolStripMenuItem;
        public ToolStripSeparator toolStripMenuItem4;
        public ToolStripSeparator toolStripMenuItem5;
        public ToolStripMenuItem cascadeToolStripMenuItem;
        public ToolStripMenuItem tileHorizontallyToolStripMenuItem;
        public ToolStripMenuItem tileVerticallyToolStripMenuItem;
        public ToolStripMenuItem arrangeIconsToolStripMenuItem;
        public ToolStripSeparator toolStripMenuItem7;
        public ToolStripMenuItem lapTimesToolStripMenuItem;
        public ToolStripMenuItem waveformToolStripMenuItem;
        public ToolStripMenuItem histogramToolStripMenuItem;
        public ToolStripMenuItem trackMapToolStripMenuItem;
        public ToolStripMenuItem setupToolStripMenuItem;
        public ToolStripMenuItem sessionDetailsToolStripMenuItem;
        public MenuStrip mnuMainViewMenu;
        public ToolStrip tlsMainViewToolStrip;
        public StatusStrip staMainViewStatusStrip;
        public ToolStripStatusLabel lblProjectName;
        public ToolStripStatusLabel lblSession;
        public ToolStripStatusLabel lblSetup;
        public ToolStripMenuItem fileToolStripMenuItem;
        public ToolStripMenuItem sessionToolStripMenuItem;
        public ToolStripMenuItem windowToolStripMenuItem;
        public ToolStripMenuItem displayToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripButton btnNewProject;
        private ToolStripButton btnOpenProject;
        private ToolStripButton btnCloseProject;
        private ToolStripButton btnSaveProject;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnOpenSession;
        private ToolStripButton btnCloseSession;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnNewLapTimesDisplay;
        private ToolStripButton btnNewWaveformDisplay;
        private ToolStripButton btnNewHistogramDisplay;
        private ToolStripButton btnNewTrackMapDisplay;
        private ToolStripButton btnSetupDisplay;
        private ToolStripButton btnSessionDetailsDisplay;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnCascade;
        private ToolStripButton btnTileHorizontally;
        private ToolStripButton btnTileVertically;
        private ToolStripButton btnArrangeIcons;
        public ToolStripButton btnCopy;
        public ToolStripButton btnPaste;
        public ToolStripButton btnCut;
        public ToolStripButton btnDelete;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem fieldDefinitionsToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnFieldDefinitions;
        private ToolStripButton btnOptions;
        public ToolStripLabel lblSessionLaps;
        private ToolStripButton btnFirstLap;
        private ToolStripButton btnPreviousLap;
        private ToolStripButton btnFastestLap;
        private ToolStripButton btnNextLap;
        private ToolStripButton btnLastLap;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton btnZoomIn;
        private ToolStripButton btnResetZoom;
        private ToolStripButton btnZoomOut;
        private ToolStripSeparator toolStripSeparator8;
        public ToolStrip tlsSessionToolStrip;
        public ToolStripStatusLabel lblVehicle;
        private ToolStripMenuItem functionEditorToolStripMenuItem;
        private ToolStripButton btnFunctionEditor;
        private ToolStripSeparator toolStripSeparator9;
        public ToolStripButton btnSaveProjectAs;
        public ToolStripStatusLabel lblTrack;
        public ToolStripButton btnTrackMapBuilder;
        public ToolStripMenuItem trackMapBuilderToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem saveDisplayToolStripMenuItem;
        private ToolStripMenuItem openDisplayToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripButton btnSaveDisplay;
        private ToolStripButton btnOpenDisplay;
        private ToolStripMenuItem saveDisplayToolStripMenuItem1;
        private ToolStripMenuItem loadDisplayToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripSeparator toolStripMenuItem10;
        private ToolStripSeparator toolStripMenuItem11;
    }
}
