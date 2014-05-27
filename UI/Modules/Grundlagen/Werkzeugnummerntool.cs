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
            // add child and put it into first index
            flPanelTop.Controls.Add(TopMenuStrip);
            flPanelTop.Controls.SetChildIndex(TopMenuStrip, 0);
            
            // Item1
            ToolStripMenuItem Item = new ToolStripMenuItem();
            Item.Text = "Anwendungen";
            
            ToolStripMenuItem SubItem = new ToolStripMenuItem();
            SubItem.Text = "Dateneingang";
            Item.DropDownItems.Add(SubItem);

            SubItem = new ToolStripMenuItem();
            SubItem.Text = "Drucklärung";
            Item.DropDownItems.Add(SubItem);

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
    }
}
