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
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.TabIndex = 0;
            // Item1
            ToolStripMenuItem Item = new ToolStripMenuItem();
            Item.Text = "Anwendungen";
            
            ToolStripMenuItem SubItem = new ToolStripMenuItem();
            SubItem.Text = "Dateneingang";
            Item.DropDownItems.Add(SubItem);

            SubItem = new ToolStripMenuItem();
            SubItem.Text = "Drucklärung";
            Item.DropDownItems.Add(SubItem);

            this.TopMenuStrip.Items.Add(Item);
            // Item2
            Item = new ToolStripMenuItem();
            Item.Text = "Verwaltung";
            this.TopMenuStrip.Items.Add(Item);
            // Item3
            Item = new ToolStripMenuItem();
            Item.Text = "Extras";
            this.TopMenuStrip.Items.Add(Item);
        }
    }
}
