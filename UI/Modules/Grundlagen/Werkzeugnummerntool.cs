using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Modules.Grundlagen
{
    public partial class Werkzeugnummerntool : Form
    {
        // 
        // constructor
        // 
        public Werkzeugnummerntool()
        {
            InitializeComponent();
            InitializeTopMenu();
            InitializeTree();
            InitializeEvents();
        }
        // 
        // dynamically create top menu
        // 
        protected void InitializeTopMenu()
        {
            // TopMenuStrip
            MenuStrip TopMenuStrip = new MenuStrip();
            TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            TopMenuStrip.Name = "TopMenuStrip";
            TopMenuStrip.TabIndex = 0;
            TopMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F);
            TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            TopMenuStrip.Name = "TopMenuStrip";
            TopMenuStrip.Size = new System.Drawing.Size(330, 24);
            TopMenuStrip.Margin = new Padding(0, 0, 30, 0);
            TopMenuStrip.TabIndex = 0;
            TopMenuStrip.Cursor = Cursors.Hand;
            // add child and put it into first index
            flPanelTop.Controls.Add(TopMenuStrip);
            flPanelTop.Controls.SetChildIndex(TopMenuStrip, 0);
            
            // Item1
            ToolStripMenuItem Item = new ToolStripMenuItem();
            Item.Text = "Anwendungen";
            
            ToolStripMenuItem SubItem = new ToolStripMenuItem();
            SubItem.Text = "Dateneingang";
            Item.DropDownItems.Add(SubItem);
            Item.DropDown.Cursor = Cursors.Hand;

            SubItem = new ToolStripMenuItem();
            SubItem.Text = "Drucklärung";
            Item.DropDownItems.Add(SubItem);
            Item.DropDown.Cursor = Cursors.Hand;

            TopMenuStrip.Items.Add(Item);
            
            // Item2
            Item = new ToolStripMenuItem();
            Item.Text = "Verwaltung";
            TopMenuStrip.Items.Add(Item);
            
            // Item3
            Item = new ToolStripMenuItem();
            Item.Text = "Extras";
            TopMenuStrip.Items.Add(Item);
        }
        // 
        // dynamically create tree nodes
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
        protected void InitializeEvents()
        {
            // Tree View
            this.treeView1.AfterSelect += TreeView1_AfterSelect;
            // TableLayoutPanel
            this.tableLayout1.CellPaint += TableLayoutPanel_CellPaint;
        }
        //
        // handle after select tree node event 
        //
        protected void TreeView1_AfterSelect(System.Object sender,
            System.Windows.Forms.TreeViewEventArgs e)
        {

            switch ((e.Action))
            {
                case TreeViewAction.ByKeyboard:
                    MessageBox.Show("You like the keyboard!");
                    break;
                case TreeViewAction.ByMouse:
                    Label Label = new Label();
                    Label.Text = "Artikel identisch";
                    int Row = this.tableLayout1.RowStyles.Add(new RowStyle());
                    this.tableLayout1.Controls.Add(Label, 1, Row);
                    break;
            }
        }
        //
        // handle cell paint event 
        //
        protected void TableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column == 0)
            {
                Graphics G = e.Graphics;
                Rectangle R = e.CellBounds;
                G.FillRectangle(Brushes.Gray, R);
            }
        }
    }
}
