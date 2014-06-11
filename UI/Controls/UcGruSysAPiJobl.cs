using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Shared;
using UI.Workspaces;
using UI.ResFilesManagers;
using Services;

namespace UI.Controls
{
    public partial class UcGruSysAPiJobl : UserControl
    {
        // 
        // Class Properties
        //
        protected WsGruSysAPiJobl Workspace;

        public UcGruSysAPiJobl()
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
            DialogResult Dialog = MessageBox.Show(ResUcGruSysAPiJobl.SaveConfirmMsg, ResUcGruSysAPiJobl.SaveConfirmTitle,
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Dialog == DialogResult.Yes)
            {
                if (Workspace.SaveChanges())
                {
                    MessageBox.Show(ResUcGruSysStandort.SaveSucceeded);
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
            Workspace = new WsGruSysAPiJobl();
            BindView();
        }

        private void BindView()
        {
            SetViewColumns();
            SetViewRows();
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

            // JobId
            Column = new DataGridViewTextBoxColumn();
            {
                Column.HeaderText = ResUcGruSysAPiJobl.JobId; // Read Resource File
                Column.DataPropertyName = "JOB_ID";
                Column.Visible = true;
                Columns.Add(Column);
            }

            // JoebBezeichnung
            Column = new DataGridViewTextBoxColumn();
            {
                Column.HeaderText = ResUcGruSysAPiJobl.JoebBezeichnung; // Read Resource File
                Column.DataPropertyName = "JOB_Bez";
                Column.Visible = true;
                Columns.Add(Column);
            }

            // StandortKz
            Column = new DataGridViewTextBoxColumn();
            {
                Column.HeaderText = ResUcGruSysAPiJobl.StandortId; // Read Resource File
                Column.DataPropertyName = "StandortKz";
                Column.Visible = true;
                Columns.Add(Column);
            }

            // ParameterDatei
            Column = new DataGridViewTextBoxColumn();
            {
                Column.HeaderText = ResUcGruSysAPiJobl.ParameterDatei; // Read Resource File
                Column.DataPropertyName = "ParameterDatei";
                Column.Visible = true;
                Columns.Add(Column);
            }

            // AktivKZ
            Column = new DataGridViewTextBoxColumn();
            {
                Column.HeaderText = ResUcGruSysAPiJobl.AktivKZ; // Read Resource File
                Column.DataPropertyName = "AktivKZ";
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

        private void BindEvents()
        {
            //
            // Buttons
            //
            this.btEdit.Click += btEdit_Click;
            this.btSave.Click += btSave_Click;
            this.btCancel.Click += btCancel_Click;
            
            //
            // _DGVParent
            //
            this.dataGridView1.UserDeletingRow += DataGridView_UserDeletingRow;
            this.dataGridView1.Leave += _DGVParent_Leave;
            // !IMPORTANT: Cell Formatting is important for data binding
            this.dataGridView1.CellFormatting += DataGridView_CellFormatting;
        }

        //
        // Handlers
        //
        
        private void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult Dialog = MessageBox.Show(ResUcGruSysAPiJobl.DeleteConfirmMsg, ResUcGruSysAPiJobl.DeleteConfirmTitle,
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
        private void _DGVParent_Leave(object sender, EventArgs e)
        {
            // Check Dirty Row
            if (this.dataGridView1.IsCurrentRowDirty)
            {
                // End Edit
                this.dataGridView1.EndEdit();
            }
        }
    }
}
