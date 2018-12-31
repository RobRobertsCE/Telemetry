namespace iRacing.Telemetry.Controls.Views
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
            this.numLargeStep = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numRightMargin = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numLeftMargin = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numBottomMargin = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numTopMargin = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSetAxisFont = new System.Windows.Forms.Button();
            this.lblAxisFont = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLineThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinWarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.munPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLargeStep)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRightMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeftMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBottomMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTopMargin)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 35);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(412, 3);
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
            this.chkInvertRange.Location = new System.Drawing.Point(217, 252);
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
            this.numRangeStart.Location = new System.Drawing.Point(217, 303);
            this.numRangeStart.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRangeStart.Name = "numRangeStart";
            this.numRangeStart.Size = new System.Drawing.Size(50, 20);
            this.numRangeStart.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 284);
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
            this.numRangeEnd.Location = new System.Drawing.Point(282, 303);
            this.numRangeEnd.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRangeEnd.Name = "numRangeEnd";
            this.numRangeEnd.Size = new System.Drawing.Size(50, 20);
            this.numRangeEnd.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Range End";
            // 
            // munPrecision
            // 
            this.munPrecision.DecimalPlaces = 2;
            this.munPrecision.Location = new System.Drawing.Point(217, 213);
            this.munPrecision.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.munPrecision.Name = "munPrecision";
            this.munPrecision.Size = new System.Drawing.Size(50, 20);
            this.munPrecision.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(214, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Precision";
            // 
            // chkShowAxis
            // 
            this.chkShowAxis.AutoSize = true;
            this.chkShowAxis.Location = new System.Drawing.Point(217, 60);
            this.chkShowAxis.Name = "chkShowAxis";
            this.chkShowAxis.Size = new System.Drawing.Size(75, 17);
            this.chkShowAxis.TabIndex = 28;
            this.chkShowAxis.Text = "Show Axis";
            this.chkShowAxis.UseVisualStyleBackColor = true;
            // 
            // chkShowTitle
            // 
            this.chkShowTitle.AutoSize = true;
            this.chkShowTitle.Location = new System.Drawing.Point(217, 83);
            this.chkShowTitle.Name = "chkShowTitle";
            this.chkShowTitle.Size = new System.Drawing.Size(76, 17);
            this.chkShowTitle.TabIndex = 29;
            this.chkShowTitle.Text = "Show Title";
            this.chkShowTitle.UseVisualStyleBackColor = true;
            // 
            // chkShowLargeTicks
            // 
            this.chkShowLargeTicks.AutoSize = true;
            this.chkShowLargeTicks.Location = new System.Drawing.Point(217, 106);
            this.chkShowLargeTicks.Name = "chkShowLargeTicks";
            this.chkShowLargeTicks.Size = new System.Drawing.Size(82, 17);
            this.chkShowLargeTicks.TabIndex = 30;
            this.chkShowLargeTicks.Text = "Show Ticks";
            this.chkShowLargeTicks.UseVisualStyleBackColor = true;
            this.chkShowLargeTicks.CheckStateChanged += new System.EventHandler(this.chkShowLargeTicks_CheckStateChanged);
            // 
            // chkShowLargeLabels
            // 
            this.chkShowLargeLabels.AutoSize = true;
            this.chkShowLargeLabels.Location = new System.Drawing.Point(231, 129);
            this.chkShowLargeLabels.Name = "chkShowLargeLabels";
            this.chkShowLargeLabels.Size = new System.Drawing.Size(111, 17);
            this.chkShowLargeLabels.TabIndex = 31;
            this.chkShowLargeLabels.Text = "Show Tick Labels";
            this.chkShowLargeLabels.UseVisualStyleBackColor = true;
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
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Tick Step";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numRightMargin);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.numLeftMargin);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.numBottomMargin);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.numTopMargin);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(348, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 127);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Margins";
            // 
            // numRightMargin
            // 
            this.numRightMargin.Location = new System.Drawing.Point(67, 100);
            this.numRightMargin.Name = "numRightMargin";
            this.numRightMargin.Size = new System.Drawing.Size(42, 20);
            this.numRightMargin.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Right";
            // 
            // numLeftMargin
            // 
            this.numLeftMargin.Location = new System.Drawing.Point(67, 74);
            this.numLeftMargin.Name = "numLeftMargin";
            this.numLeftMargin.Size = new System.Drawing.Size(42, 20);
            this.numLeftMargin.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Left";
            // 
            // numBottomMargin
            // 
            this.numBottomMargin.Location = new System.Drawing.Point(67, 48);
            this.numBottomMargin.Name = "numBottomMargin";
            this.numBottomMargin.Size = new System.Drawing.Size(42, 20);
            this.numBottomMargin.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Bottom";
            // 
            // numTopMargin
            // 
            this.numTopMargin.Location = new System.Drawing.Point(67, 22);
            this.numTopMargin.Name = "numTopMargin";
            this.numTopMargin.Size = new System.Drawing.Size(42, 20);
            this.numTopMargin.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Top";
            // 
            // btnSetAxisFont
            // 
            this.btnSetAxisFont.Location = new System.Drawing.Point(11, 329);
            this.btnSetAxisFont.Name = "btnSetAxisFont";
            this.btnSetAxisFont.Size = new System.Drawing.Size(40, 23);
            this.btnSetAxisFont.TabIndex = 9;
            this.btnSetAxisFont.Text = "Set...";
            this.btnSetAxisFont.UseVisualStyleBackColor = true;
            this.btnSetAxisFont.Click += new System.EventHandler(this.btnSetAxisFont_Click);
            // 
            // lblAxisFont
            // 
            this.lblAxisFont.AutoSize = true;
            this.lblAxisFont.Location = new System.Drawing.Point(57, 334);
            this.lblAxisFont.Name = "lblAxisFont";
            this.lblAxisFont.Size = new System.Drawing.Size(57, 13);
            this.lblAxisFont.TabIndex = 8;
            this.lblAxisFont.Text = "[Axis Font}";
            // 
            // SeriesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 411);
            this.Controls.Add(this.btnSetAxisFont);
            this.Controls.Add(this.lblAxisFont);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numLargeStep);
            this.Controls.Add(this.label9);
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
            ((System.ComponentModel.ISupportInitialize)(this.numRangeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.munPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLargeStep)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRightMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeftMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBottomMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTopMargin)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numLargeStep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numRightMargin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numLeftMargin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numBottomMargin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numTopMargin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSetAxisFont;
        private System.Windows.Forms.Label lblAxisFont;
    }
}