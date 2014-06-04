using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Interfaces;
using UI.Shared;

namespace UI.Controls
{
    public partial class UcGruArtAufEinzelnutzen : UserControl
    {
        // 
        // Class Properties
        //
        protected WsInterfaceTemplate IWorkspace;
        
        public UcGruArtAufEinzelnutzen()
        {
            InitializeComponent();
            LoadWorkspace();
        }
        
        // 
        // Workspace
        //
        protected void LoadWorkspace()
        {
            if (IWorkspace != null)
            {
                // Clear Old
                IWorkspace.Clear();
            }
            // Create New
            IWorkspace = new WsInterfaceGruArtAufEinzelnutzen(this.bindingSource1, this.dataGridView1, this.bindingSource2, this.dataGridView2);
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
                if (IWorkspace.Save())
                {
                    MessageBox.Show("All changes have been saved!");
                    LoadWorkspace();
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
            LoadWorkspace();
        }
    }
}
