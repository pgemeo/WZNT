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
        public static List<GruArtAufEinzelnutzen> GetListGruArtAufEinzelnutzen()
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                return Client.GetGruArtAufEinzelnutzenList().ToList();
            }
        }
        public static GruArtAufEinzelnutzen GetGruArtAufEinzelnutzen(int Id)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                return Client.GetGruArtAufEinzelnutzen(Id);
            }
        }
        public static int InsertGruArtAufEinzelnutzen(GruArtAufEinzelnutzen Instance)
        {
            int Rows = 0;
            using (TransactionScope Transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (WZNTServices.ServiceClient Client = new ServiceClient())
                    {
                        Client.InsertGruArtAufEinzelnutzen(Instance);
                        Transaction.Complete();
                    }
                    return Rows;
                }
                catch (Exception ex)
                {
                    Transaction.Dispose();
                    throw ex;
                }
            }
        }
        public static int InsertGruArtAufEinzelnutzen(List<GruArtAufEinzelnutzen> List)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                Client.InsertGruArtAufEinzelnutzenList(List.ToArray());
                return 0;
            }
        }
        public static int UpdateGruArtAufEinzelnutzen(List<GruArtAufEinzelnutzen> List)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                //return Client.UpdateListOfGruArtAufEinzelnutzen(List.ToArray());
                return 0;
            }
        }
        public static int DeleteGruArtAufEinzelnutzen(List<GruArtAufEinzelnutzen> List)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                Client.RemoveGruArtAufEinzelnutzenList(List.ToArray());
                return 0;
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
    }
}
