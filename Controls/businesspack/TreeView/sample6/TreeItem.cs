using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample6
{
    public class TreeItem
    {
        public string Name { get; set; }
        public bool HasItems { get; set; }
        public List<TreeItem> Items { get; set; } = new List<TreeItem>();
    }
}