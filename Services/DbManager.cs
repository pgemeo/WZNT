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
        public static List<GruArtAufEinzelnutzen> GetListGruArtAufEinzelnutzen()
        {
            List<GruArtAufEinzelnutzen> Elements = null;

            using (WZNTServices.ServiceClient client = new ServiceClient())
            {
                Elements = client.GetListGruArtAufEinzelnutzen().ToList();
            }

            return Elements;
        }
    }
}
