using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Services;
using Services.WZNTServices;

namespace UI.Shared
{
    public class DataBindingSource
    {
        public static void Set(BindingSource Source, DataGridView GridView, IList Collection)
        {
            if (Source != null && GridView != null && Collection != null)
            {
                GridView.AutoGenerateColumns = false;
                GridView.Columns.Clear();
                Source.DataSource = Collection;
                Type Type = GlobalFunctions.GetListElementsType(Collection);
                List<DataGridViewColumn> Columns = BindingConfiguration.GetDataGridViewColumns(Type.Name);
                GridView.Columns.AddRange(Columns.ToArray());
                GridView.DataSource = Source;
            }
            else
            {
                GridView.AutoGenerateColumns = false;
                GridView.Columns.Clear();
                Source.DataSource = Collection;
                GridView.DataSource = Source;
            }
        }
    }
}
