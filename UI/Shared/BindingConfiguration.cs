using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace UI.Shared
{
    public class BindingConfiguration
    {
        public static List<DataGridViewColumn> GetDataGridViewColumns(string ElementName)
        {
            List<DataGridViewColumn> Columns = new List<DataGridViewColumn>();
            string XmlConfiguration = Properties.Settings.Default.DataGridViewColumns;
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.LoadXml(XmlConfiguration);
            var XmlElements = XmlDoc.SelectNodes(string.Format("Elements/{0}/DataGridViewColumns/DataGridViewColumn", ElementName));
            foreach(XmlNode XNode in XmlElements)
            {
                DataGridViewColumn Column = new DataGridViewTextBoxColumn();
                Column.HeaderText = XNode["HeaderText"].InnerText;
                Column.DataPropertyName = XNode["DataPropertyName"].InnerText;
                Column.Visible = Convert.ToBoolean(XNode["Visible"].InnerText);
                Columns.Add(Column);
            }
            return Columns;
        }
    }
}
