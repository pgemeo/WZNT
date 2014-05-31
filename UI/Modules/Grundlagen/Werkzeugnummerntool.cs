﻿using System;
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
        protected IList GridView1BaseCollection;
        protected IList GridView2BaseCollection;

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
            // Tree View
            this.treeView1.AfterSelect += TreeView1_AfterSelect;
            // Grid View
            this.dataGridView1.UserDeletingRow += DataGridView_UserDeletingRow;
            this.dataGridView1.RowEnter += DataGridView_RowEnter;
            // !IMPORTANT: Cell Formatting is important for data binding
            this.dataGridView1.CellFormatting += DataGridView_CellFormatting;
            this.dataGridView2.CellFormatting += DataGridView_CellFormatting;
        }
        
        // 
        // Grid View
        //
        protected void InitializeGridView1()
        {
            List<GruArtAufEinzelnutzen> Collection = DbManager.GetListGruArtAufEinzelnutzen();
            GridView1BaseCollection = Collection.Select(X => X).ToList();
            DataBindingSource.Set(this.gruArtAufEinzelnutzenBindingSource, this.dataGridView1, Collection);
        }
        protected void InitializeGridView2(DataGridViewRow GridView1SelectedRow)
        {
            if (GridView1SelectedRow != null && GridView1SelectedRow.Cells.Count > 0 && GridView1SelectedRow.Cells[0].Value != null)
            {
                int Id = (int)GridView1SelectedRow.Cells[0].Value;
                GruArtAufEinzelnutzen GruArtAufEinzelnutzen = new GruArtAufEinzelnutzen();
                GruArtAufEinzelnutzen.Id = Id;
                List<GruArtAufEinSprache> Collection = DbManager.GetListGruArtAufEinSprache(GruArtAufEinzelnutzen);
                GridView2BaseCollection = Collection;
                DataBindingSource.Set(this.gruArtAufEinSpracheBindingSource, this.dataGridView2, Collection);
            }
            else
            {
                ResetGridView2();
            }
        }
        protected void ResetGridView1()
        {
            GridView1BaseCollection = null;
            DataBindingSource.Set(this.gruArtAufEinzelnutzenBindingSource, this.dataGridView1, new List<GruArtAufEinzelnutzen>());
        }
        protected void ResetGridView2()
        {
            GridView2BaseCollection = null;
            DataBindingSource.Set(this.gruArtAufEinSpracheBindingSource, this.dataGridView2, new List<GruArtAufEinSprache>());
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
                    InitializeGridView1();
                    break;
            }
        }
        
        //
        // Handlers Grid View
        //
        private void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                DialogResult Dialog = MessageBox.Show("Are you sure you want to delete this row?", "Delete confirmation",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Dialog == DialogResult.No)
                    e.Cancel = true;
            }
        }
        private void DataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView GridView = (DataGridView)sender;
            InitializeGridView2(GridView.Rows[e.RowIndex]);
        }
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView DataGridView = (DataGridView)sender;
            if (DataGridView.Columns[e.ColumnIndex].DataPropertyName.Contains("."))
                e.Value = System.Web.UI.DataBinder.Eval(
                    DataGridView.Rows[e.RowIndex].DataBoundItem,
                    DataGridView.Columns[e.ColumnIndex].DataPropertyName);
        }

        //
        // Handlers Buttons
        //
        private void btSave_Click(object sender, EventArgs e)
        {
            BindingSource Source1 = (BindingSource)this.dataGridView1.DataSource;
            IList List1 = Source1.List;
            Type Type1 = GlobalFunctions.GetListElementsType(List1);
            Type BaseType1 = GlobalFunctions.GetListElementsType(GridView1BaseCollection);
            if (Type1 == typeof(GruArtAufEinzelnutzen) && Type1 == BaseType1)
            {
                List<GruArtAufEinzelnutzen> Elements1 = (List<GruArtAufEinzelnutzen>)List1;
                List<GruArtAufEinzelnutzen> BaseElements1 = (List<GruArtAufEinzelnutzen>)GridView1BaseCollection;
                
                // Finding Edit Elements
                List<GruArtAufEinzelnutzen> EditElements1 =
                    (from E in Elements1
                     join B in BaseElements1 on E.Id equals B.Id into Join
                     from I in Join
                     select E
                    ).ToList();
                MessageBox.Show(String.Format("Edit {0} element(s).", EditElements1.Count));
                
                // Finding Insert Elements
                List<GruArtAufEinzelnutzen> InsertElements1 = Elements1.Except(BaseElements1).ToList();
                MessageBox.Show(String.Format("Insert {0} element(s).", InsertElements1.Count));
            }
        }
        private void btNew_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.DataSource != null)
            {
                List<GruArtAufEinzelnutzen> DataSource = (List<GruArtAufEinzelnutzen>)this.dataGridView1.DataSource;
                DataSource.Add(new GruArtAufEinzelnutzen());
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = DataSource;
                this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.Rows.Count - 1;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0];
                this.dataGridView1.CurrentCell.OwningRow.ReadOnly = false;
                this.dataGridView1.BeginEdit(false);
            }
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection Cells = this.dataGridView1.SelectedCells;
            foreach (DataGridViewCell Cell in Cells)
            {
                this.dataGridView1.CurrentCell = Cell;
                Cell.OwningRow.ReadOnly = false;
                this.dataGridView1.BeginEdit(false);
            }
            DataGridViewSelectedRowCollection Rows = this.dataGridView1.SelectedRows;
            foreach (DataGridViewRow Row in Rows)
            {
                this.dataGridView1.CurrentCell = Row.Cells[0];
                Row.ReadOnly = false;
                this.dataGridView1.BeginEdit(false);
            }
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            InitializeGridView1();
        }
    }
}
