using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using UI.Controls;

namespace UI.ResFilesManagers
{
    public class ResUcGruSysStandort
    {
        protected static Type _Type = typeof(UcGruSysStandort);
        protected static ResourceManager RManager = new ResourceManager(_Type);

        public static string StandortId
        {
            get
            {
                return RManager.GetString("StandortId");
            }
        }
        public static string Standort
        {
            get
            {
                return RManager.GetString("Standort");
            }
        }
        public static string SaveConfirmMsg
        {
            get
            {
                return RManager.GetString("SaveConfirmMsg");
            }
        }
        public static string SaveConfirmTitle
        {
            get
            {
                return RManager.GetString("SaveConfirmTitle");
            }
        }
        public static string SaveSucceeded
        {
            get
            {
                return RManager.GetString("SaveSucceeded");
            }
        }
        public static string DeleteConfirmMsg
        {
            get
            {
                return RManager.GetString("DeleteConfirmMsg");
            }
        }
        public static string DeleteConfirmTitle
        {
            get
            {
                return RManager.GetString("DeleteConfirmTitle");
            }
        }
    }
}
