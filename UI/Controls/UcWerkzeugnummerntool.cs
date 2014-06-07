using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class UcWerkzeugnummerntool : UserControl
    {
        public UcWerkzeugnummerntool()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeTree();
            LoadContent();
        }

        //
        // Content
        //
        protected void LoadContent()
        {
            // Clear Content
            flowLayoutContent.Controls.Clear();
            // New Content
            if (this.treeView1.SelectedNode != null)
            {
                switch (this.treeView1.SelectedNode.Text)
                {
                    // User Control
                    case "Aufgaben Einzelnutzen":
                        UcGruArtAufEinzelnutzen Control = new UcGruArtAufEinzelnutzen();
                        flowLayoutContent.Controls.Add(Control);
                        break;
                }
            }
        }

        // 
        // Events
        //
        protected void InitializeEvents()
        {
            //
            // Tree View
            //
            this.treeView1.AfterSelect += TreeView1_AfterSelect;
        }

        //
        // Tree
        //
        protected void InitializeTree()
        {
            // top parent
            TreeNode Node = new TreeNode("Verwaltung");
            treeView1.Nodes.Add(Node);
            // level 1
            TreeNode Child1 = new TreeNode("Stammdaten");
            Node.Nodes.Add(Child1);
            // level 2
            TreeNode Child2 = new TreeNode("Artikel");
            Child1.Nodes.Add(Child2);
            // level 3
            TreeNode Child3 = new TreeNode("Aufgaben Einzelnutzen");
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode("Basisart");
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode("Druckvorlagen");
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode("Punktform");
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode("Druckverfahren");
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode("Farbtyp");
            Child2.Nodes.Add(Child3);
            // level 2
            Child2 = new TreeNode("Werkzeug");
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode("Registermarken");
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode("Druckkontrollelemente");
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode("Werkzeugtypen");
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode("MaterialKennlinie");
            Child2.Nodes.Add(Child3);
            // level 2
            Child2 = new TreeNode("Maschinen");
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode("Maschinengruppen");
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode("Maschinenpark");
            Child2.Nodes.Add(Child3);
            // level 2
            Child2 = new TreeNode("Programm");
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode("Abrechnungsgründe");
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode("Parameter");
            Child2.Nodes.Add(Child3);
            // level 2
            Child2 = new TreeNode("Export");
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode("Einzelnutzen");
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode("Werkzeuge");
            Child2.Nodes.Add(Child3);
            // level 1
            Child1 = new TreeNode("Systemparameter");
            Node.Nodes.Add(Child1);
            // level 2
            Child2 = new TreeNode("Standorte/Mand.");
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode("Standorte/Mandanten");
            Child2.Nodes.Add(Child3);
            // level 2
            Child2 = new TreeNode("DS-APi-Einstellungen");
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode("Artikel-Update");
            Child2.Nodes.Add(Child3);
            // level 4
            TreeNode Child4 = new TreeNode("Datenquellen");
            Child3.Nodes.Add(Child4);
            Child4 = new TreeNode("Jobsteuerung");
            Child3.Nodes.Add(Child4);
            // level 1
            Child1 = new TreeNode("Berechtigungen");
            Node.Nodes.Add(Child1);
        }
        protected void TreeView1_AfterSelect(System.Object sender, TreeViewEventArgs e)
        {
            switch ((e.Action))
            {
                case TreeViewAction.ByKeyboard:
                    break;
                case TreeViewAction.ByMouse:
                    LoadContent();
                    break;
            }
        }
    }
}
