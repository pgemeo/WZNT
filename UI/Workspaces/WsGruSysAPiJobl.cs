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
    public class WsGruSysAPiJobl
    {
        protected IList _List;
        protected IList _Original;

        public WsGruSysAPiJobl()
        {
            this._List = null;
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
                List<GruSysStandort> Elements = (List<GruSysStandort>)Data;
                List<GruSysStandort> BaseElements = (List<GruSysStandort>)Original;
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
                List<GruSysStandort> Elements = (List<GruSysStandort>)Data;
                List<GruSysStandort> BaseElements = (List<GruSysStandort>)Original;
                // Finding Inserts
                IList =
                    (from E in Elements
                        join B in BaseElements on E.Id equals B.Id into Join
                        from J in Join.DefaultIfEmpty()
                        where J == null && E != null && (E.Id == 0 && E.StandortId != null)
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
                List<GruSysStandort> Elements = (List<GruSysStandort>)Data;
                List<GruSysStandort> BaseElements = (List<GruSysStandort>)Original;
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
            List<GruSysStandort> InsertElements = (List<GruSysStandort>)Added;
            List<GruSysStandort> DeleteElements = (List<GruSysStandort>)Deleted;
            List<GruSysStandort> EditElements = (List<GruSysStandort>)Modified;
            // Db Operations
            DbManager.InsertGruSysStandort(InsertElements);
            DbManager.DeleteGruSysStandort(DeleteElements);
            DbManager.UpdateGruSysStandort(EditElements);
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
    }
}
