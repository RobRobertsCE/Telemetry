using iRacing.Common.Models;
using iRacing.Telemetry.Data.Models;
using iRacing.Telemetry.Data.Ports;
using iRacing.Telemetry.Ports;
using iRacing.Telemetry.Windows.Models;
using iRacing.TelemetryFile.Ports;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Views
{
    public partial class FieldDefinitionsView : Form
    {
        #region fields
        private bool _loading = true;
        private string _currentDisplayInfoKey;
        private IFieldDefinitionRepository _fieldDefinitionRepository;
        private IFieldDisplayInfoRepository _displayFieldRepository;
        #endregion

        #region properties
        public bool IsEditMode { get; set; } = false;
        private IServiceProvider _serviceProvider = null;
        protected virtual IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceProvider == null)
                {
                    var services = new ServiceCollection();

                    services.AddTelemetryWindows();

                    _serviceProvider = services.BuildServiceProvider();
                }
                return _serviceProvider;
            }
        }
        public IList<string> SelectedFieldDefinitionKeys { get; set; } = new List<string>();
        public IList<IFieldDefinition> FieldDefinitions { get; set; } = new List<IFieldDefinition>();
        public IList<IFieldDisplayInfo> DisplayInfos { get; set; } = new List<IFieldDisplayInfo>();
        #endregion

        #region ctor/load
        public FieldDefinitionsView()
        {
            InitializeComponent();
        }
        public FieldDefinitionsView(IServiceProvider serviceProvider)
         : this(serviceProvider, false)
        {

        }
        public FieldDefinitionsView(IServiceProvider serviceProvider, bool editMode)
          : this()
        {
            _serviceProvider = (serviceProvider == null) ? throw new ArgumentNullException(nameof(serviceProvider)) : serviceProvider;
            IsEditMode = editMode;
        }

        private async void FieldDefinitionsView_Load(object sender, EventArgs e)
        {
            try
            {
                _fieldDefinitionRepository = ServiceProvider.GetService<IFieldDefinitionRepository>();
                _displayFieldRepository = ServiceProvider.GetService<IFieldDisplayInfoRepository>();

                DisplayConverters();
                FieldDefinitions = await LoadFieldDefinitionsAsync();
                DisplayInfos = await LoadDisplayInfosAsync();

                if (IsEditMode)
                {
                    chkSelectedFieldsOnly.CheckedChanged += ChkSelectedFieldsOnly_CheckedChanged;
                }
                else
                {
                    chkSelectedFieldsOnly.Checked = false;
                }

                lvFieldDefinitions.CheckBoxes = IsEditMode;
                chkSelectedFieldsOnly.Checked = IsEditMode;
                chkSelectedFieldsOnly.Visible = IsEditMode;

                DisplayFieldDefinitions(FieldDefinitions, IsEditMode);

                _loading = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        #region protected
        #region common
        protected virtual void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        protected virtual void DisplayConverters()
        {
            cboConversions.DisplayMember = "Name";
            cboConversions.DataSource = FieldConverterService.GetConverters();
        }
        #endregion

        #region display field definitions
        protected virtual void DisplayFieldDefinitions(IEnumerable<IFieldDefinition> fieldDefinitions)
        {
            DisplayFieldDefinitions(fieldDefinitions, chkSelectedFieldsOnly.Checked);
        }
        protected virtual void DisplayFieldDefinitions(IEnumerable<IFieldDefinition> fieldDefinitions, bool selectedOnly)
        {
            try
            {
                int selectedIndex = -1;

                lvFieldDefinitions.SuspendLayout();

                lvFieldDefinitions.Items.Clear();

                ListViewGroup telemetryGroup = null;

                foreach (IFieldDefinition fieldDefinition in fieldDefinitions)
                {
                    if (!selectedOnly || (selectedOnly && this.SelectedFieldDefinitionKeys.Contains(fieldDefinition.Key)))
                    {
                        var groupName = (String.IsNullOrEmpty(fieldDefinition.Group) || fieldDefinition.Group == "-") ? "Telemetry" : fieldDefinition.Group;

                        telemetryGroup = lvFieldDefinitions.Groups[groupName];

                        if (telemetryGroup == null)
                        {
                            telemetryGroup = new ListViewGroup(groupName, groupName);

                            lvFieldDefinitions.Groups.Add(telemetryGroup);
                        }

                        var lvi = new ListViewItem(fieldDefinition.Name);
                        lvi.Checked = this.SelectedFieldDefinitionKeys.Contains(fieldDefinition.Key);
                        lvi.SubItems.Add(fieldDefinition.DataTypeName);
                        lvi.SubItems.Add(fieldDefinition.Unit);
                        lvi.SubItems.Add(fieldDefinition.Size.ToString());

                        var displayInfo = GetDisplayInfo(fieldDefinition);
                        if (null != displayInfo)
                        {
                            lvi.SubItems.Add(displayInfo.Name);
                            Color lineColor = Color.FromArgb(
                                displayInfo.ColorA,
                                displayInfo.ColorR,
                                displayInfo.ColorG,
                                displayInfo.ColorB);
                            var subItem = lvi.SubItems.Add(lineColor.ToString());
                            subItem.BackColor = lineColor;
                            lvi.UseItemStyleForSubItems = false;
                        }
                        lvi.SubItems.Add(displayInfo.ConvertedUnit);

                        lvi.Tag = fieldDefinition;

                        telemetryGroup.Items.Add(lvi);
                        lvFieldDefinitions.Items.Add(lvi);

                        if (!String.IsNullOrEmpty(_currentDisplayInfoKey) && displayInfo.Key == _currentDisplayInfoKey)
                        {
                            selectedIndex = lvFieldDefinitions.Items.Count - 1;
                        }
                    }
                }

                UpdateFilterStatus(fieldDefinitions.Count());

                if (selectedIndex > -1)
                {
                    lvFieldDefinitions.SelectedIndices.Add(selectedIndex);
                    lvFieldDefinitions.EnsureVisible(selectedIndex);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                lvFieldDefinitions.ResumeLayout();
            }
        }
        #endregion

        #region load/save
        protected virtual async Task<IList<IFieldDefinition>> LoadFieldDefinitionsAsync()
        {
            return await Task.Run(() => _fieldDefinitionRepository.GetFieldDefinitionsAsync());
        }
        protected virtual async Task SaveFieldDefinitionFile(IList<IFieldDefinition> fieldDefinitions)
        {
            await Task.Run(() => _fieldDefinitionRepository.SaveFieldDefinitionsAsync(fieldDefinitions));
        }

        protected virtual async Task<IList<IFieldDisplayInfo>> LoadDisplayInfosAsync()
        {
            return await Task.Run(() => _displayFieldRepository.GetDisplayFieldsAsync());
        }
        protected virtual async Task SaveDisplayInfoFile(IList<IFieldDisplayInfo> displayFields)
        {
            await Task.Run(() => _displayFieldRepository.SaveDisplayFieldsAsync(displayFields));
        }
        #endregion

        #region search
        protected virtual void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PerformSearch();
        }

        protected virtual void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        protected virtual void PerformSearch()
        {
            try
            {
                var searchToken = txtSearch.Text.Trim();

                IEnumerable<IFieldDefinition> fieldDefinitions;

                if (String.IsNullOrEmpty(searchToken))
                {
                    fieldDefinitions = this.FieldDefinitions.AsEnumerable();
                }
                else
                {
                    fieldDefinitions = FieldDefinitions
                        .Where(f =>
                        f.Name.ToUpper().Contains(searchToken.ToUpper()) ||
                        f.Group.ToUpper().Contains(searchToken.ToUpper())
                        );
                }

                DisplayFieldDefinitions(fieldDefinitions);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        protected virtual void btnClearSearch_Click(object sender, EventArgs e)
        {
            ClearSearchFilter();
        }

        protected virtual void ClearSearchFilter()
        {
            txtSearch.Clear();
            DisplayFieldDefinitions(FieldDefinitions);
        }

        protected virtual void UpdateFilterStatus(int displayedCount)
        {
            lblFilterStatus.Text = $"Displaying {displayedCount} of {FieldDefinitions.Count} records.";
        }
        #endregion

        #region protected
        protected virtual void lvFieldDefinitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_currentDisplayInfoKey))
            {
                UpdateSelectedDisplayInfo(_currentDisplayInfoKey);
            }

            if (lvFieldDefinitions.SelectedItems.Count > 0)
            {
                var fieldDefinition = (IFieldDefinition)lvFieldDefinitions.SelectedItems[0].Tag;

                var displayInfo = GetDisplayInfo(fieldDefinition);

                PopulateDisplayInfoProperties(displayInfo);

                _currentDisplayInfoKey = displayInfo.Key;
            }
            else
            {
                ClearSelectedFieldDefinition();
            }
        }

        protected virtual IFieldDisplayInfo GetDisplayInfo(IFieldDefinition fieldDefinition)
        {
            IFieldDisplayInfo displayInfo = DisplayInfos.FirstOrDefault(d => d.Key == fieldDefinition.Key);

            if (fieldDefinition.Group.Contains("RightRear"))
            {
                Console.WriteLine(fieldDefinition.Group);
            }

            if (displayInfo == null)
            {
                displayInfo = new FieldDisplayInfo()
                {
                    Name = (fieldDefinition.IsCalculated) ? $"{fieldDefinition.Group}.{fieldDefinition.Name}" : fieldDefinition.Name,
                    Key = fieldDefinition.Key,
                    Thickness = 1,
                    RangeMax = 1.0F,
                    RangeMin = 0.0F,
                    Format = "#.#",
                    ColorA = 255,
                    ColorR = 255,
                    ColorG = 255,
                    ColorB = 255,
                    Unit = fieldDefinition.Unit
                };

                var converter = FieldConverterService.GetConverter(displayInfo.Unit);

                if (converter != null)
                {
                    displayInfo.Conversion = converter.UnitKey;
                    displayInfo.ConvertedUnit = converter.Unit;
                }

                DisplayInfos.Add(displayInfo);
            }

            return displayInfo;
        }

        protected virtual void PopulateDisplayInfoProperties(IFieldDisplayInfo displayInfo)
        {
            txtName.Text = displayInfo.Name;
            picColor.BackColor = Color.FromArgb(
                displayInfo.ColorA,
                displayInfo.ColorR,
                displayInfo.ColorG,
                displayInfo.ColorB);
            numThickness.Value = (decimal)displayInfo.Thickness;


            var displayUnit = displayInfo.ConvertedUnit != displayInfo.Unit ? displayInfo.Conversion : displayInfo.Unit;
            var converter = FieldConverterService.GetConverter(displayUnit);

            if (converter != null)
            {
                cboConversions.SelectedItem = converter;
                if (converter.UnitKey.StartsWith("irsdk"))
                {
                    txtMax.Clear();
                    txtMin.Clear();
                    txtFormat.Clear();
                }
                else
                {
                    txtMax.Text = displayInfo.RangeMax.ToString();
                    txtMin.Text = displayInfo.RangeMin.ToString();
                    txtFormat.Text = displayInfo.Format;
                }
                txtMax.Enabled = (!converter.UnitKey.StartsWith("irsdk"));
                txtMin.Enabled = (!converter.UnitKey.StartsWith("irsdk"));
                txtFormat.Enabled = (!converter.UnitKey.StartsWith("irsdk"));
            }
        }

        protected virtual void ClearSelectedFieldDefinition()
        {
            txtName.Clear();
            picColor.BackColor = Color.White;
            numThickness.Value = 1;
            txtMax.Text = "1";
            txtMin.Text = "0";
            txtFormat.Clear();
            cboConversions.SelectedIndex = 0;
            _currentDisplayInfoKey = String.Empty;
        }

        protected virtual void UpdateSelectedDisplayInfo(string key)
        {
            var displayInfo = DisplayInfos.FirstOrDefault(d => d.Key == key);

            displayInfo.Name = txtName.Text;
            displayInfo.ColorA = picColor.BackColor.A;
            displayInfo.ColorR = picColor.BackColor.R;
            displayInfo.ColorG = picColor.BackColor.G;
            displayInfo.ColorB = picColor.BackColor.B;
            displayInfo.Thickness = (float)numThickness.Value;
            if (String.IsNullOrEmpty(txtMax.Text))
            {
                displayInfo.RangeMax = 0;
            }
            else
            {
                displayInfo.RangeMax = float.Parse(txtMax.Text);
            }
            displayInfo.Thickness = (float)numThickness.Value;
            if (String.IsNullOrEmpty(txtMin.Text))
            {
                displayInfo.RangeMin = 0;
            }
            else
            {
                displayInfo.RangeMin = float.Parse(txtMin.Text);
            }
            displayInfo.Format = txtFormat.Text;
            if (cboConversions.SelectedItem != null)
            {
                FieldConverterBase converter = (FieldConverterBase)cboConversions.SelectedItem;
                displayInfo.Conversion = converter.UnitKey;
                displayInfo.ConvertedUnit = converter.Unit;
            }
            else
            {
                displayInfo.Conversion = "";
                displayInfo.ConvertedUnit = String.Empty;
            }
        }

        protected virtual void picColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog()
            {
                Color = picColor.BackColor,
                SolidColorOnly = true,
                AllowFullOpen = false,
                AnyColor = false,
                FullOpen = false
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                picColor.BackColor = dialog.Color;
            }
        }

        protected virtual void picColor_BackColorChanged(object sender, EventArgs e)
        {
            if (picColor.BackColor.IsKnownColor)
            {
                lblLineColor.Text = picColor.BackColor.ToArgb().ToString();
            }
            else
            {
                lblLineColor.Text = picColor.BackColor.ToString();
            }

            if (lvFieldDefinitions.SelectedItems.Count > 0)
            {
                var lvi = lvFieldDefinitions.SelectedItems[0];

                if (lvi != null)
                {
                    lvi.SubItems[5].BackColor = picColor.BackColor;
                    lvi.SubItems[5].Text = picColor.BackColor.ToString();
                    lvi.UseItemStyleForSubItems = false;
                }
            }
        }

        protected virtual async void btnSave_Click(object sender, EventArgs e)
        {
            await ApplyChanges(false);
            DialogResult = DialogResult.OK;
        }

        protected virtual async void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                await ApplyChanges(IsEditMode);

                DisplayFieldDefinitions(FieldDefinitions);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        protected virtual async Task ApplyChanges(bool editMode)
        {
            if (!String.IsNullOrEmpty(_currentDisplayInfoKey))
            {
                UpdateSelectedDisplayInfo(_currentDisplayInfoKey);
            }

            await SaveDisplayInfoFile(DisplayInfos);
            await SaveFieldDefinitionFile(FieldDefinitions);
        }
        #endregion

        #region import
        protected virtual async void btnImport_Click(object sender, EventArgs e)
        {
            await ImportTelemetryFileFields();
        }
        protected virtual async Task ImportTelemetryFileFields()
        {
            try
            {
                var fileName = String.Empty;

                var dialog = new OpenFileDialog()
                {
                    InitialDirectory = Constants.TelemetryFolder,
                    Filter = "Atlas Telemetry Files (*.ibt)|*.ibt|All Files (*.*)|*.*",
                    FilterIndex = 1
                };

                var result = dialog.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    fileName = dialog.FileName;

                    var fileReader = ServiceProvider.GetRequiredService<IIbtFileReader>();
                    var bytes = await fileReader.ReadTelemetryDataAsync(fileName);
                    var parser = ServiceProvider.GetRequiredService<IIbtSessionParser>();
                    ISessionData session = await parser.ParseTelemetrySessionAsync(bytes);

                    // TelemetryFields
                    FieldDefinitions = MergeTelemetryFields(session.Fields);

                    ISessionDictionaries sessionInfo = session.SessionInfo;

                    var telemetryReader = ServiceProvider.GetRequiredService<ISessionParser>();

                    // Session fields
                    var sessionFieldDefinitions = await telemetryReader.BuildFieldDefinitionListAsync(sessionInfo.root);

                    ((List<IFieldDefinition>)FieldDefinitions).AddRange(sessionFieldDefinitions);

                    FieldDefinitions = MergeTelemetryFields(sessionFieldDefinitions);

                    DisplayFieldDefinitions(FieldDefinitions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
        protected virtual IList<IFieldDefinition> MergeTelemetryFields(IList<IFieldDefinition> importedFieldDefinitions)
        {
            var updated = new List<IFieldDefinition>();
            var removed = new List<IFieldDefinition>();
            var current = FieldDefinitions.ToList();
            var promptMergeAll = false;
            var mergeAll = false;

            foreach (IFieldDefinition importedFieldDefinition in importedFieldDefinitions)
            {
                var existing = current.FirstOrDefault(f => f.Name == importedFieldDefinition.Name);

                if (existing != null)
                {
                    if ((!promptMergeAll && !mergeAll) || (promptMergeAll && !mergeAll))
                    {
                        var dialogResult = MessageBox.Show(this, $"Telemetry field definition list already contains an entry for '{importedFieldDefinition.Name}'. Overwrite?", "Duplicate Telemetry Entry", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes)
                        {
                            removed.Add(existing);
                            updated.Add(importedFieldDefinition);

                            if (!promptMergeAll)
                            {
                                var mergeAllDialogResult = MessageBox.Show(this, "Overwrite all Telemetry duplicates?", "Duplicate Telemetry Entry", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                                if (mergeAllDialogResult == DialogResult.Cancel)
                                {
                                    return FieldDefinitions;
                                }
                                else
                                {
                                    mergeAll = (mergeAllDialogResult == DialogResult.Yes);
                                    promptMergeAll = true;
                                }
                            }
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            return FieldDefinitions;
                        }
                    }
                    else if (promptMergeAll && mergeAll)
                    {
                        // merge all
                        removed.Add(existing);
                        updated.Add(importedFieldDefinition);
                    }
                }
                else
                {
                    updated.Add(importedFieldDefinition);
                }
            }

            ((List<IFieldDefinition>)FieldDefinitions).RemoveAll(i => removed.Any(r => r.Name == i.Name));
            ((List<IFieldDefinition>)FieldDefinitions).AddRange(updated);

            MessageBox.Show($"{importedFieldDefinitions.Count} records imported. {updated.Count - removed.Count} records added, {removed.Count} records merged, {importedFieldDefinitions.Count - updated.Count} records skipped.");

            return FieldDefinitions;
        }
        #endregion
        #endregion

        #region private
        private void ChkSelectedFieldsOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (_loading)
                return;

            PerformSearch();
            //DisplayFieldDefinitions(FieldDefinitions, chkSelectedFieldsOnly.Checked);
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            try
            {
                var promptResult = MessageBox.Show(this, "Delete all mappings?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (promptResult == DialogResult.OK)
                {
                    FieldDefinitions = new List<IFieldDefinition>();
                    DisplayInfos = new List<IFieldDisplayInfo>();

                    DisplayFieldDefinitions(FieldDefinitions);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        #endregion

        private void lvFieldDefinitions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var fieldDefinition = (IFieldDefinition)lvFieldDefinitions.Items[e.Index].Tag;

            if (e.NewValue == CheckState.Checked)
            {
                if (!SelectedFieldDefinitionKeys.Contains(fieldDefinition.Key))
                    SelectedFieldDefinitionKeys.Add(fieldDefinition.Key);

                lvFieldDefinitions.SelectedItems.Clear();

                lvFieldDefinitions.Items[e.Index].Selected = true;
            }
            else
            {
                if (SelectedFieldDefinitionKeys.Contains(fieldDefinition.Key))
                    SelectedFieldDefinitionKeys.Remove(fieldDefinition.Key);
            }

        }
    }
}
