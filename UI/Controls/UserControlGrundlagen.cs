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
    public partial class UserControlGrundlagen : UserControlTemplate
    {
        // 
        // Class Properties
        //
        protected WsInterfaceTemplate Workspace;
        protected TreeNode Node;

        public UserControlGrundlagen(TreeNode Node)
        {
            InitializeComponent();
            this.Node = Node;
            InitializeWorkspace();
        }
        
        // 
        // Workspace
        //
        protected void InitializeWorkspace()
        {
            if (Workspace != null)
            {
                // Clear Old
                Workspace.Clear();
            }
            // Create New
            Workspace = new WsInterfaceUnknown();
            if (Node != null)
            {
                switch (Node.Text)
                {
                    // Workspace
                    case "Aufgaben Einzelnutzen":
                        Workspace = new WsInterfaceGruArtAufEinzelnutzen(this.bindingSource1, this.dataGridView1, this.bindingSource2, this.dataGridView2);
                        break;
                }
            }
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
                if (Workspace.Save())
                {
                    MessageBox.Show("All changes have been saved!");
                    InitializeWorkspace();
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
            InitializeWorkspace();
        }
    }
}
