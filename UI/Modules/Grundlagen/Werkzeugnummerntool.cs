using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Shared;
using System.Collections;
using Services;
using Services.WZNTServices;

namespace UI.Modules.Grundlagen
{
    public partial class Werkzeugnummerntool : Form
    {
        // 
        // Class Properties
        //
        protected Workspace Workspace;

        // 
        // Workspace
        //
        protected void InitializeWorkspace(TreeNode Node)
        {
            Workspace = new Workspace(null);

            if (Node.Text.Equals("Aufgaben Einzelnutzen"))
            {
                // Workspace
                Workspace = new Workspace(typeof(GruArtAufEinzelnutzen));
            }
        }

        // 
        // Constructor
        // 
        public Werkzeugnummerntool()
        {
            InitializeComponent();
            InitializeTopMenu();
            InitializeTree();
            InitializeEvents();
        }

        // 
        // Top Menu
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
        // Tree View
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

        // 
        // Events
        //
        protected void InitializeEvents()
        {
            //
            // Tree View
            //
            this.treeView1.AfterSelect += TreeView1_AfterSelect;
            //
            // Grid View 1
            //
            this.dataGridView1.UserDeletingRow += DataGridView_UserDeletingRow;
            this.dataGridView1.RowEnter += DataGridView1_RowEnter;
            this.dataGridView1.Leave += DataGridView1_Leave;
            // !IMPORTANT: Cell Formatting is important for data binding
            this.dataGridView1.CellFormatting += DataGridView_CellFormatting;
            //
            // Grid View 2
            //
            this.dataGridView2.UserDeletingRow += DataGridView_UserDeletingRow;
            this.dataGridView2.Leave += DataGridView2_Leave;
            this.dataGridView2.CellBeginEdit += DataGridView2_CellBeginEdit;
            // !IMPORTANT: Cell Formatting is important for data binding
            this.dataGridView2.CellFormatting += DataGridView_CellFormatting;
            //
            // Form
            //
            this.Closing += Form_Closing;
        }

        // 
        // Grid View
        //
        protected void InitializeGridView1(TreeNode Node)
        {
            ResetGridView1();
            InitializeWorkspace(Node);
            // Binding
            DataBindingSource.Set(this.bindingSource1, this.dataGridView1, Workspace.List);
        }
        protected void InitializeGridView2(DataGridViewRow GridView1SelectedRow)
        {
            IList Collection = GetGridView2Collection(GridView1SelectedRow);
            // Binding
            DataBindingSource.Set(this.bindingSource2, this.dataGridView2, Collection);
        }
        protected void ResetGridView1()
        {
            this.dataGridView1.CurrentCell = null;
            Workspace = null;
            ResetGridView2();
        }
        protected void ResetGridView2()
        {
            DataBindingSource.Set(this.bindingSource2, this.dataGridView2, null);
        }
        
        protected IList GetGridView2Collection(DataGridViewRow GridView1SelectedRow)
        {
            if (Workspace.Type == typeof(GruArtAufEinzelnutzen))
            {
                // Get Cell Values
                int? Id = Convert.ToInt32(GridView1SelectedRow.Cells[0].Value);
                string Aufgabe = (string)GridView1SelectedRow.Cells[1].Value;
                // Parent Item
                Predicate<GruArtAufEinzelnutzen> Predicate = (GruArtAufEinzelnutzen X) => { return (Id > 0 && X.Id == Id) || X.Aufgabe == Aufgabe; };
                GruArtAufEinzelnutzen GruArtAufEinzelnutzen = (GruArtAufEinzelnutzen)Workspace.FindElement(Predicate);
                // Child Items
                List<GruArtAufEinSprache> Collection = (GruArtAufEinzelnutzen.GruArtAufEinSpraches != null) ?
                    GruArtAufEinzelnutzen.GruArtAufEinSpraches.ToList() : new List<GruArtAufEinSprache>();
                return Collection;
            }
            return null;
        }
        protected void UpdateWorkspaceAfterLeaveDataGridView2(DataGridViewRow GridView1SelectedRow)
        {
            if (GridView1SelectedRow != null)
            {
                if (Workspace.Type == typeof(GruArtAufEinzelnutzen))
                {
                    // Get Cell Values
                    int? Id = Convert.ToInt32(GridView1SelectedRow.Cells[0].Value);
                    string Aufgabe = (string)GridView1SelectedRow.Cells[1].Value;
                    // Workspace Item
                    Predicate<GruArtAufEinzelnutzen> Predicate = (GruArtAufEinzelnutzen X) => { return (Id > 0 && X.Id == Id) || X.Aufgabe == Aufgabe; };
                    GruArtAufEinzelnutzen Instance = (GruArtAufEinzelnutzen)Workspace.FindElement(Predicate);
                    // View Childs
                    BindingSource Source = (BindingSource)this.dataGridView2.DataSource;
                    List<GruArtAufEinSprache> ViewChilds = (List<GruArtAufEinSprache>)Source.List;
                    // Save Changes
                    Workspace.SaveElement(Instance, ViewChilds);
                }
            }
        }
        protected void UpdateDataGridView2OnBeginEdit(int RowIndex, DataGridViewRow GridView1SelectedRow) 
        {
            if (GridView1SelectedRow != null)
            {
                if (Workspace.Type == typeof(GruArtAufEinzelnutzen))
                {
                    // Get Cell Values
                    int Id = (int)GridView1SelectedRow.Cells[0].Value;
                    this.dataGridView2.Rows[RowIndex].Cells[2].Value = Convert.ToString(Id);
                }
            }
        }

