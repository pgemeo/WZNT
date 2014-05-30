using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services;
using Services.WZNTServices;
using System.Windows.Forms;

namespace UI.Shared
{
    public class DataBindingSource
    {
        public static void SetBindingSource(BindingSource Source, DataGridView GridView)
        {
            Source.DataSource = DbManager.GetListGruArtAufEinzelnutzen();
            GridView.Columns.Clear();
            DataGridViewColumn Column = new DataGridViewTextBoxColumn();
            Column.HeaderText = "Column 1";
            Column.DataPropertyName = "Aufgabe";
            GridView.Columns.Add(Column);
            GridView.DataSource = Source;
        }
    }
}
