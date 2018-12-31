using iRacing.Common.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iRacing.Telemetry.Controls.Dialogs
{
    public partial class FieldSelectionDialog : Form
    {
        public IList<IFieldDefinition> Fields { get; set; }

        public IFieldDefinition Field { get; private set; }

        public FieldSelectionDialog()
        {
            InitializeComponent();
        }

        private void FieldSelectionDialog_Load(object sender, EventArgs e)
        {
            PopulateFieldList();
        }

        private void PopulateFieldList()
        {
            lvFields.Items.Clear();

            foreach (IFieldDefinition field in Fields)
            {
                var lvi = new ListViewItem(field.Name);
                lvi.SubItems.Add(field.DataTypeName);
                lvi.Tag = field;

                lvFields.Items.Add(lvi);
            }
        }

        private void lvFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = (lvFields.SelectedItems.Count > 0);

            if (lvFields.SelectedItems.Count > 0)
            {
                Field = (IFieldDefinition)lvFields.SelectedItems[0].Tag;
            }
            else
            {
                Field = null;
            }
        }
    }
}
