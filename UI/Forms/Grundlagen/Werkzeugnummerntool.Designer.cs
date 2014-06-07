using System.Windows.Forms;
namespace UI.Modules.Grundlagen
{
    partial class Werkzeugnummerntool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Werkzeugnummerntool));
            this.flowPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureFlag1 = new System.Windows.Forms.PictureBox();
            this.pictureFlag2 = new System.Windows.Forms.PictureBox();
            this.pictureFlag3 = new System.Windows.Forms.PictureBox();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.pictureConfigs = new System.Windows.Forms.PictureBox();
            this.pictureSync = new System.Windows.Forms.PictureBox();
            this.pictureHelp = new System.Windows.Forms.PictureBox();
            this.pictureExit = new System.Windows.Forms.PictureBox();
            this.pictureUndo = new System.Windows.Forms.PictureBox();
            this.flowPanelContent = new System.Windows.Forms.FlowLayoutPanel();
            this.flowPanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag3)).BeginInit();
            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureConfigs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUndo)).BeginInit();
            this.SuspendLayout();
            // 
            // flowPanelMenu
            // 
            this.flowPanelMenu.Controls.Add(this.pictureFlag1);
            this.flowPanelMenu.Controls.Add(this.pictureFlag2);
            this.flowPanelMenu.Controls.Add(this.pictureFlag3);
            resources.ApplyResources(this.flowPanelMenu, "flowPanelMenu");
            this.flowPanelMenu.Name = "flowPanelMenu";
            // 
            // pictureFlag1
            // 
            this.pictureFlag1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureFlag1.Image = global::UI.Properties.Resources.flag_germany;
            resources.ApplyResources(this.pictureFlag1, "pictureFlag1");
            this.pictureFlag1.Name = "pictureFlag1";
            this.pictureFlag1.TabStop = false;
            this.pictureFlag1.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureFlag2
            // 
            this.pictureFlag2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureFlag2.Image = global::UI.Properties.Resources.flag_france;
            resources.ApplyResources(this.pictureFlag2, "pictureFlag2");
            this.pictureFlag2.Name = "pictureFlag2";
            this.pictureFlag2.TabStop = false;
            this.pictureFlag2.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureFlag3
            // 
            this.pictureFlag3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureFlag3.Image = global::UI.Properties.Resources.flag_russia;
            resources.ApplyResources(this.pictureFlag3, "pictureFlag3");
            this.pictureFlag3.Name = "pictureFlag3";
            this.pictureFlag3.TabStop = false;
            this.pictureFlag3.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // panelToolbar
            // 
            this.panelToolbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelToolbar.Controls.Add(this.pictureConfigs);
            this.panelToolbar.Controls.Add(this.pictureSync);
            this.panelToolbar.Controls.Add(this.pictureHelp);
            this.panelToolbar.Controls.Add(this.pictureExit);
            this.panelToolbar.Controls.Add(this.pictureUndo);
            resources.ApplyResources(this.panelToolbar, "panelToolbar");
            this.panelToolbar.Name = "panelToolbar";
            // 
            // pictureConfigs
            // 
            this.pictureConfigs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureConfigs.Image = global::UI.Properties.Resources.preferences;
            resources.ApplyResources(this.pictureConfigs, "pictureConfigs");
            this.pictureConfigs.Name = "pictureConfigs";
            this.pictureConfigs.TabStop = false;
            // 
            // pictureSync
            // 
            this.pictureSync.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureSync.Image = global::UI.Properties.Resources.refresh;
            resources.ApplyResources(this.pictureSync, "pictureSync");
            this.pictureSync.Name = "pictureSync";
            this.pictureSync.TabStop = false;
            // 
            // pictureHelp
            // 
            this.pictureHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureHelp.Image = global::UI.Properties.Resources.help;
            resources.ApplyResources(this.pictureHelp, "pictureHelp");
            this.pictureHelp.Name = "pictureHelp";
            this.pictureHelp.TabStop = false;
            // 
            // pictureExit
            // 
            this.pictureExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureExit.Image = global::UI.Properties.Resources.exit;
            resources.ApplyResources(this.pictureExit, "pictureExit");
            this.pictureExit.Name = "pictureExit";
            this.pictureExit.TabStop = false;
            // 
            // pictureUndo
            // 
            this.pictureUndo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureUndo.Image = global::UI.Properties.Resources.undo;
            resources.ApplyResources(this.pictureUndo, "pictureUndo");
            this.pictureUndo.Name = "pictureUndo";
            this.pictureUndo.TabStop = false;
            // 
            // flowPanelContent
            // 
            resources.ApplyResources(this.flowPanelContent, "flowPanelContent");
            this.flowPanelContent.Name = "flowPanelContent";
            // 
            // Werkzeugnummerntool
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPanelContent);
            this.Controls.Add(this.panelToolbar);
            this.Controls.Add(this.flowPanelMenu);
            this.Name = "Werkzeugnummerntool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.flowPanelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlag3)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureConfigs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUndo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPanelMenu;
        private System.Windows.Forms.PictureBox pictureSync;
        private System.Windows.Forms.PictureBox pictureConfigs;
        private System.Windows.Forms.PictureBox pictureFlag3;
        private System.Windows.Forms.PictureBox pictureFlag2;
        private System.Windows.Forms.PictureBox pictureFlag1;
        private System.Windows.Forms.PictureBox pictureExit;
        private System.Windows.Forms.PictureBox pictureUndo;
        private System.Windows.Forms.PictureBox pictureHelp;
        private System.Windows.Forms.Panel panelToolbar;
        private FlowLayoutPanel flowPanelContent;
    }
}