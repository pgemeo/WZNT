using Services.WZNTServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Shared;
using UI.Workspaces;

namespace UI.Interfaces
{
    public class WsInterfaceGruArtAufEinzelnutzen : WsInterface
    {
        protected BindingSource _BSParent;
        protected BindingSource _BSChildren;
        protected DataGridView _DGVParent;
        protected DataGridView _DGVChildren;

        public WsInterfaceGruArtAufEinzelnutzen(BindingSource BSParent, DataGridView DGVParent, BindingSource BSChildren, DataGridView DGVChildren)
        {
            _Workspace = new WsGruArtAufEinzelnutzen();
            _BSParent = BSParent;
            _DGVParent = DGVParent;
            _BSChildren = BSChildren;
            _DGVChildren = DGVChildren;
            Initialize();
        }

        protected override void Initialize()
        {
            BindEvents();
            BindingToView();
        }
        public override void Clear()
        {
            ResetView();
            UnBindEvents();
        }

        private void BindingToView()
        {
            DataBindingSource.Set(_BSParent, _DGVParent, _Workspace.List);
        }
        private void BindingElementToView(IList List)
        {
            DataBindingSource.Set(_BSChildren, _DGVChildren, List);
        }
        private void ResetView()
        {
            if (_DGVParent != null)
            {
                _DGVParent.CurrentCell = null;
            }
            _Workspace = new WsUnknown();
            BindingToView();
            ResetElementView();
        }
        private void ResetElementView()
        {
            BindingElementToView(null);
        }
        
        private void BindEvents()
        {
            //
            // _DGVParent
            //
            this._DGVParent.UserDeletingRow += DataGridView_UserDeletingRow;
            this._DGVParent.RowEnter += _DGVParent_RowEnter;
            this._DGVParent.Leave += _DGVParent_Leave;
            // !IMPORTANT: Cell Formatting is important for data binding
            this._DGVParent.CellFormatting += DataGridView_CellFormatting;
            //
            // _DGVChildren
            //
            this._DGVChildren.UserDeletingRow += DataGridView_UserDeletingRow;
            this._DGVChildren.Leave += _DGVChildren_Leave;
            this._DGVChildren.CellBeginEdit += _DGVChildren_CellBeginEdit;
            // !IMPORTANT: Cell Formatting is important for data binding
            this._DGVChildren.CellFormatting += DataGridView_CellFormatting;
        }
        private void UnBindEvents()
        {
            //
            // _DGVParent
            //
            this._DGVParent.UserDeletingRow -= DataGridView_UserDeletingRow;
            this._DGVParent.RowEnter -= _DGVParent_RowEnter;
            this._DGVParent.Leave -= _DGVParent_Leave;
            // !IMPORTANT: Cell Formatting is important for data binding
            this._DGVParent.CellFormatting -= DataGridView_CellFormatting;
            //
            // _DGVChildren
            //
            this._DGVChildren.UserDeletingRow -= DataGridView_UserDeletingRow;
            this._DGVChildren.Leave -= _DGVChildren_Leave;
            this._DGVChildren.CellBeginEdit -= _DGVChildren_CellBeginEdit;
            // !IMPORTANT: Cell Formatting is important for data binding
            this._DGVChildren.CellFormatting -= DataGridView_CellFormatting;
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
                    this._DGVChildren.Rows[RowIndex].Cells[2].Value = Convert.ToString(Id);
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
                BindingSource Source = (BindingSource)this._DGVChildren.DataSource;
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
            BindingElementToView(GetChildren(GridView.Rows[e.RowIndex]));
        }
        private void _DGVParent_Leave(object sender, EventArgs e)
        {
            // Check Dirty Row
            if (this._DGVParent.IsCurrentRowDirty)
            {
                // End Edit
                this._DGVParent.EndEdit();
            }
        }
        private void _DGVChildren_Leave(object sender, EventArgs e)
        {
            // Check Dirty Row
            if (this._DGVChildren.IsCurrentRowDirty)
            {
                // End Edit
                this._DGVChildren.EndEdit();
            }
            // Get Selected Row
            DataGridViewRow SelectedRow = (this._DGVParent.SelectedRows.Count == 1) ?
                this._DGVParent.SelectedRows[0] : (this._DGVParent.CurrentCell != null) ?
                this._DGVParent.CurrentCell.OwningRow : null;
            UpdateWorkspaceAfterLeaveDataGridViewChildren(SelectedRow);
        }
        private void _DGVChildren_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Get Selected Row
            DataGridViewRow GridView1SelectedRow = (this._DGVParent.SelectedRows.Count == 1) ?
                this._DGVParent.SelectedRows[0] : (this._DGVParent.CurrentCell != null) ?
                this._DGVParent.CurrentCell.OwningRow : null;
            UpdateDataGridViewChildrenOnBeginEdit(e.RowIndex, GridView1SelectedRow);
        }
    }
}
