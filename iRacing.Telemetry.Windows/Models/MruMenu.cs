using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace iRacing.Telemetry.Windows.Models
{
    public class MruMenu
    {
        #region constants
        public const int DefaultMaxItemCount = 10;
        #endregion

        #region events
        public event EventHandler<MruMenuItem> MruItemSelected;
        protected virtual void OnMruItemSelected(MruMenuItem item)
        {
            var handler = MruItemSelected;
            if (handler != null)
            {
                handler.Invoke(this, item);
            }
        }
        #endregion

        #region fields
        protected virtual string _fileName { get; set; }
        #endregion

        #region properties
        public int MaxItems { get; set; }
        public List<MruMenuItem> MenuItems { get; set; }
        #endregion

        #region ctor
        public MruMenu()
        {
            MaxItems = DefaultMaxItemCount;
            MenuItems = new List<MruMenuItem>();
        }
        #endregion

        #region public
        public void AddItem(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                return;

            MruMenuItem item = MenuItems.FirstOrDefault(m => m.FileName == fileName);

            if (item != null)
            {
                MenuItems.Remove(item);
            }
            else
            {
                item = new MruMenuItem()
                {
                    FileName = fileName,
                    Title = Path.GetFileNameWithoutExtension(fileName)
                };
            }

            MenuItems.Insert(0, item);

            if (MenuItems.Count > MaxItems)
            {
                MenuItems.RemoveAt(MenuItems.Count - 1);
            }

            Save();
        }

        public void LoadParentMenu(ToolStripMenuItem parent)
        {
            int insertIdx = 0;

            var mruPlaceholder = parent.DropDownItems.OfType<MruPlaceholderToolStripMenuItem>().FirstOrDefault();
            if (mruPlaceholder != null)
            {
                insertIdx = parent.DropDownItems.IndexOf(mruPlaceholder);
                parent.DropDownItems.Remove(mruPlaceholder);
            }

            var existingMenuItems = parent.DropDownItems.OfType<MruToolStripMenuItem>().ToList();
            var firstmenuItem = existingMenuItems.FirstOrDefault();
            if (firstmenuItem != null)
            {
                insertIdx = parent.DropDownItems.IndexOf(firstmenuItem);
            }
            else if (insertIdx == 0)
            {
                insertIdx = parent.DropDownItems.Count;
            }

            foreach (MruToolStripMenuItem existingMenuItem in existingMenuItems)
            {
                existingMenuItem.Click -= NewMenuItem_Click;
                parent.DropDownItems.Remove(existingMenuItem);
            }

            for (int i = 0; i < MenuItems.Count; i++)
            {
                MruMenuItem item = MenuItems[i];
                var newMenuItem = new MruToolStripMenuItem()
                {
                    Text = $"{i + 1}. {item.Title}",
                    Tag = item,
                    Enabled = item.IsEnabled
                };
                item.MenuItem = newMenuItem;
                newMenuItem.Click += NewMenuItem_Click;
                parent.DropDownItems.Insert(insertIdx + i, newMenuItem);
            }
        }

        public void SetMenuItemState(bool isEnabled)
        {
            foreach (MruMenuItem item in MenuItems)
            {
                item.IsEnabled = isEnabled;

                if (item.MenuItem != null)
                    item.MenuItem.Enabled = isEnabled;
            }
        }

        public void Save()
        {
            Save(_fileName);
        }

        public void Save(string fileName)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var json = JsonConvert.SerializeObject(this, settings);
            File.WriteAllText(fileName, json);
        }

        public static MruMenu Load(string fileName)
        {
            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                var mruList = JsonConvert.DeserializeObject<MruMenu>(json, settings);
                mruList._fileName = fileName;
                mruList.MaxItems = DefaultMaxItemCount;
                return mruList;
            }
            else
            {
                return new MruMenu() { MaxItems = DefaultMaxItemCount, _fileName = fileName };
            }

        }
        #endregion

        #region private
        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            var toolStripMenuItem = (MruToolStripMenuItem)sender;
            var mruItem = (MruMenuItem)toolStripMenuItem.Tag;

            OnMruItemSelected(mruItem);
        }
        #endregion
    }

    public class MruToolStripMenuItem : ToolStripMenuItem
    {

    }

    public class MruPlaceholderToolStripMenuItem : ToolStripMenuItem
    {

    }

    public class MruMenuItem
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        [JsonIgnore()]
        public bool IsEnabled { get; set; }
        [JsonIgnore()]
        public ToolStripMenuItem MenuItem { get; set; }
    }
}
