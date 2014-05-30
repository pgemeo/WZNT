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
        public static void SetBindingSource(BindingSource Source, DataGridView GridView, object Collection)
        {
            Type Type = Collection.GetType().GenericTypeArguments.Single();
            GridView.AutoGenerateColumns = false;
            GridView.Columns.Clear();
            Source.DataSource = Collection;
            List<DataGridViewColumn> Columns = BindingConfiguration.GetDataGridViewColumns(Type.Name);
            GridView.Columns.AddRange(Columns.ToArray());
            GridView.DataSource = Source;
        }
    }
}
