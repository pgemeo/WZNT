using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using UI.Controls;

namespace UI.ResFilesManagers
{
    public class ResUcGruArtAufEinzelnutzen
    {
        protected static Type _Type = typeof(UcGruArtAufEinzelnutzen);
        protected static ResourceManager RManager = new ResourceManager(_Type);
        
        public static string Aufgabe
        {
            get
            {
                return RManager.GetString("Aufgabe");
            }
        }
        public static string Sprache
        {
            get
            {
                return RManager.GetString("Sprache");
            }
        }
        public static string Uebersetzung
        {
            get
            {
                return RManager.GetString("Uebersetzung");
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
