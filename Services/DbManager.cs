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
        // ArtAufEinzelnutzen
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
                        throw new Exception("Error on Inserting");
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
    }
}
