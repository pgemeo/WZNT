using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form2 : Form
    {
        private ICollection<Services.WZNTServices.GruArtAufEinzelnutzen> mycollection = null;

        public Form2()
        {
            InitializeComponent();

            mycollection = Services.DbManager.ReadGruArtAufEinzelnutzenList(null);
            gruArtAufEinzelnutzenBindingSource.DataSource = mycollection;

            /*
            foreach (DataGridViewTextBoxColumn cols in gruArtAufEinzelnutzenBindingSource.DataMember)
            {
                cols.Visible = false;
            }
            */

            dataGridView1.DataSource = gruArtAufEinzelnutzenBindingSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICollection<Services.WZNTServices.GruArtAufEinzelnutzen> list = new List<Services.WZNTServices.GruArtAufEinzelnutzen>();
            Services.WZNTServices.GruArtAufEinzelnutzen model = new Services.WZNTServices.GruArtAufEinzelnutzen();
            model.Aufgabe = "Tiago";
            list.Add(model);
            gruArtAufEinzelnutzenBindingSource.DataSource = list;
        }
    }
}
