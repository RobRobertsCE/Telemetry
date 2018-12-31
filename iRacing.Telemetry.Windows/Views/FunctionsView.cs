using iRacing.Common.Models;
using iRacing.Telemetry.Data.Models;
using iRacing.Telemetry.Windows.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Views
{
    public partial class FunctionsView : Form
    {
        public class TelemetryFunction
        {
            public string Name { get; set; }
            public string FileName { get; set; }
            public string Body { get; set; }
            [JsonIgnore()]
            internal bool HasChanges
            {
                get
                {
                    return (State != Serialize());
                }
            }
            [JsonIgnore()]
            internal string State { get; set; }

            internal string Serialize()
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                var json = JsonConvert.SerializeObject(this, settings);
                return json;
            }
        }
        private class TelemetryFieldDisplayInfoView
        {
            public string Name { get { return DisplayInfo.Name.Replace($"{FieldDefinition.Group}.", ""); } }
            public IFieldDefinition FieldDefinition { get; set; }
            public FieldDisplayInfo DisplayInfo { get; set; }
        }
        private IList<TelemetryFieldDisplayInfoView> TelemetryFields { get; set; }
        private IList<TelemetryFieldDisplayInfoView> SessionFields { get; set; }
        private IList<TelemetryFieldDisplayInfoView> SetupFields { get; set; }
        private IList<TelemetryFunction> Functions { get; set; }
        private IList<string> FieldGroups { get; set; }

        public FunctionsView()
        {
            InitializeComponent();
        }

        private void FunctionsView_Load(object sender, EventArgs e)
        {
            try
            {
                IList<TelemetryFieldDisplayInfoView> fieldDefinitionList = LoadFieldDefinitionList();
                FieldGroups = LoadFieldGroups(fieldDefinitionList);
                TelemetryFields = LoadTelemetryFieldList(fieldDefinitionList);
                SessionFields = LoadSessionFieldList(fieldDefinitionList);
                SetupFields = LoadSetupFieldList(fieldDefinitionList);

                var fieldDisplayGroups = LoadFieldDisplayGroups(fieldDefinitionList);
                DisplayFieldDisplayGroups(fieldDisplayGroups);

                Functions = LoadFunctionList();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        private IList<TelemetryFieldDisplayInfoView> LoadFieldDefinitionList()
        {
            var fieldDefinitions = LoadFieldDefinitionFile();
            var displayInfos = LoadDisplayInfoFile();
            var fieldDefinitionDisplayInfos = new List<TelemetryFieldDisplayInfoView>();

            foreach (IFieldDefinition fieldDefinition in fieldDefinitions)
            {

                var displayInfo = GetDisplayInfo(fieldDefinition, displayInfos);

                var fieldDisplayInfo = new TelemetryFieldDisplayInfoView()
                {
                    FieldDefinition = fieldDefinition,
                    DisplayInfo = displayInfo
                };

                fieldDefinitionDisplayInfos.Add(fieldDisplayInfo);
            }

            return fieldDefinitionDisplayInfos;
        }
        // TODO: Move to FieldDefinitionRepo?
        protected virtual IList<IFieldDefinition> LoadFieldDefinitionFile()
        {
            IList<IFieldDefinition> fieldDefinitions = new List<IFieldDefinition>();

            var fieldListFile = Path.Combine(Constants.AppFolder, "FieldDefinitions.json");
            if (File.Exists(fieldListFile))
            {
                var json = File.ReadAllText(fieldListFile);
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                fieldDefinitions = JsonConvert.DeserializeObject<IList<IFieldDefinition>>(json, settings);
            }
            return fieldDefinitions;
        }
        protected virtual IList<FieldDisplayInfo> LoadDisplayInfoFile()
        {
            IList<FieldDisplayInfo> displayInfos = new List<FieldDisplayInfo>();

            var fieldListFile = Path.Combine(Constants.AppFolder, "DefaultDisplayInfo.json");
            if (File.Exists(fieldListFile))
            {
                var json = File.ReadAllText(fieldListFile);
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                displayInfos = JsonConvert.DeserializeObject<IList<FieldDisplayInfo>>(json, settings);
            }
            return displayInfos;
        }
        protected virtual IList<TelemetryFunction> LoadFunctionFile()
        {
            IList<TelemetryFunction> functions = new List<TelemetryFunction>();

            var fileName = Path.Combine(Constants.AppFolder, "Functions.json");
            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                functions = JsonConvert.DeserializeObject<IList<TelemetryFunction>>(json, settings);
            }
            if (functions.Count == 0)
                functions.Add(new TelemetryFunction() { Name = "Sample Function" });

            return functions;
        }

        private void SaveFunctionsFile(IList<TelemetryFunction> functions)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var json = JsonConvert.SerializeObject(functions, settings);
            var fieldListFile = Path.Combine(Constants.AppFolder, "Functions.json");
            if (File.Exists(fieldListFile))
            {
                File.Delete(fieldListFile);
            }
            File.WriteAllText(fieldListFile, json);
        }

        private FieldDisplayInfo GetDisplayInfo(IFieldDefinition fieldDefinition, IList<FieldDisplayInfo> displayInfos)
        {
            FieldDisplayInfo displayInfo = displayInfos.FirstOrDefault(d => d.Key == fieldDefinition.Name);

            if (displayInfo == null)
            {
                displayInfo = new FieldDisplayInfo()
                {
                    Name = (fieldDefinition.IsCalculated) ? $"{fieldDefinition.Group}.{fieldDefinition.Name}" : fieldDefinition.Name,
                    Key = fieldDefinition.Name,
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

                displayInfos.Add(displayInfo);
            }

            return displayInfo;
        }
        private IList<string> LoadFieldGroups(IList<TelemetryFieldDisplayInfoView> fieldDisplayInfos)
        {
            var groups = new List<string>();

            foreach (TelemetryFieldDisplayInfoView fieldDefinition in fieldDisplayInfos)
            {
                var groupName = (String.IsNullOrEmpty(fieldDefinition.FieldDefinition.Group) || fieldDefinition.FieldDefinition.Group == "-") ? "Telemetry" : fieldDefinition.FieldDefinition.Group;

                var telemetryGroup = groups.FirstOrDefault(g => g == groupName);

                if (telemetryGroup == null)
                {
                    groups.Add(telemetryGroup);
                }
            }

            groups.Add("Functions");

            return groups;
        }
        private IList<TelemetryFieldDisplayInfoView> LoadTelemetryFieldList(IList<TelemetryFieldDisplayInfoView> fieldDisplayInfos)
        {
            return fieldDisplayInfos.Where(f => f.FieldDefinition.Group == "Telemetry").ToList();
        }
        private IList<TelemetryFieldDisplayInfoView> LoadSessionFieldList(IList<TelemetryFieldDisplayInfoView> fieldDisplayInfos)
        {
            return fieldDisplayInfos.Where(f => f.FieldDefinition.Group == "Session").ToList();
        }
        private IList<TelemetryFieldDisplayInfoView> LoadSetupFieldList(IList<TelemetryFieldDisplayInfoView> fieldDisplayInfos)
        {
            return fieldDisplayInfos.Where(f => f.FieldDefinition.Group == "Session").ToList();
        }

        private IEnumerable<IGrouping<string, TelemetryFieldDisplayInfoView>> LoadFieldDisplayGroups(IList<TelemetryFieldDisplayInfoView> fieldDisplayInfos)
        {
            return fieldDisplayInfos.GroupBy(f => f.FieldDefinition.Group);
        }
        private void DisplayFieldDisplayGroups(IEnumerable<IGrouping<string, TelemetryFieldDisplayInfoView>> groups)
        {
            lstGroups.Items.Clear();
            lstGroups.DisplayMember = "Key";

            foreach (var group in groups)
            {
                lstGroups.Items.Add(group);
            }

            lstGroups.Items.Add("Functions");
        }

        private IList<TelemetryFunction> LoadFunctionList()
        {
            var functions = LoadFunctionFile();
            return functions;
        }

        //private void DisplayGroupsList(IList<string> groups)
        //{
        //    lstFields.Items.Clear();

        //    foreach (string group in groups)
        //    {
        //        lstFields.Items.Add(group);
        //    }
        //}

        private void lstGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayFieldsList(lstGroups.SelectedItem);
        }

        private void DisplayFieldsList(object selectedGroup)
        {
            lstFields.DataSource = null;
            lstFields.DisplayMember = "Name";

            if (selectedGroup != null)
            {
                if (selectedGroup is string)
                {
                    lstFields.DataSource = Functions;
                }
                else
                {
                    IGrouping<string, TelemetryFieldDisplayInfoView> groupFields = (IGrouping<string, TelemetryFieldDisplayInfoView>)selectedGroup;
                    lstFields.DataSource = groupFields.ToList();
                }
            }
        }

        #region functions
        private TelemetryFunction _currentFunction = null;

        private void btnNewFunction_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CloseFx(_currentFunction))
                {
                    // user cancelled
                    return;
                }

                _currentFunction = NewFx();

                DisplayFx(_currentFunction);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private bool CloseFx(TelemetryFunction fx)
        {
            var result = PromptToSaveChangesToFx(fx);

            if (result == DialogResult.Cancel)
                return false;
            else if (result == DialogResult.Yes)
                SaveFx(fx);

            ClearFx();

            return true;
        }
        private void UpdateFx(TelemetryFunction fx)
        {
            if (fx != null)
            {
                fx.Name = txtFxName.Text.Trim();
                fx.Body = txtFxBody.Text.Trim();
            }
        }
        private void SaveFx(TelemetryFunction fx)
        {
            UpdateFx(fx);

            var dialog = new SaveFileDialog()
            {
                InitialDirectory = Constants.FunctionsFolder,
                Filter = "Function Files (*.fx.json)|*.fx.json|All Files (*.*)|*.*",
                FilterIndex = 1,
                FileName = String.IsNullOrEmpty(fx.FileName) ? fx.Name : Path.GetFileName(fx.FileName)
            };

            var result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                fx.FileName = dialog.FileName;

                SaveCustomFunctionFile(fx);
            }
        }
        private void SaveCustomFunctionFile(TelemetryFunction fx)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var json = JsonConvert.SerializeObject(fx, settings);
            var fieldListFile = Path.Combine(Constants.AppFolder, fx.FileName);
            if (File.Exists(fieldListFile))
            {
                File.Delete(fieldListFile);
            }
            File.WriteAllText(fieldListFile, json);
            fx.State = fx.Serialize();
        }

        private void ClearFx()
        {
            txtFxName.Clear();
            txtFxBody.Clear();

            btnSaveFunction.Enabled = false;
            btnCloseFunction.Enabled = false;
            btnTestFunction.Enabled = false;
            btnAddField.Enabled = false;
            pnlFxDetails.Enabled = false;
            txtFxBody.Enabled = false;

            _currentFunction = null;
        }

        private TelemetryFunction NewFx()
        {
            var fx = new TelemetryFunction() { Name = "New Function" };
            fx.State = fx.Serialize();
            return fx;
        }

        private void DisplayFx(TelemetryFunction fx)
        {
            txtFxName.Text = fx.Name;
            txtFxBody.Text = fx.Body;

            btnSaveFunction.Enabled = true;
            btnCloseFunction.Enabled = true;
            btnTestFunction.Enabled = true;
            pnlFxDetails.Enabled = true;
            txtFxBody.Enabled = true;
        }

        private DialogResult PromptToSaveChangesToFx(TelemetryFunction fx)
        {
            if (_currentFunction == null)
            {
                return DialogResult.No;
            }

            UpdateFx(_currentFunction);

            if (!_currentFunction.HasChanges)
            {
                return DialogResult.No;
            }
            else
                return MessageBox.Show(this, $"Save changes to {fx.Name}?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        }

        private void btnOpenFunction_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CloseFx(_currentFunction))
                {
                    // user cancelled
                    return;
                }

                _currentFunction = OpenFx();

                DisplayFx(_currentFunction);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private TelemetryFunction OpenFx()
        {
            TelemetryFunction fx = null;

            var dialog = new OpenFileDialog()
            {
                InitialDirectory = Constants.FunctionsFolder,
                Filter = "Function Files (*.fx.json)|*.fx.json|All Files (*.*)|*.*",
                FilterIndex = 1
            };

            var result = dialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                fx = LoadCustomFunctionFile(dialog.FileName);
            }

            return fx;
        }

        private TelemetryFunction LoadCustomFunctionFile(string fileName)
        {
            TelemetryFunction fx = null;

            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                fx = JsonConvert.DeserializeObject<TelemetryFunction>(json, settings);
                fx.State = fx.Serialize();
            }

            return fx;
        }

        private void btnSaveFunction_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFx(_currentFunction);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnCloseFunction_Click(object sender, EventArgs e)
        {
            try
            {
                CloseFx(_currentFunction);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnTestFunction_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void lstFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddField.Enabled = (lstFields.SelectedItem != null);
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            InsertFieldToken();
        }
        private void lstFields_DoubleClick(object sender, EventArgs e)
        {
            InsertFieldToken();
        }
        private void InsertFieldToken()
        {
            if (_currentFunction == null)
                return;

            if (lstFields.SelectedItem != null)
            {
                var fieldDisplayInfo = (TelemetryFieldDisplayInfoView)lstFields.SelectedItem;
                var token = $"{fieldDisplayInfo.FieldDefinition.Group}.{fieldDisplayInfo.FieldDefinition.Name}";
                txtFxBody.SelectedText = "{" + token + "}";

                txtFxBody.Focus();
            }

        }
    }
}
