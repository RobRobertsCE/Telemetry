namespace iRacing.Telemetry.Graphing.Views
{
    partial class SeriesEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSeriesName = new System.Windows.Forms.Label();
            this.dlgSeriesColor = new System.Windows.Forms.ColorDialog();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numLineThickness = new System.Windows.Forms.NumericUpDown();
            this.btnChangeColor = new System.Windows.Forms.Button();
            this.nudMax = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chkMinWarning = new System.Windows.Forms.CheckBox();
            this.chkMaxWarning = new System.Windows.Forms.CheckBox();
            this.numMinWarn = new System.Windows.Forms.NumericUpDown();
            this.numMaxWarn = new System.Windows.Forms.NumericUpDown();
            this.chkLapAvg = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLapMin = new System.Windows.Forms.CheckBox();
            this.chkLapMax = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.chkInvertRange = new System.Windows.Forms.CheckBox();
            this.numRangeStart = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numRangeEnd = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.munPrecision = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.chkShowAxis = new System.Windows.Forms.CheckBox();
            this.chkShowTitle = new System.Windows.Forms.CheckBox();
            this.chkShowLargeTicks = new System.Windows.Forms.CheckBox();
            this.chkShowLargeLabels = new System.Windows.Forms.CheckBox();
            this.chkShowSmallTicks = new System.Windows.Forms.CheckBox();
            this.chkShowSmallLabels = new System.Windows.Forms.CheckBox();
            this.numLargeStep = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numSmallStep = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLineThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinWarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWarn)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.munPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLargeStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSmallStep)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 35);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(559, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSeriesName
            // 
            this.lblSeriesName.AutoSize = true;
            this.lblSeriesName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeriesName.Location = new System.Drawing.Point(8, 8);
            this.lblSeriesName.Name = "lblSeriesName";
            this.lblSeriesName.Size = new System.Drawing.Size(103, 16);
            this.lblSeriesName.TabIndex = 2;
            this.lblSeriesName.Text = "[series name]";
            // 
            // dlgSeriesColor
            // 
            this.dlgSeriesColor.SolidColorOnly = true;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(8, 44);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "Color";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(11, 60);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(78, 20);
            this.txtColor.TabIndex = 5;
            this.txtColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtColor.DoubleClick += new System.EventHandler(this.txtColor_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Format";
            // 
            // txtFormat
            // 
            this.txtFormat.Location = new System.Drawing.Point(11, 96);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.Size = new System.Drawing.Size(144, 20);
            this.txtFormat.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Line Thickness";
            // 
            // numLineThickness
            // 
            this.numLineThickness.DecimalPlaces = 1;
            this.numLineThickness.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numLineThickness.Location = new System.Drawing.Point(11, 174);
            this.numLineThickness.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numLineThickness.Name = "numLineThickness";
            this.numLineThickness.Size = new System.Drawing.Size(77, 20);
            this.numLineThickness.TabIndex = 9;
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Location = new System.Drawing.Point(95, 60);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(59, 20);
            this.btnChangeColor.TabIndex = 10;
            this.btnChangeColor.Text = "Set Color";
            this.btnChangeColor.UseVisualStyleBackColor = true;
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // nudMax
            // 
            this.nudMax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudMax.Location = new System.Drawing.Point(105, 213);
            this.nudMax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMax.Name = "nudMax";
            this.nudMax.Size = new System.Drawing.Size(89, 20);
            this.nudMax.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Maximum";
            // 
            // nudMin
            // 
            this.nudMin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudMin.Location = new System.Drawing.Point(11, 213);
            this.nudMin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(89, 20);
            this.nudMin.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Minimum";
            // 
            // chkMinWarning
            // 
            this.chkMinWarning.AutoSize = true;
            this.chkMinWarning.Location = new System.Drawing.Point(11, 239);
            this.chkMinWarning.Name = "chkMinWarning";
            this.chkMinWarning.Size = new System.Drawing.Size(86, 17);
            this.chkMinWarning.TabIndex = 15;
            this.chkMinWarning.Text = "Min Warning";
            this.chkMinWarning.UseVisualStyleBackColor = true;
            this.chkMinWarning.CheckStateChanged += new System.EventHandler(this.chkMinWarning_CheckStateChanged);
            // 
            // chkMaxWarning
            // 
            this.chkMaxWarning.AutoSize = true;
            this.chkMaxWarning.Location = new System.Drawing.Point(105, 239);
            this.chkMaxWarning.Name = "chkMaxWarning";
            this.chkMaxWarning.Size = new System.Drawing.Size(89, 17);
            this.chkMaxWarning.TabIndex = 16;
            this.chkMaxWarning.Text = "Max Warning";
            this.chkMaxWarning.UseVisualStyleBackColor = true;
            this.chkMaxWarning.CheckStateChanged += new System.EventHandler(this.chkMaxWarning_CheckStateChanged);
            // 
            // numMinWarn
            // 
            this.numMinWarn.DecimalPlaces = 2;
            this.numMinWarn.Enabled = false;
            this.numMinWarn.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numMinWarn.Location = new System.Drawing.Point(11, 262);
            this.numMinWarn.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMinWarn.Name = "numMinWarn";
            this.numMinWarn.Size = new System.Drawing.Size(89, 20);
            this.numMinWarn.TabIndex = 18;
            // 
            // numMaxWarn
            // 
            this.numMaxWarn.DecimalPlaces = 2;
            this.numMaxWarn.Enabled = false;
            this.numMaxWarn.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numMaxWarn.Location = new System.Drawing.Point(105, 262);
            this.numMaxWarn.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMaxWarn.Name = "numMaxWarn";
            this.numMaxWarn.Size = new System.Drawing.Size(89, 20);
            this.numMaxWarn.TabIndex = 17;
            // 
            // chkLapAvg
            // 
            this.chkLapAvg.AutoSize = true;
            this.chkLapAvg.Location = new System.Drawing.Point(6, 62);
            this.chkLapAvg.Name = "chkLapAvg";
            this.chkLapAvg.Size = new System.Drawing.Size(87, 17);
            this.chkLapAvg.TabIndex = 19;
            this.chkLapAvg.Text = "Lap Average";
            this.chkLapAvg.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLapMin);
            this.groupBox1.Controls.Add(this.chkLapMax);
            this.groupBox1.Controls.Add(this.chkLapAvg);
            this.groupBox1.Location = new System.Drawing.Point(227, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 95);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summaries";
            // 
            // chkLapMin
            // 
            this.chkLapMin.AutoSize = true;
            this.chkLapMin.Location = new System.Drawing.Point(6, 16);
            this.chkLapMin.Name = "chkLapMin";
            this.chkLapMin.Size = new System.Drawing.Size(88, 17);
            this.chkLapMin.TabIndex = 21;
            this.chkLapMin.Text = "Lap Minimum";
            this.chkLapMin.UseVisualStyleBackColor = true;
            // 
            // chkLapMax
            // 
            this.chkLapMax.AutoSize = true;
            this.chkLapMax.Location = new System.Drawing.Point(6, 39);
            this.chkLapMax.Name = "chkLapMax";
            this.chkLapMax.Size = new System.Drawing.Size(91, 17);
            this.chkLapMax.TabIndex = 20;
            this.chkLapMax.Text = "Lap Maximum";
            this.chkLapMax.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Unit";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(11, 135);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(144, 20);
            this.txtUnit.TabIndex = 7;
            // 
            // chkInvertRange
            // 
            this.chkInvertRange.AutoSize = true;
            this.chkInvertRange.Location = new System.Drawing.Point(233, 214);
            this.chkInvertRange.Name = "chkInvertRange";
            this.chkInvertRange.Size = new System.Drawing.Size(88, 17);
            this.chkInvertRange.TabIndex = 21;
            this.chkInvertRange.Text = "Invert Range";
            this.chkInvertRange.UseVisualStyleBackColor = true;
            // 
            // numRangeStart
            // 
            this.numRangeStart.DecimalPlaces = 2;
            this.numRangeStart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRangeStart.Location = new System.Drawing.Point(233, 262);
            this.numRangeStart.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRangeStart.Name = "numRangeStart";
            this.numRangeStart.Size = new System.Drawing.Size(89, 20);
            this.numRangeStart.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Range Start";
            // 
            // numRangeEnd
            // 
            this.numRangeEnd.DecimalPlaces = 2;
            this.numRangeEnd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRangeEnd.Location = new System.Drawing.Point(328, 262);
            this.numRangeEnd.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRangeEnd.Name = "numRangeEnd";
            this.numRangeEnd.Size = new System.Drawing.Size(89, 20);
            this.numRangeEnd.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Range End";
            // 
            // munPrecision
            // 
            this.munPrecision.DecimalPlaces = 2;
            this.munPrecision.Location = new System.Drawing.Point(233, 175);
            this.munPrecision.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.munPrecision.Name = "munPrecision";
            this.munPrecision.Size = new System.Drawing.Size(89, 20);
            this.munPrecision.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(230, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Precision";
            // 
            // chkShowAxis
            // 
            this.chkShowAxis.AutoSize = true;
            this.chkShowAxis.Location = new System.Drawing.Point(439, 63);
            this.chkShowAxis.Name = "chkShowAxis";
            this.chkShowAxis.Size = new System.Drawing.Size(75, 17);
            this.chkShowAxis.TabIndex = 28;
            this.chkShowAxis.Text = "Show Axis";
            this.chkShowAxis.UseVisualStyleBackColor = true;
            // 
            // chkShowTitle
            // 
            this.chkShowTitle.AutoSize = true;
            this.chkShowTitle.Location = new System.Drawing.Point(439, 86);
            this.chkShowTitle.Name = "chkShowTitle";
            this.chkShowTitle.Size = new System.Drawing.Size(76, 17);
            this.chkShowTitle.TabIndex = 29;
            this.chkShowTitle.Text = "Show Title";
            this.chkShowTitle.UseVisualStyleBackColor = true;
            // 
            // chkShowLargeTicks
            // 
            this.chkShowLargeTicks.AutoSize = true;
            this.chkShowLargeTicks.Location = new System.Drawing.Point(439, 109);
            this.chkShowLargeTicks.Name = "chkShowLargeTicks";
            this.chkShowLargeTicks.Size = new System.Drawing.Size(112, 17);
            this.chkShowLargeTicks.TabIndex = 30;
            this.chkShowLargeTicks.Text = "Show Large Ticks";
            this.chkShowLargeTicks.UseVisualStyleBackColor = true;
            this.chkShowLargeTicks.CheckStateChanged += new System.EventHandler(this.chkShowLargeTicks_CheckStateChanged);
            // 
            // chkShowLargeLabels
            // 
            this.chkShowLargeLabels.AutoSize = true;
            this.chkShowLargeLabels.Location = new System.Drawing.Point(453, 132);
            this.chkShowLargeLabels.Name = "chkShowLargeLabels";
            this.chkShowLargeLabels.Size = new System.Drawing.Size(117, 17);
            this.chkShowLargeLabels.TabIndex = 31;
            this.chkShowLargeLabels.Text = "Show Large Labels";
            this.chkShowLargeLabels.UseVisualStyleBackColor = true;
            // 
            // chkShowSmallTicks
            // 
            this.chkShowSmallTicks.AutoSize = true;
            this.chkShowSmallTicks.Location = new System.Drawing.Point(439, 155);
            this.chkShowSmallTicks.Name = "chkShowSmallTicks";
            this.chkShowSmallTicks.Size = new System.Drawing.Size(110, 17);
            this.chkShowSmallTicks.TabIndex = 32;
            this.chkShowSmallTicks.Text = "Show Small Ticks";
            this.chkShowSmallTicks.UseVisualStyleBackColor = true;
            this.chkShowSmallTicks.CheckStateChanged += new System.EventHandler(this.chkShowSmallTicks_CheckStateChanged);
            // 
            // chkShowSmallLabels
            // 
            this.chkShowSmallLabels.AutoSize = true;
            this.chkShowSmallLabels.Location = new System.Drawing.Point(453, 175);
            this.chkShowSmallLabels.Name = "chkShowSmallLabels";
            this.chkShowSmallLabels.Size = new System.Drawing.Size(115, 17);
            this.chkShowSmallLabels.TabIndex = 33;
            this.chkShowSmallLabels.Text = "Show Small Labels";
            this.chkShowSmallLabels.UseVisualStyleBackColor = true;
            // 
            // numLargeStep
            // 
            this.numLargeStep.DecimalPlaces = 2;
            this.numLargeStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numLargeStep.Location = new System.Drawing.Point(11, 303);
            this.numLargeStep.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLargeStep.Name = "numLargeStep";
            this.numLargeStep.Size = new System.Drawing.Size(89, 20);
            this.numLargeStep.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Large Step";
            // 
            // numSmallStep
            // 
            this.numSmallStep.DecimalPlaces = 2;
            this.numSmallStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSmallStep.Location = new System.Drawing.Point(105, 303);
            this.numSmallStep.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSmallStep.Name = "numSmallStep";
            this.numSmallStep.Size = new System.Drawing.Size(89, 20);
            this.numSmallStep.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(104, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Small Step";
            // 
            // SeriesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 368);
            this.Controls.Add(this.numLargeStep);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numSmallStep);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkShowSmallLabels);
            this.Controls.Add(this.chkShowSmallTicks);
            this.Controls.Add(this.chkShowLargeLabels);
            this.Controls.Add(this.chkShowLargeTicks);
            this.Controls.Add(this.chkShowTitle);
            this.Controls.Add(this.chkShowAxis);
            this.Controls.Add(this.munPrecision);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numRangeStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numRangeEnd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkInvertRange);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numMinWarn);
            this.Controls.Add(this.numMaxWarn);
            this.Controls.Add(this.chkMaxWarning);
            this.Controls.Add(this.chkMinWarning);
            this.Controls.Add(this.nudMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChangeColor);
            this.Controls.Add(this.numLineThickness);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtFormat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblSeriesName);
            this.Controls.Add(this.panel1);
            this.Name = "SeriesEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Series Editor";
            this.Load += new System.EventHandler(this.SeriesEditor_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numLineThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinWarn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWarn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.munPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLargeStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSmallStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSeriesName;
        private System.Windows.Forms.ColorDialog dlgSeriesColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numLineThickness;
        private System.Windows.Forms.Button btnChangeColor;
        private System.Windows.Forms.NumericUpDown nudMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkMinWarning;
        private System.Windows.Forms.CheckBox chkMaxWarning;
        private System.Windows.Forms.NumericUpDown numMinWarn;
        private System.Windows.Forms.NumericUpDown numMaxWarn;
        private System.Windows.Forms.CheckBox chkLapAvg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkLapMin;
        private System.Windows.Forms.CheckBox chkLapMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.CheckBox chkInvertRange;
        private System.Windows.Forms.NumericUpDown numRangeStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numRangeEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown munPrecision;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkShowAxis;
        private System.Windows.Forms.CheckBox chkShowTitle;
        private System.Windows.Forms.CheckBox chkShowLargeTicks;
        private System.Windows.Forms.CheckBox chkShowLargeLabels;
        private System.Windows.Forms.CheckBox chkShowSmallTicks;
        private System.Windows.Forms.CheckBox chkShowSmallLabels;
        private System.Windows.Forms.NumericUpDown numLargeStep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numSmallStep;
        private System.Windows.Forms.Label label10;
    }
}