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
        protected Type _Type = typeof(UcGruArtAufEinzelnutzen);
        
        public static string Aufgabe
        {
            get
            {
                ResourceManager RManager = new ResourceManager(typeof(UcGruArtAufEinzelnutzen));
                return RManager.GetString("Aufgabe");
            }
        }
    }
}
