namespace iRacing.Telemetry.Controls.Views
{
    partial class MarginsEditor
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
            this.lblSeriesName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numRightMargin = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numLeftMargin = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numBottomMargin = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numTopMargin = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRightMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeftMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBottomMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTopMargin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSeriesName
            // 
            this.lblSeriesName.AutoSize = true;
            this.lblSeriesName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeriesName.Location = new System.Drawing.Point(11, 5);
            this.lblSeriesName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeriesName.Name = "lblSeriesName";
            this.lblSeriesName.Size = new System.Drawing.Size(103, 16);
            this.lblSeriesName.TabIndex = 32;
            this.lblSeriesName.Text = "[series name]";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 201);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 38);
            this.panel1.TabIndex = 31;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(189, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(48, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 127);
            this.groupBox1.TabIndex = 39;
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
            // MarginsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 239);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblSeriesName);
            this.Controls.Add(this.panel1);
            this.Name = "MarginsEditor";
            this.Text = "Margins";
            this.Load += new System.EventHandler(this.MarginsEditor_Load);
            this.panel1.ResumeLayout(false);
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

        private System.Windows.Forms.Label lblSeriesName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numRightMargin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numLeftMargin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numBottomMargin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numTopMargin;
        private System.Windows.Forms.Label label11;
    }
}