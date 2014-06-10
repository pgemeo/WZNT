namespace UI.Controls
{
    partial class UcGruArtAufEinzelnutzen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcGruArtAufEinzelnutzen));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.flowPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btEdit = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.flowPanelStandort = new System.Windows.Forms.FlowLayoutPanel();
            this.labelStandort = new System.Windows.Forms.Label();
            this.comboBoxStandort = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.flowPanelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.flowPanelStandort.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView2, "dataGridView2");
            this.dataGridView2.Name = "dataGridView2";
            // 
            // flowPanelButtons
            // 
            this.flowPanelButtons.Controls.Add(this.btEdit);
            this.flowPanelButtons.Controls.Add(this.btSave);
            this.flowPanelButtons.Controls.Add(this.btCancel);
            resources.ApplyResources(this.flowPanelButtons, "flowPanelButtons");
            this.flowPanelButtons.Name = "flowPanelButtons";
            // 
            // btEdit
            // 
            resources.ApplyResources(this.btEdit, "btEdit");
            this.btEdit.Name = "btEdit";
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            resources.ApplyResources(this.btSave, "btSave");
            this.btSave.Name = "btSave";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            resources.ApplyResources(this.btCancel, "btCancel");
            this.btCancel.Name = "btCancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // flowPanelStandort
            // 
            this.flowPanelStandort.Controls.Add(this.labelStandort);
            this.flowPanelStandort.Controls.Add(this.comboBoxStandort);
            resources.ApplyResources(this.flowPanelStandort, "flowPanelStandort");
            this.flowPanelStandort.Name = "flowPanelStandort";
            // 
            // labelStandort
            // 
            resources.ApplyResources(this.labelStandort, "labelStandort");
            this.labelStandort.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelStandort.Name = "labelStandort";
            // 
            // comboBoxStandort
            // 
            this.comboBoxStandort.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxStandort, "comboBoxStandort");
            this.comboBoxStandort.Name = "comboBoxStandort";
            // 
            // UcGruArtAufEinzelnutzen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPanelStandort);
            this.Controls.Add(this.flowPanelButtons);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UcGruArtAufEinzelnutzen";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.flowPanelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.flowPanelStandort.ResumeLayout(false);
            this.flowPanelStandort.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.FlowLayoutPanel flowPanelButtons;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.FlowLayoutPanel flowPanelStandort;
        private System.Windows.Forms.Label labelStandort;
        private System.Windows.Forms.ComboBox comboBoxStandort;
    }
}
