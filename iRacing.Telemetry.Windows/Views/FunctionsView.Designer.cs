namespace iRacing.Telemetry.Windows.Views
{
    partial class FunctionsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionsView));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlFxDetails = new System.Windows.Forms.Panel();
            this.txtFxBody = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lstGroups = new System.Windows.Forms.ListBox();
            this.lstFields = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnNewFunction = new System.Windows.Forms.ToolStripButton();
            this.txtFxName = new System.Windows.Forms.TextBox();
            this.btnOpenFunction = new System.Windows.Forms.ToolStripButton();
            this.btnSaveFunction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseFunction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTestFunction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddField = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFxDetails.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 421);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtFxBody);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.pnlFxDetails);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(763, 396);
            this.panel3.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewFunction,
            this.btnOpenFunction,
            this.btnSaveFunction,
            this.toolStripSeparator1,
            this.btnCloseFunction,
            this.toolStripSeparator2,
            this.btnTestFunction,
            this.toolStripSeparator3,
            this.btnAddField});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(763, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 421);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 42);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(660, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pnlFxDetails
            // 
            this.pnlFxDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFxDetails.Controls.Add(this.txtFxName);
            this.pnlFxDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFxDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlFxDetails.Name = "pnlFxDetails";
            this.pnlFxDetails.Size = new System.Drawing.Size(763, 81);
            this.pnlFxDetails.TabIndex = 0;
            // 
            // txtFxBody
            // 
            this.txtFxBody.BackColor = System.Drawing.Color.White;
            this.txtFxBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFxBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFxBody.Enabled = false;
            this.txtFxBody.HideSelection = false;
            this.txtFxBody.Location = new System.Drawing.Point(0, 81);
            this.txtFxBody.Multiline = true;
            this.txtFxBody.Name = "txtFxBody";
            this.txtFxBody.Size = new System.Drawing.Size(763, 120);
            this.txtFxBody.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.splitter1);
            this.panel5.Controls.Add(this.lstFields);
            this.panel5.Controls.Add(this.lstGroups);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 201);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(763, 195);
            this.panel5.TabIndex = 2;
            // 
            // lstGroups
            // 
            this.lstGroups.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstGroups.FormattingEnabled = true;
            this.lstGroups.Location = new System.Drawing.Point(0, 0);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(247, 195);
            this.lstGroups.TabIndex = 0;
            this.lstGroups.SelectedIndexChanged += new System.EventHandler(this.lstGroups_SelectedIndexChanged);
            // 
            // lstFields
            // 
            this.lstFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFields.FormattingEnabled = true;
            this.lstFields.Location = new System.Drawing.Point(247, 0);
            this.lstFields.Name = "lstFields";
            this.lstFields.Size = new System.Drawing.Size(516, 195);
            this.lstFields.TabIndex = 1;
            this.lstFields.SelectedIndexChanged += new System.EventHandler(this.lstFields_SelectedIndexChanged);
            this.lstFields.DoubleClick += new System.EventHandler(this.lstFields_DoubleClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(247, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 195);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // btnNewFunction
            // 
            this.btnNewFunction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNewFunction.Image = ((System.Drawing.Image)(resources.GetObject("btnNewFunction.Image")));
            this.btnNewFunction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewFunction.Name = "btnNewFunction";
            this.btnNewFunction.Size = new System.Drawing.Size(35, 22);
            this.btnNewFunction.Text = "New";
            this.btnNewFunction.Click += new System.EventHandler(this.btnNewFunction_Click);
            // 
            // txtFxName
            // 
            this.txtFxName.Location = new System.Drawing.Point(11, 3);
            this.txtFxName.Name = "txtFxName";
            this.txtFxName.Size = new System.Drawing.Size(235, 20);
            this.txtFxName.TabIndex = 0;
            // 
            // btnOpenFunction
            // 
            this.btnOpenFunction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpenFunction.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFunction.Image")));
            this.btnOpenFunction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenFunction.Name = "btnOpenFunction";
            this.btnOpenFunction.Size = new System.Drawing.Size(40, 22);
            this.btnOpenFunction.Text = "Open";
            this.btnOpenFunction.Click += new System.EventHandler(this.btnOpenFunction_Click);
            // 
            // btnSaveFunction
            // 
            this.btnSaveFunction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSaveFunction.Enabled = false;
            this.btnSaveFunction.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveFunction.Image")));
            this.btnSaveFunction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveFunction.Name = "btnSaveFunction";
            this.btnSaveFunction.Size = new System.Drawing.Size(35, 22);
            this.btnSaveFunction.Text = "Save";
            this.btnSaveFunction.Click += new System.EventHandler(this.btnSaveFunction_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCloseFunction
            // 
            this.btnCloseFunction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCloseFunction.Enabled = false;
            this.btnCloseFunction.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseFunction.Image")));
            this.btnCloseFunction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseFunction.Name = "btnCloseFunction";
            this.btnCloseFunction.Size = new System.Drawing.Size(40, 22);
            this.btnCloseFunction.Text = "Close";
            this.btnCloseFunction.Click += new System.EventHandler(this.btnCloseFunction_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTestFunction
            // 
            this.btnTestFunction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTestFunction.Enabled = false;
            this.btnTestFunction.Image = ((System.Drawing.Image)(resources.GetObject("btnTestFunction.Image")));
            this.btnTestFunction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTestFunction.Name = "btnTestFunction";
            this.btnTestFunction.Size = new System.Drawing.Size(33, 22);
            this.btnTestFunction.Text = "Test";
            this.btnTestFunction.Click += new System.EventHandler(this.btnTestFunction_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddField
            // 
            this.btnAddField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddField.Enabled = false;
            this.btnAddField.Image = ((System.Drawing.Image)(resources.GetObject("btnAddField.Image")));
            this.btnAddField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(61, 22);
            this.btnAddField.Text = "Add Field";
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // FunctionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 463);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FunctionsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Functions";
            this.Load += new System.EventHandler(this.FunctionsView_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlFxDetails.ResumeLayout(false);
            this.pnlFxDetails.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtFxBody;
        private System.Windows.Forms.Panel pnlFxDetails;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListBox lstFields;
        private System.Windows.Forms.ListBox lstGroups;
        private System.Windows.Forms.TextBox txtFxName;
        private System.Windows.Forms.ToolStripButton btnNewFunction;
        private System.Windows.Forms.ToolStripButton btnOpenFunction;
        private System.Windows.Forms.ToolStripButton btnSaveFunction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCloseFunction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnTestFunction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAddField;
    }
}