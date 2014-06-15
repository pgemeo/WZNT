using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.WZNTServices;
using Services;
using UI.Shared;

namespace UI.Workspaces
{
    public class WsGruSysAPiJobSt
    {
        protected IList _List;
        protected IList _Original;

        public WsGruSysAPiJobSt()
        {
            this._List = DbManager.ReadGruSysAPiJobStList();
            this._Original = GlobalFunctions.CloneList(this._List);
        }

        public IList Data
        {
            get
            {
                return _List;
            }
        }

        protected IList Original
        {
            get
            {
                return _Original;
            }
        }

        protected IList Deleted
        {
            get
            {
                IList IList = null;
                List<GruSysAPiJobSt> Elements = (List<GruSysAPiJobSt>)Data;
                List<GruSysAPiJobSt> BaseElements = (List<GruSysAPiJobSt>)Original;
                // Finding Deletes
                IList =
                    (from B in BaseElements
                        join E in Elements on B.Id equals E.Id into Join
                        from J in Join.DefaultIfEmpty()
                        where J == null && B != null
                        select B
                    ).ToList();
                return IList;
            }
        }

        protected IList Added
        {
            get
            {
                IList IList = null;
                List<GruSysAPiJobSt> Elements = (List<GruSysAPiJobSt>)Data;
                List<GruSysAPiJobSt> BaseElements = (List<GruSysAPiJobSt>)Original;
                // Finding Inserts
                IList =
                    (from E in Elements
                        join B in BaseElements on E.Id equals B.Id into Join
                        from J in Join.DefaultIfEmpty()
                        where J == null && E != null && (E.Id == 0 && E.JobId != null)
                        select E
                    ).ToList();
                return IList;
            }
        }

        protected IList Modified
        {
            get
            {
                IList IList = null;
                List<GruSysAPiJobSt> Elements = (List<GruSysAPiJobSt>)Data;
                List<GruSysAPiJobSt> BaseElements = (List<GruSysAPiJobSt>)Original;
                // Finding Edits
                IList =
                    (from E in Elements
                        join B in BaseElements on E.Id equals B.Id into Join
                        from J in Join
                        select E
                    ).ToList();
                return IList;
            }
        }

        public bool SaveChanges()
        {
            bool ReturnValue = false;
            List<GruSysAPiJobSt> InsertElements = (List<GruSysAPiJobSt>)Added;
            List<GruSysAPiJobSt> DeleteElements = (List<GruSysAPiJobSt>)Deleted;
            List<GruSysAPiJobSt> EditElements = (List<GruSysAPiJobSt>)Modified;
            // Db Operations
            DbManager.InsertGruSysAPiJobSt(InsertElements);
            DbManager.DeleteGruSysAPiJobSt(DeleteElements);
            DbManager.UpdateGruSysAPiJobSt(EditElements);
            // Return
            ReturnValue = true;
            return ReturnValue;
        }

        public IList GruSysStandorts
        {
            get
            {
                IList List = DbManager.ReadGruSysStandortList();
                return List;
            }
        }

        public IList Frequenzs
        {
            get
            {
                IList List = new List<string>();
                List.Add("1h");
                List.Add("6h");
                List.Add("12h");
                List.Add("24h");
                List.Add("48h");
                List.Add("168h");
                return List;
            }
        }

        public IList JobIds
        {
            get
            {
                IList List = DbManager.ReadGruSysAPiJoblList();
                return List;
            }
        }
    }
}
