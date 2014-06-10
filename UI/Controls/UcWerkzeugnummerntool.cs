using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.ResFilesManagers;

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
                // User Control
                if (this.treeView1.SelectedNode.Text.Equals(ResUcWerkzeugnummerntool.Node1111))
                {
                    UcGruArtAufEinzelnutzen Control = new UcGruArtAufEinzelnutzen();
                    flowLayoutContent.Controls.Add(Control);
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
            TreeNode Node = new TreeNode(ResUcWerkzeugnummerntool.Node1);
            treeView1.Nodes.Add(Node);
            // level 1
            TreeNode Child1 = new TreeNode(ResUcWerkzeugnummerntool.Node11);
            Node.Nodes.Add(Child1);
            // level 2
            TreeNode Child2 = new TreeNode(ResUcWerkzeugnummerntool.Node111);
            Child1.Nodes.Add(Child2);
            // level 3
            TreeNode Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1111);
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1112);
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1113);
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1114);
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1115);
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1116);
            Child2.Nodes.Add(Child3);
            // level 2
            Child2 = new TreeNode(ResUcWerkzeugnummerntool.Node112);
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1121);
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1122);
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1123);
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1124);
            Child2.Nodes.Add(Child3);
            // level 2
            Child2 = new TreeNode(ResUcWerkzeugnummerntool.Node113);
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1131);
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1132);
            Child2.Nodes.Add(Child3);
            // level 2
            Child2 = new TreeNode(ResUcWerkzeugnummerntool.Node114);
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1141);
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1142);
            Child2.Nodes.Add(Child3);
            // level 2
            Child2 = new TreeNode(ResUcWerkzeugnummerntool.Node115);
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1151);
            Child2.Nodes.Add(Child3);
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1152);
            Child2.Nodes.Add(Child3);
            // level 1
            Child1 = new TreeNode(ResUcWerkzeugnummerntool.Node12);
            Node.Nodes.Add(Child1);
            // level 2
            Child2 = new TreeNode(ResUcWerkzeugnummerntool.Node121);
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1211);
            Child2.Nodes.Add(Child3);
            // level 2
            Child2 = new TreeNode(ResUcWerkzeugnummerntool.Node122);
            Child1.Nodes.Add(Child2);
            // level 3
            Child3 = new TreeNode(ResUcWerkzeugnummerntool.Node1221);
            Child2.Nodes.Add(Child3);
            // level 4
            TreeNode Child4 = new TreeNode(ResUcWerkzeugnummerntool.Node12211);
            Child3.Nodes.Add(Child4);
            Child4 = new TreeNode(ResUcWerkzeugnummerntool.Node12212);
            Child3.Nodes.Add(Child4);
            // level 1
            Child1 = new TreeNode(ResUcWerkzeugnummerntool.Node13);
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