        //
        // Handlers Tree
        //
        protected void TreeView1_AfterSelect(System.Object sender, TreeViewEventArgs e)
        {
            switch ((e.Action))
            {
                case TreeViewAction.ByKeyboard:
                    break;
                case TreeViewAction.ByMouse:
                    InitializeGridView1(e.Node);
                    break;
            }
        }

        //
        // Handlers Grid View 
        //
        private void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult Dialog = MessageBox.Show("Are you sure you want to delete this row?", "Delete confirmation",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Dialog == DialogResult.No)
                e.Cancel = true;
        }
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView DataGridView = (DataGridView)sender;
            if (DataGridView.Columns[e.ColumnIndex].DataPropertyName.Contains("."))
                e.Value = System.Web.UI.DataBinder.Eval(
                    DataGridView.Rows[e.RowIndex].DataBoundItem,
                    DataGridView.Columns[e.ColumnIndex].DataPropertyName);
        }
        private void DataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView GridView = (DataGridView)sender;
            InitializeGridView2(GridView.Rows[e.RowIndex]);
        }
        private void DataGridView1_Leave(object sender, EventArgs e)
        {
            // Check Dirty Row
            if (this.dataGridView1.IsCurrentRowDirty)
            {
                // End Edit
                this.dataGridView1.EndEdit();
            }
        }
        private void DataGridView2_Leave(object sender, EventArgs e)
        {
            // Check Dirty Row
            if (this.dataGridView2.IsCurrentRowDirty)
            {
                // End Edit
                this.dataGridView2.EndEdit();
            }
            // Get Selected Row
            DataGridViewRow GridView1SelectedRow = (this.dataGridView1.SelectedRows.Count == 1) ?
                this.dataGridView1.SelectedRows[0] : (this.dataGridView1.CurrentCell != null) ?
                this.dataGridView1.CurrentCell.OwningRow : null;
            UpdateWorkspaceAfterLeaveDataGridView2(GridView1SelectedRow);
        }
        private void DataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Get Selected Row
            DataGridViewRow GridView1SelectedRow = (this.dataGridView1.SelectedRows.Count == 1) ?
                this.dataGridView1.SelectedRows[0] : (this.dataGridView1.CurrentCell != null) ?
                this.dataGridView1.CurrentCell.OwningRow : null;
            UpdateDataGridView2OnBeginEdit(e.RowIndex, GridView1SelectedRow);
        }
        
        //
        // Handlers Buttons
        //
        private void btSave_Click(object sender, EventArgs e)
        {
            DialogResult Dialog = MessageBox.Show("Are you sure you want to save?", "Save confirmation",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Dialog == DialogResult.Yes)
            {
                if (Workspace.SaveChanges())
                {
                    MessageBox.Show("All changes have been saved!");
                }
            }
        }
        private void btNew_Click(object sender, EventArgs e)
        {
            
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            InitializeGridView1(treeView1.SelectedNode);
        }

        //
        // Handlers Form
        //
        private void Form_Closing(object sender, CancelEventArgs e)
        {
            this.Activate();
            this.Dispose();
            this.Close();
        }
    }
}
