using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using UI.Controls;

namespace UI.ResFilesManagers
{
    public class ResUcGruSysAPiJobl
    {
        protected static Type _Type = typeof(UcGruSysAPiJobl);
        protected static ResourceManager RManager = new ResourceManager(_Type);

        public static string JobId
        {
            get
            {
                return RManager.GetString("JobId");
            }
        }

        public static string JoebBezeichnung
        {
            get
            {
                return RManager.GetString("JoebBezeichnung");
            }
        }

        public static string StandortId
        {
            get
            {
                return RManager.GetString("StandortId");
            }
        }

        public static string ParameterDatei
        {
            get
            {
                return RManager.GetString("ParameterDatei");
            }
        }

        public static string AktivKZ
        {
            get
            {
                return RManager.GetString("AktivKZ");
            }
        }

    }
}
