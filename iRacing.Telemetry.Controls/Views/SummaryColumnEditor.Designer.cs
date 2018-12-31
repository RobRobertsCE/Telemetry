namespace iRacing.Telemetry.Controls.Views
{
    partial class SummaryColumnEditor
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
            this.chkLapMin = new System.Windows.Forms.CheckBox();
            this.chkLapMax = new System.Windows.Forms.CheckBox();
            this.chkLapAvg = new System.Windows.Forms.CheckBox();
            this.chkLapStdDev = new System.Windows.Forms.CheckBox();
            this.chkSessionStdDev = new System.Windows.Forms.CheckBox();
            this.chkSessionMin = new System.Windows.Forms.CheckBox();
            this.chkSessionMax = new System.Windows.Forms.CheckBox();
            this.chkSessionAvg = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkSessionMode = new System.Windows.Forms.CheckBox();
            this.chkSessionDelta = new System.Windows.Forms.CheckBox();
            this.chkLapMode = new System.Windows.Forms.CheckBox();
            this.chkLapDelta = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 226);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 38);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(166, 4);
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
            // lblSeriesName
            // 
            this.lblSeriesName.AutoSize = true;
            this.lblSeriesName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeriesName.Location = new System.Drawing.Point(8, 8);
            this.lblSeriesName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeriesName.Name = "lblSeriesName";
            this.lblSeriesName.Size = new System.Drawing.Size(103, 16);
            this.lblSeriesName.TabIndex = 31;
            this.lblSeriesName.Text = "[series name]";
            // 
            // chkLapMin
            // 
            this.chkLapMin.AutoSize = true;
            this.chkLapMin.Location = new System.Drawing.Point(24, 43);
            this.chkLapMin.Name = "chkLapMin";
            this.chkLapMin.Size = new System.Drawing.Size(88, 17);
            this.chkLapMin.TabIndex = 21;
            this.chkLapMin.Text = "Lap Minimum";
            this.chkLapMin.UseVisualStyleBackColor = true;
            this.chkLapMin.CheckedChanged += new System.EventHandler(this.chkSummaryColumn_CheckedChanged);
            // 
            // chkLapMax
            // 
            this.chkLapMax.AutoSize = true;
            this.chkLapMax.Location = new System.Drawing.Point(24, 66);
            this.chkLapMax.Name = "chkLapMax";
            this.chkLapMax.Size = new System.Drawing.Size(91, 17);
            this.chkLapMax.TabIndex = 20;
            this.chkLapMax.Text = "Lap Maximum";
            this.chkLapMax.UseVisualStyleBackColor = true;
            this.chkLapMax.CheckedChanged += new System.EventHandler(this.chkSummaryColumn_CheckedChanged);
            // 
            // chkLapAvg
            // 
            this.chkLapAvg.AutoSize = true;
            this.chkLapAvg.Location = new System.Drawing.Point(24, 135);
            this.chkLapAvg.Name = "chkLapAvg";
            this.chkLapAvg.Size = new System.Drawing.Size(87, 17);
            this.chkLapAvg.TabIndex = 19;
            this.chkLapAvg.Text = "Lap Average";
            this.chkLapAvg.UseVisualStyleBackColor = true;
            this.chkLapAvg.CheckedChanged += new System.EventHandler(this.chkSummaryColumn_CheckedChanged);
            // 
            // chkLapStdDev
            // 
            this.chkLapStdDev.AutoSize = true;
            this.chkLapStdDev.Location = new System.Drawing.Point(24, 158);
            this.chkLapStdDev.Name = "chkLapStdDev";
            this.chkLapStdDev.Size = new System.Drawing.Size(86, 17);
            this.chkLapStdDev.TabIndex = 32;
            this.chkLapStdDev.Text = "Lap Std Dev";
            this.chkLapStdDev.UseVisualStyleBackColor = true;
            this.chkLapStdDev.CheckedChanged += new System.EventHandler(this.chkSummaryColumn_CheckedChanged);
            // 
            // chkSessionStdDev
            // 
            this.chkSessionStdDev.AutoSize = true;
            this.chkSessionStdDev.Location = new System.Drawing.Point(134, 158);
            this.chkSessionStdDev.Name = "chkSessionStdDev";
            this.chkSessionStdDev.Size = new System.Drawing.Size(105, 17);
            this.chkSessionStdDev.TabIndex = 36;
            this.chkSessionStdDev.Text = "Session Std Dev";
            this.chkSessionStdDev.UseVisualStyleBackColor = true;
            this.chkSessionStdDev.CheckedChanged += new System.EventHandler(this.chkSummaryColumn_CheckedChanged);
            // 
            // chkSessionMin
            // 
            this.chkSessionMin.AutoSize = true;
            this.chkSessionMin.Location = new System.Drawing.Point(134, 43);
            this.chkSessionMin.Name = "chkSessionMin";
            this.chkSessionMin.Size = new System.Drawing.Size(107, 17);
            this.chkSessionMin.TabIndex = 35;
            this.chkSessionMin.Text = "Session Minimum";
            this.chkSessionMin.UseVisualStyleBackColor = true;
            this.chkSessionMin.CheckedChanged += new System.EventHandler(this.chkSummaryColumn_CheckedChanged);
            // 
            // chkSessionMax
            // 
            this.chkSessionMax.AutoSize = true;
            this.chkSessionMax.Location = new System.Drawing.Point(134, 66);
            this.chkSessionMax.Name = "chkSessionMax";
            this.chkSessionMax.Size = new System.Drawing.Size(110, 17);
            this.chkSessionMax.TabIndex = 34;
            this.chkSessionMax.Text = "Session Maximum";
            this.chkSessionMax.UseVisualStyleBackColor = true;
            this.chkSessionMax.CheckedChanged += new System.EventHandler(this.chkSummaryColumn_CheckedChanged);
            // 
            // chkSessionAvg
            // 
            this.chkSessionAvg.AutoSize = true;
            this.chkSessionAvg.Location = new System.Drawing.Point(134, 135);
            this.chkSessionAvg.Name = "chkSessionAvg";
            this.chkSessionAvg.Size = new System.Drawing.Size(106, 17);
            this.chkSessionAvg.TabIndex = 33;
            this.chkSessionAvg.Text = "Session Average";
            this.chkSessionAvg.UseVisualStyleBackColor = true;
            this.chkSessionAvg.CheckedChanged += new System.EventHandler(this.chkSummaryColumn_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(24, 196);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 37;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkSessionMode
            // 
            this.chkSessionMode.AutoSize = true;
            this.chkSessionMode.Location = new System.Drawing.Point(134, 112);
            this.chkSessionMode.Name = "chkSessionMode";
            this.chkSessionMode.Size = new System.Drawing.Size(93, 17);
            this.chkSessionMode.TabIndex = 41;
            this.chkSessionMode.Text = "Session Mode";
            this.chkSessionMode.UseVisualStyleBackColor = true;
            // 
            // chkSessionDelta
            // 
            this.chkSessionDelta.AutoSize = true;
            this.chkSessionDelta.Location = new System.Drawing.Point(134, 89);
            this.chkSessionDelta.Name = "chkSessionDelta";
            this.chkSessionDelta.Size = new System.Drawing.Size(91, 17);
            this.chkSessionDelta.TabIndex = 40;
            this.chkSessionDelta.Text = "Session Delta";
            this.chkSessionDelta.UseVisualStyleBackColor = true;
            // 
            // chkLapMode
            // 
            this.chkLapMode.AutoSize = true;
            this.chkLapMode.Location = new System.Drawing.Point(24, 112);
            this.chkLapMode.Name = "chkLapMode";
            this.chkLapMode.Size = new System.Drawing.Size(74, 17);
            this.chkLapMode.TabIndex = 39;
            this.chkLapMode.Text = "Lap Mode";
            this.chkLapMode.UseVisualStyleBackColor = true;
            // 
            // chkLapDelta
            // 
            this.chkLapDelta.AutoSize = true;
            this.chkLapDelta.Location = new System.Drawing.Point(24, 89);
            this.chkLapDelta.Name = "chkLapDelta";
            this.chkLapDelta.Size = new System.Drawing.Size(72, 17);
            this.chkLapDelta.TabIndex = 38;
            this.chkLapDelta.Text = "Lap Delta";
            this.chkLapDelta.UseVisualStyleBackColor = true;
            // 
            // SummaryColumnEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 264);
            this.Controls.Add(this.chkSessionMode);
            this.Controls.Add(this.chkSessionDelta);
            this.Controls.Add(this.chkLapMode);
            this.Controls.Add(this.chkLapDelta);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkSessionStdDev);
            this.Controls.Add(this.chkSessionMin);
            this.Controls.Add(this.chkSessionMax);
            this.Controls.Add(this.chkSessionAvg);
            this.Controls.Add(this.chkLapStdDev);
            this.Controls.Add(this.chkLapMin);
            this.Controls.Add(this.chkLapMax);
            this.Controls.Add(this.lblSeriesName);
            this.Controls.Add(this.chkLapAvg);
            this.Controls.Add(this.panel1);
            this.Name = "SummaryColumnEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Summary Columns";
            this.Load += new System.EventHandler(this.SummaryColumnEditor_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSeriesName;
        private System.Windows.Forms.CheckBox chkLapMin;
        private System.Windows.Forms.CheckBox chkLapMax;
        private System.Windows.Forms.CheckBox chkLapAvg;
        private System.Windows.Forms.CheckBox chkLapStdDev;
        private System.Windows.Forms.CheckBox chkSessionStdDev;
        private System.Windows.Forms.CheckBox chkSessionMin;
        private System.Windows.Forms.CheckBox chkSessionMax;
        private System.Windows.Forms.CheckBox chkSessionAvg;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkSessionMode;
        private System.Windows.Forms.CheckBox chkSessionDelta;
        private System.Windows.Forms.CheckBox chkLapMode;
        private System.Windows.Forms.CheckBox chkLapDelta;
    }
}