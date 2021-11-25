using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Model;
namespace Solution
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IActionMainController
    {
        public MainWindow()
        {
            InitializeComponent();
            Ini();
        }

        private void Ini() {
            var tr = new TreeviewManager(this.tree1,
                this.btnCreateNew,
                this.btnDelete,
                this.btnRename,
                this.txtRename, this);

            var list = new ObservableCollection<Node>();
           
            list.Add(new Node
            {
                Id = 1,
                IdParent = 0,
                Header = "node1"
            });
            list.Add(new Node
            {
                Id = 2,
                IdParent = 1,
                Header = "node2"
            });
            list.Add(new Node
            {
                Id = 3,
                IdParent = 1,
                Header = "node3"
            });

            list.Add(new Node
            {
                Id = 4,
                IdParent = 0,
                Header = "node11"
            });

            tr.Load(list);
        }

        public void CreateNew(Node node) { 
            //TODO
        }
        public void Delete(Node node) {
            //TODO
        }
        public void Rename(string newName, Node oldNode) {
            //TODO
        }

    }
}
