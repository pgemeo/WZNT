using Services.WZNTServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Services
{
    public class DbManager
    {
        //
        // GruArtAufEinzelnutzen
        //
        public static List<GruArtAufEinzelnutzen> ReadGruArtAufEinzelnutzenList()
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                return Client.ReadGruArtAufEinzelnutzenList().ToList();
            }
        }
        public static GruArtAufEinzelnutzen ReadGruArtAufEinzelnutzen(int Id)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                return Client.ReadGruArtAufEinzelnutzen(Id);
            }
        }
        public static void InsertGruArtAufEinzelnutzen(List<GruArtAufEinzelnutzen> List)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                Client.CreateGruArtAufEinzelnutzenList(List.ToArray());
            }
        }
        public static void UpdateGruArtAufEinzelnutzen(List<GruArtAufEinzelnutzen> List)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                Client.UpdateGruArtAufEinzelnutzenList(List.ToArray());
            }
        }
        public static void DeleteGruArtAufEinzelnutzen(List<GruArtAufEinzelnutzen> List)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                Client.DeleteGruArtAufEinzelnutzenList(List.ToArray());
            }
        }

        //
        // GruArtAufEinSprache
        //
        public static List<GruArtAufEinSprache> GetListGruArtAufEinSprache(GruArtAufEinzelnutzen GruArtAufEinzelnutzen)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                return Client.GetListGruArtAufEinSprache(GruArtAufEinzelnutzen).ToList();
            }
        }

        //
        //
        //
        public static List<GruSprachen> ReadGruSprachenList()
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                return Client.ReadGruSprachenList().ToList();
            }
        }
    }
}
