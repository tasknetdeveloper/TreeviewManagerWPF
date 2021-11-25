using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Model;
namespace Solution
{
    
    internal class TreeviewManager: ITreeviewManager
    {
        private TreeView tree=null;
        private Button btnCreateNew = null;
        private Button btnDelete = null;
        private Button btnRename = null;
        private TextBox txtRename = null;
        private ObservableCollection<Node> nodes = null;

        private TreeViewItem SelectedItem = null;
        private TreeViewItem ParentItem = new TreeViewItem();
        private IActionMainController iActionMainController;
        internal TreeviewManager(TreeView tree,
            Button btnCreateNew,
            Button btnDelete,
            Button btnRename,
            TextBox txtRename,

            IActionMainController iActionMainController, string root = "root") {
            this.tree = tree;
            this.btnCreateNew = btnCreateNew;
            this.btnDelete = btnDelete;
            this.btnRename = btnRename;
            this.txtRename = txtRename;

            this.iActionMainController = iActionMainController;
            ParentItem.Header = root;
            ParentItem.IsExpanded = true;
            this.tree.Items.Add(ParentItem);
            Event();
        }

        private void Event() {
            this.tree.SelectedItemChanged += (s, e) => {
                SelectedItem = (TreeViewItem)this.tree.SelectedItem;
            };

            btnCreateNew.PreviewMouseLeftButtonDown += (s, e) => {
                var node = new Node()
                {
                    Header = "New node",
                    Id = 111,
                    IdParent = 0
                };
                CreateNew("New node", node);                
            };
            btnDelete.PreviewMouseLeftButtonDown += (s, e) => {
                DeleteNode();
            };

            btnRename.PreviewMouseLeftButtonDown += (s, e) => {
                Rename(this.txtRename.Text);
            };
        }
        
        internal void Load(ObservableCollection<Node> list, int idParent = 0, TreeViewItem parent = null)
        {
            if (parent == null)
            {
                parent = ParentItem;
                nodes = list;
            }

            if (list != null && list.Count > 0)
            {
                var r = list.Where(y => y.IdParent == idParent).ToList();
                if (r == null || r.Count == 0) return;

                r.ForEach(x => {
                    var Child1Item = new TreeViewItem()
                    {
                        Header = x.Header,
                        Tag = x,
                        IsExpanded = true
                    };

                    parent.Items.Add(Child1Item);

                    idParent = x.Id;
                    Load(list, x.Id, Child1Item);
                });
            }
        }

        #region ITreeviewManager
        public void CreateNew(string Name, Node node)
        {            
            var Child1Item = new TreeViewItem()
            {
                Header = Name,
                Tag = node,
                IsExpanded = true
            };

            this.SelectedItem.Items.Add(Child1Item);
            //TODO
            this.iActionMainController.CreateNew(node);
        }

        public void DeleteNode()
        {
          //TODO
        }

        public void Rename(string newName)
        {
            var oldNode = (Node)this.SelectedItem.Tag;
            //TODO
            this.SelectedItem.Header = newName;
            this.iActionMainController.Rename(newName, oldNode);
        }
        #endregion
    }
}
