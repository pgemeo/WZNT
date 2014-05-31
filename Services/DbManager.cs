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
                return Client.GetListGruArtAufEinzelnutzen().ToList();
            }
        }
        public static GruArtAufEinzelnutzen GetGruArtAufEinzelnutzen(int Id)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                return Client.GetGruArtAufEinzelnutzen(Id);
            }
        }
        public static void InsertGruArtAufEinzelnutzen(GruArtAufEinzelnutzen Instance)
        {
            using (TransactionScope Transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    using (WZNTServices.ServiceClient Client = new ServiceClient())
                    {
                        Client.InsertGruArtAufEinzelnutzen(Instance);
                        Transaction.Complete();
                    }
                }
                catch (Exception ex)
                {
                    Transaction.Dispose();
                    throw ex;
                }
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
