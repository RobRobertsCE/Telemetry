namespace iRacing.Telemetry.Windows.Views
{
    partial class FieldDefinitionsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldDefinitionsView));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvFieldDefinitions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkSelectedFieldsOnly = new System.Windows.Forms.CheckBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlSeries = new System.Windows.Forms.Panel();
            this.cboConversions = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numThickness = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLineColor = new System.Windows.Forms.Label();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnResetAll = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlSeries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvFieldDefinitions);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pnlSeries);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1210, 471);
            this.panel2.TabIndex = 3;
            // 
            // lvFieldDefinitions
            // 
            this.lvFieldDefinitions.CheckBoxes = true;
            this.lvFieldDefinitions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvFieldDefinitions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFieldDefinitions.FullRowSelect = true;
            this.lvFieldDefinitions.GridLines = true;
            this.lvFieldDefinitions.HideSelection = false;
            this.lvFieldDefinitions.Location = new System.Drawing.Point(0, 31);
            this.lvFieldDefinitions.Margin = new System.Windows.Forms.Padding(4);
            this.lvFieldDefinitions.Name = "lvFieldDefinitions";
            this.lvFieldDefinitions.Size = new System.Drawing.Size(1210, 319);
            this.lvFieldDefinitions.TabIndex = 0;
            this.lvFieldDefinitions.UseCompatibleStateImageBehavior = false;
            this.lvFieldDefinitions.View = System.Windows.Forms.View.Details;
            this.lvFieldDefinitions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvFieldDefinitions_ItemCheck);
            this.lvFieldDefinitions.SelectedIndexChanged += new System.EventHandler(this.lvFieldDefinitions_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Field";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data Type";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Units";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Size";
            this.columnHeader4.Width = 75;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Display Info";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Color";
            this.columnHeader6.Width = 250;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "DisplayUnit";
            this.columnHeader7.Width = 200;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkSelectedFieldsOnly);
            this.panel3.Controls.Add(this.lblFilterStatus);
            this.panel3.Controls.Add(this.btnClearSearch);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1210, 31);
            this.panel3.TabIndex = 2;
            // 
            // chkSelectedFieldsOnly
            // 
            this.chkSelectedFieldsOnly.AutoSize = true;
            this.chkSelectedFieldsOnly.Location = new System.Drawing.Point(668, 5);
            this.chkSelectedFieldsOnly.Name = "chkSelectedFieldsOnly";
            this.chkSelectedFieldsOnly.Size = new System.Drawing.Size(151, 20);
            this.chkSelectedFieldsOnly.TabIndex = 5;
            this.chkSelectedFieldsOnly.Text = "Selected Fields Only";
            this.chkSelectedFieldsOnly.UseVisualStyleBackColor = true;
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Location = new System.Drawing.Point(462, 6);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(12, 16);
            this.lblFilterStatus.TabIndex = 4;
            this.lblFilterStatus.Text = "-";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Image = global::iRacing.Telemetry.Windows.Properties.Resources.StatusAnnotations_Play_32xMD_color;
            this.btnClearSearch.Location = new System.Drawing.Point(397, 3);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(35, 22);
            this.btnClearSearch.TabIndex = 3;
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::iRacing.Telemetry.Windows.Properties.Resources.FilteredObject_13400_32x;
            this.btnSearch.Location = new System.Drawing.Point(356, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 22);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "?";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(338, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // pnlSeries
            // 
            this.pnlSeries.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSeries.Controls.Add(this.cboConversions);
            this.pnlSeries.Controls.Add(this.label8);
            this.pnlSeries.Controls.Add(this.txtFormat);
            this.pnlSeries.Controls.Add(this.label7);
            this.pnlSeries.Controls.Add(this.txtMax);
            this.pnlSeries.Controls.Add(this.label6);
            this.pnlSeries.Controls.Add(this.txtMin);
            this.pnlSeries.Controls.Add(this.label5);
            this.pnlSeries.Controls.Add(this.numThickness);
            this.pnlSeries.Controls.Add(this.label4);
            this.pnlSeries.Controls.Add(this.txtName);
            this.pnlSeries.Controls.Add(this.label3);
            this.pnlSeries.Controls.Add(this.label2);
            this.pnlSeries.Controls.Add(this.lblLineColor);
            this.pnlSeries.Controls.Add(this.picColor);
            this.pnlSeries.Controls.Add(this.label1);
            this.pnlSeries.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSeries.Location = new System.Drawing.Point(0, 350);
            this.pnlSeries.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSeries.Name = "pnlSeries";
            this.pnlSeries.Size = new System.Drawing.Size(1210, 121);
            this.pnlSeries.TabIndex = 1;
            // 
            // cboConversions
            // 
            this.cboConversions.FormattingEnabled = true;
            this.cboConversions.Location = new System.Drawing.Point(706, 81);
            this.cboConversions.Name = "cboConversions";
            this.cboConversions.Size = new System.Drawing.Size(229, 24);
            this.cboConversions.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(703, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Conversion";
            // 
            // txtFormat
            // 
            this.txtFormat.Location = new System.Drawing.Point(706, 39);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.Size = new System.Drawing.Size(229, 22);
            this.txtFormat.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(703, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Display Format";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(597, 83);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(103, 22);
            this.txtMax.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(594, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Range Max";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(597, 39);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(103, 22);
            this.txtMin.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Range Min";
            // 
            // numThickness
            // 
            this.numThickness.DecimalPlaces = 1;
            this.numThickness.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numThickness.Location = new System.Drawing.Point(11, 86);
            this.numThickness.Name = "numThickness";
            this.numThickness.Size = new System.Drawing.Size(93, 22);
            this.numThickness.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Line Thickness";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(11, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(580, 22);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Line Color";
            // 
            // lblLineColor
            // 
            this.lblLineColor.AutoSize = true;
            this.lblLineColor.Location = new System.Drawing.Point(164, 89);
            this.lblLineColor.Name = "lblLineColor";
            this.lblLineColor.Size = new System.Drawing.Size(42, 16);
            this.lblLineColor.TabIndex = 2;
            this.lblLineColor.Text = "White";
            this.lblLineColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picColor
            // 
            this.picColor.BackColor = System.Drawing.Color.White;
            this.picColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picColor.Location = new System.Drawing.Point(110, 86);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(48, 22);
            this.picColor.TabIndex = 1;
            this.picColor.TabStop = false;
            this.picColor.BackColorChanged += new System.EventHandler(this.picColor_BackColorChanged);
            this.picColor.Click += new System.EventHandler(this.picColor_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1208, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default Series Properties";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnResetAll);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 471);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1210, 52);
            this.panel1.TabIndex = 2;
            // 
            // btnResetAll
            // 
            this.btnResetAll.BackColor = System.Drawing.Color.Red;
            this.btnResetAll.Location = new System.Drawing.Point(598, 4);
            this.btnResetAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.Size = new System.Drawing.Size(133, 41);
            this.btnResetAll.TabIndex = 4;
            this.btnResetAll.Text = "Reset All";
            this.btnResetAll.UseVisualStyleBackColor = false;
            this.btnResetAll.Click += new System.EventHandler(this.btnResetAll_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(287, 4);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(133, 41);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import...";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(146, 4);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(133, 41);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(1073, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 41);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FieldDefinitionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 523);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FieldDefinitionsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Field Definitions";
            this.Load += new System.EventHandler(this.FieldDefinitionsView_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlSeries.ResumeLayout(false);
            this.pnlSeries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lvFieldDefinitions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel pnlSeries;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.Label lblLineColor;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numThickness;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboConversions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnResetAll;
        private System.Windows.Forms.CheckBox chkSelectedFieldsOnly;
    }
}