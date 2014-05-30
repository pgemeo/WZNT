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
            List<GruArtAufEinzelnutzen> Elements = null;

            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                Elements = Client.GetListGruArtAufEinzelnutzen().ToList();
            }

            return Elements;
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
            List<GruArtAufEinSprache> Elements = null;

            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                Elements = Client.GetListGruArtAufEinSprache(GruArtAufEinzelnutzen).ToList();
            }

            return Elements;
        }
    }
}
