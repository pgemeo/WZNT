using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Services.WZNTServices;
using UI.Shared;
using UI.Workspaces;
using UI.ResFilesManagers;


namespace UI.Controls
{
    public partial class UcGruArtAufEinzelnutzen : UserControl
    {
        // 
        // Class Properties
        //
        protected WsGruArtAufEinzelnutzen Workspace;
        
        public UcGruArtAufEinzelnutzen()
        {
            InitializeComponent();
            BindEvents();
            InitializeWorkspace();
        }
        
        //
        // Buttons
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
                    InitializeWorkspace();
                }
            }
        }
        private void btEdit_Click(object sender, EventArgs e)
        {

        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            InitializeWorkspace();
        }

        // 
        // Workspace
        //

        protected void InitializeWorkspace()
        {
            Workspace = new WsGruArtAufEinzelnutzen();
            BindView();
        }
        
        private void BindView()
        {
            SetViewColumns();
            SetViewRows();
        }
        private void BindElementView(IList Data)
        {
            SetElementViewColumns();
            SetElementViewRows(Data);
        }
        private void ResetElementView()
        {
            BindElementView(null);
        }

        private void SetViewColumns()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<DataGridViewColumn> Columns = new List<DataGridViewColumn>();

            // Id
            DataGridViewColumn Column = new DataGridViewTextBoxColumn();
            {
                Column.HeaderText = "Id";
                Column.DataPropertyName = "Id";
                Column.Visible = false;
                Columns.Add(Column);
            }

            // Aufgabe
            Column = new DataGridViewTextBoxColumn();
            {
                Column.HeaderText = ResUcGruArtAufEinzelnutzen.Aufgabe; // Read Resource File
                Column.DataPropertyName = "Aufgabe";
                Column.Visible = true;
                Columns.Add(Column);
            }

            this.dataGridView1.Columns.AddRange(Columns.ToArray());
        }
        private void SetViewRows()
        {
            this.bindingSource1.DataSource = Workspace.Data;
            this.dataGridView1.DataSource = this.bindingSource1;
        }
        private void SetElementViewColumns()
        {
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.Columns.Clear();
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<DataGridViewColumn> Columns = new List<DataGridViewColumn>();

            // Id
            DataGridViewColumn Column = new DataGridViewTextBoxColumn();
            {
                Column.HeaderText = "Id";
                Column.DataPropertyName = "Id";
                Column.Visible = false;
                Columns.Add(Column);
            }
            
            // IdSprache
            Column = new DataGridViewTextBoxColumn();
            {
                Column.HeaderText = "IdSprache";
                Column.DataPropertyName = "IdSprache";
                Column.Visible = false;
                Columns.Add(Column);
            }

            // IdAufgabe
            Column = new DataGridViewTextBoxColumn();
            {
                Column.HeaderText = "IdAufgabe";
                Column.DataPropertyName = "IdAufgabe";
                Column.Visible = false;
                Columns.Add(Column);
            }

            // Sprache
            DataGridViewComboBoxColumn ComboBoxColumn = new DataGridViewComboBoxColumn();
            {
                ComboBoxColumn.FlatStyle = FlatStyle.Flat;
                ComboBoxColumn.DataSource = Workspace.GruSprachens;
                ComboBoxColumn.ValueMember = "Id";
                ComboBoxColumn.DisplayMember = "Sprache";
                ComboBoxColumn.HeaderText = "Sprache";
                ComboBoxColumn.DataPropertyName = "IdSprache";
                Columns.Add(ComboBoxColumn);
            }
                        
            // Uebersetzung
            Column = new DataGridViewTextBoxColumn();
            {
                Column.HeaderText = "Uebersetzung";
                Column.DataPropertyName = "Uebersetzung";
                Column.Visible = true;
                Columns.Add(Column);
            }
            
            this.dataGridView2.Columns.AddRange(Columns.ToArray());
        }
        private void SetElementViewRows(IList Data)
        {
            this.bindingSource2.DataSource = Data;
            this.dataGridView2.DataSource = this.bindingSource2;
        }

        private void BindEvents()
        {
            //
            // _DGVParent
            //
            this.dataGridView1.UserDeletingRow += DataGridView_UserDeletingRow;
            this.dataGridView1.RowEnter += _DGVParent_RowEnter;
            this.dataGridView1.Leave += _DGVParent_Leave;
            // !IMPORTANT: Cell Formatting is important for data binding
            this.dataGridView1.CellFormatting += DataGridView_CellFormatting;
            //
            // _DGVChildren
            //
            this.dataGridView2.UserDeletingRow += DataGridView_UserDeletingRow;
            this.dataGridView2.Leave += _DGVChildren_Leave;
            this.dataGridView2.CellBeginEdit += _DGVChildren_CellBeginEdit;
            // !IMPORTANT: Cell Formatting is important for data binding
            this.dataGridView2.CellFormatting += DataGridView_CellFormatting;
        }
        
        //
        // Handlers
        //

        private void UpdateDataGridViewChildrenOnBeginEdit(int RowIndex, DataGridViewRow ParentSelectedRow)
        {
            if (ParentSelectedRow != null)
            {
                if (Workspace.GetType() == typeof(WsGruArtAufEinzelnutzen))
                {
                    // Get Cell Values
                    int Id = (int)ParentSelectedRow.Cells[0].Value;
                    this.dataGridView2.Rows[RowIndex].Cells[2].Value = Convert.ToString(Id);
                }
            }
        }
        private void UpdateWorkspaceAfterLeaveDataGridViewChildren(DataGridViewRow GridView1SelectedRow)
        {
            if (GridView1SelectedRow != null)
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
        private IList GetChildren(DataGridViewRow GridView1SelectedRow)
        {
            // Get Cell Values
            int? Id = Convert.ToInt32(GridView1SelectedRow.Cells[0].Value);
            string Aufgabe = (string)GridView1SelectedRow.Cells[1].Value;
            // Parent Item
            Predicate<GruArtAufEinzelnutzen> Predicate = (GruArtAufEinzelnutzen X) => { return (Id > 0 && X.Id == Id) || X.Aufgabe == Aufgabe; };
            GruArtAufEinzelnutzen Instance = (GruArtAufEinzelnutzen)Workspace.FindElement(Predicate);
            // Child Items
            List<GruArtAufEinSprache> Collection = (Instance != null && Instance.GruArtAufEinSpraches != null) ?
                Instance.GruArtAufEinSpraches.ToList() : new List<GruArtAufEinSprache>();
            return Collection;
        }

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
        private void _DGVParent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView GridView = (DataGridView)sender;
            BindElementView(GetChildren(GridView.Rows[e.RowIndex]));
        }
        private void _DGVParent_Leave(object sender, EventArgs e)
        {
            // Check Dirty Row
            if (this.dataGridView1.IsCurrentRowDirty)
            {
                // End Edit
                this.dataGridView1.EndEdit();
            }
        }
        private void _DGVChildren_Leave(object sender, EventArgs e)
        {
            // Check Dirty Row
            if (this.dataGridView2.IsCurrentRowDirty)
            {
                // End Edit
                this.dataGridView2.EndEdit();
            }
            // Get Selected Row
            DataGridViewRow SelectedRow = (this.dataGridView1.SelectedRows.Count == 1) ?
                this.dataGridView1.SelectedRows[0] : (this.dataGridView1.CurrentCell != null) ?
                this.dataGridView1.CurrentCell.OwningRow : null;
            UpdateWorkspaceAfterLeaveDataGridViewChildren(SelectedRow);
        }
        private void _DGVChildren_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Get Selected Row
            DataGridViewRow GridView1SelectedRow = (this.dataGridView1.SelectedRows.Count == 1) ?
                this.dataGridView1.SelectedRows[0] : (this.dataGridView1.CurrentCell != null) ?
                this.dataGridView1.CurrentCell.OwningRow : null;
            UpdateDataGridViewChildrenOnBeginEdit(e.RowIndex, GridView1SelectedRow);
        }
    }
}
