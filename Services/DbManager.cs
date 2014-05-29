using Services.WZNTServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DbManager
    {
        public static GruArtAufEinzelnutzen GetListGruArtAufEinzelnutzen()
        {
            GruArtAufEinzelnutzen element = null;

            using (WZNTServices.ServiceClient client = new ServiceClient())
            {
                string mydata = client.GetData(1);
                
                element = client.GetListGruArtAufEinzelnutzen();
            }

            /*
            // Create client
            ServiceClient WZNTServices = new ServiceClient();
            List<GruArtAufEinzelnutzen> Result = WZNTServices.GetListGruArtAufEinzelnutzen().ToList();
            // Close the client.
            WZNTServices.Close();
            return Result;
            */

            return element;
        }
    }
}
