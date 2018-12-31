namespace iRacing.Telemetry.Controls.Views
{
    partial class GroupingEditor
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
            this.numRangeStart = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numRangeEnd = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSeriesName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 106);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 38);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(254, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(4, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 31);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numRangeStart
            // 
            this.numRangeStart.DecimalPlaces = 2;
            this.numRangeStart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRangeStart.Location = new System.Drawing.Point(13, 62);
            this.numRangeStart.Margin = new System.Windows.Forms.Padding(4);
            this.numRangeStart.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRangeStart.Name = "numRangeStart";
            this.numRangeStart.Size = new System.Drawing.Size(119, 22);
            this.numRangeStart.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 28;
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
            this.numRangeEnd.Location = new System.Drawing.Point(154, 62);
            this.numRangeEnd.Margin = new System.Windows.Forms.Padding(4);
            this.numRangeEnd.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRangeEnd.Name = "numRangeEnd";
            this.numRangeEnd.Size = new System.Drawing.Size(119, 22);
            this.numRangeEnd.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(150, 42);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "Range End";
            // 
            // lblSeriesName
            // 
            this.lblSeriesName.AutoSize = true;
            this.lblSeriesName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeriesName.Location = new System.Drawing.Point(11, 10);
            this.lblSeriesName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeriesName.Name = "lblSeriesName";
            this.lblSeriesName.Size = new System.Drawing.Size(103, 16);
            this.lblSeriesName.TabIndex = 30;
            this.lblSeriesName.Text = "[series name]";
            // 
            // GroupingEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 144);
            this.Controls.Add(this.lblSeriesName);
            this.Controls.Add(this.numRangeStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numRangeEnd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GroupingEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Range";
            this.Load += new System.EventHandler(this.GroupingEditor_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numRangeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numRangeStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numRangeEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSeriesName;
    }
}