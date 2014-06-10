﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Services.WZNTServices;

namespace Services
{
    public class DbManager
    {
        //
        // GruArtAufEinzelnutzen
        //
        public static List<GruArtAufEinzelnutzen> ReadGruArtAufEinzelnutzenList(string StandortId)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                return Client.ReadGruArtAufEinzelnutzenList(StandortId).ToList();
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
                return Client.ReadGruArtAufEinSpracheList(GruArtAufEinzelnutzen).ToList();
            }
        }

        //
        // GruSprachen
        //
        public static List<GruSprachen> ReadGruSprachenList()
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                return Client.ReadGruSprachenList(null).ToList();
            }
        }

        //
        // GruSysStandort
        //
        public static List<GruSysStandort> ReadGruSysStandortList()
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                return Client.ReadGruSysStandortList().ToList();
            }
        }
        public static void InsertGruSysStandort(List<GruSysStandort> List)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                Client.CreateGruSysStandortList(List.ToArray());
            }
        }
        public static void UpdateGruSysStandort(List<GruSysStandort> List)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                Client.UpdateGruSysStandortList(List.ToArray());
            }
        }
        public static void DeleteGruSysStandort(List<GruSysStandort> List)
        {
            using (WZNTServices.ServiceClient Client = new ServiceClient())
            {
                Client.DeleteGruSysStandortList(List.ToArray());
            }
        }
    }
}
