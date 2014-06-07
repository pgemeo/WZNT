using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using System.Threading;
using UI.Controls;
using UI.Shared;

namespace UI.Modules.Grundlagen
{
    public partial class Werkzeugnummerntool : Form
    {        
        // 
        // Constructor
        // 
        public Werkzeugnummerntool()
        {
            Initialize();
        }

        //
        // Initialize
        //
        protected void Initialize()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeTopMenu();
            LoadContent();
        }

        //
        // LoadContent
        //
        protected void LoadContent()
        {
            this.flowPanelContent.Controls.Clear();
            this.flowPanelContent.Controls.Add(new UcWerkzeugnummerntool());
        }

        //
        // Culture
        //
        protected void SetCulture(string Culture)
        {
            // Sets the UI culture.
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Culture);
            LoadContent();
        }
        
        // 
        // Menu
        // 
        protected void InitializeTopMenu()
        {
            // New
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
            flowPanelMenu.Controls.Add(TopMenuStrip);
            flowPanelMenu.Controls.SetChildIndex(TopMenuStrip, 0);

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
        // Events
        //
        protected void InitializeEvents()
        {
            //
            // Form
            //
            this.Closing += Form_Closing;
        }

        //
        // Form
        //
        private void Form_Closing(object sender, CancelEventArgs e)
        {
            this.Activate();
            this.Dispose();
            this.Close();
        }

        //
        // Flags
        //
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            // Sets the UI culture.
            SetCulture(AppConstants.K_LANGUAGE_FRENCH);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Sets the UI culture.
            SetCulture(AppConstants.K_LANGUAGE_GERMAN);
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // Sets the UI culture.
            SetCulture(AppConstants.K_LANGUAGE_RUSSIAN);
        }
    }
}
