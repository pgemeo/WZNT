using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using UI.Controls;

namespace UI.ResFilesManagers
{
    public class ResUcGruSysAPiJobSt
    {
        protected static Type _Type = typeof(UcGruSysAPiJobSt);
        protected static ResourceManager RManager = new ResourceManager(_Type);

        public static string JobId
        {
            get
            {
                return RManager.GetString("JobId");
            }
        }
        public static string Frequenz
        {
            get
            {
                return RManager.GetString("Frequenz");
            }
        }
        public static string Startdatum
        {
            get
            {
                return RManager.GetString("Startdatum");
            }
        }
        public static string Startzeit
        {
            get
            {
                return RManager.GetString("Startzeit");
            }
        }
        public static string AktivKZ
        {
            get
            {
                return RManager.GetString("AktivKZ");
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
