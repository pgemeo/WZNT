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
    public class WsGruArtAufEinzelnutzen
    {
        protected IList _List;
        protected IList _Original;
        protected string _StandortId;

        public WsGruArtAufEinzelnutzen(string StandortId)
        {
            this._StandortId = StandortId;
            this._List = DbManager.ReadGruArtAufEinzelnutzenList(this._StandortId);
            this._Original = GlobalFunctions.CloneList(this._List);
        }

        public string StandortId
        {
            get
            {
                return _StandortId;
            }
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
                List<GruArtAufEinzelnutzen> Elements = (List<GruArtAufEinzelnutzen>)Data;
                List<GruArtAufEinzelnutzen> BaseElements = (List<GruArtAufEinzelnutzen>)Original;
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
                List<GruArtAufEinzelnutzen> Elements = (List<GruArtAufEinzelnutzen>)Data;
                List<GruArtAufEinzelnutzen> BaseElements = (List<GruArtAufEinzelnutzen>)Original;
                // Finding Inserts
                IList =
                    (from E in Elements
                        join B in BaseElements on E.Id equals B.Id into Join
                        from J in Join.DefaultIfEmpty()
                        where J == null && E != null && (E.Id == 0 && E.Aufgabe != null)
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
                List<GruArtAufEinzelnutzen> Elements = (List<GruArtAufEinzelnutzen>)Data;
                List<GruArtAufEinzelnutzen> BaseElements = (List<GruArtAufEinzelnutzen>)Original;
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

        public object FindElement<T>(Predicate<T> Predicate)
        {
            List<GruArtAufEinzelnutzen> Collection = (List<GruArtAufEinzelnutzen>)Data;
            Predicate<GruArtAufEinzelnutzen> Filter = (Predicate as Predicate<GruArtAufEinzelnutzen>);
            return Collection.Find(Filter);
        }

        public bool SaveElement(object Element, object Data)
        {
            bool ReturnValue = false;
            if (Element != null)
            {
                // Instance
                GruArtAufEinzelnutzen Instance = (GruArtAufEinzelnutzen)Element;
                // Workspace Children
                List<GruArtAufEinSprache> WSChildren = (Instance != null && Instance.GruArtAufEinSpraches != null) ?
                    Instance.GruArtAufEinSpraches.ToList() : new List<GruArtAufEinSprache>();
                // Initialize List
                List<GruArtAufEinSprache> List = new List<GruArtAufEinSprache>();
                // Modified Elements
                List = (List<GruArtAufEinSprache>)GetModifiedChildren(Element, Data);
                // Deleted Elements
                List = (List<GruArtAufEinSprache>)GetDeletedChildren(Element, Data);
                WSChildren.RemoveAll(X => List.Contains(X));
                // Added Elements
                List = (List<GruArtAufEinSprache>)GetAddedChildren(Element, Data);
                WSChildren.AddRange(List);
                // Remove Empty Elements From View
                WSChildren.RemoveAll(X => X.Id == 0 && X.IdSprache == 0);
                // Update Parent
                Instance.GruArtAufEinSpraches = WSChildren.ToArray();
                // Return Value
                ReturnValue = true;
            }
            return ReturnValue;
        }

        public bool SaveChanges()
        {
            bool ReturnValue = false;
            List<GruArtAufEinzelnutzen> InsertElements = (List<GruArtAufEinzelnutzen>)Added;
            List<GruArtAufEinzelnutzen> DeleteElements = (List<GruArtAufEinzelnutzen>)Deleted;
            List<GruArtAufEinzelnutzen> EditElements = (List<GruArtAufEinzelnutzen>)Modified;
            // Db Operations
            DbManager.InsertGruArtAufEinzelnutzen(InsertElements);
            DbManager.DeleteGruArtAufEinzelnutzen(DeleteElements);
            DbManager.UpdateGruArtAufEinzelnutzen(EditElements);
            // Return
            ReturnValue = true;
            return ReturnValue;
        }

        protected IList GetDeletedChildren(object Element, object Data)
        {
            IList IList = null;
            if (Element != null)
            {
                // Instance
                GruArtAufEinzelnutzen Instance = (GruArtAufEinzelnutzen)Element;
                // Workspace Children
                List<GruArtAufEinSprache> WSChildren = (Instance != null && Instance.GruArtAufEinSpraches != null) ?
                    Instance.GruArtAufEinSpraches.ToList() : new List<GruArtAufEinSprache>();
                // View Children
                List<GruArtAufEinSprache> ViewChildren = (List<GruArtAufEinSprache>)Data;
                // Deleted Elements
                IList = WSChildren.Except(ViewChildren).ToList();
            }
            return IList;
        }
        protected IList GetAddedChildren(object Element, object Data)
        {
            IList IList = null;
            if (Element != null)
            {
                // Instance
                GruArtAufEinzelnutzen Instance = (GruArtAufEinzelnutzen)Element;
                // Workspace Children
                List<GruArtAufEinSprache> WSChildren = (Instance != null && Instance.GruArtAufEinSpraches != null) ?
                    Instance.GruArtAufEinSpraches.ToList() : new List<GruArtAufEinSprache>();
                // View Children
                List<GruArtAufEinSprache> ViewChildren = (List<GruArtAufEinSprache>)Data;
                // Added Elements
                IList = ViewChildren.Except(WSChildren).ToList().Select
                    (X =>
                        new GruArtAufEinSprache
                        {
                            Id = X.Id,
                            IdSprache = X.IdSprache,
                            IdAufgabe = Instance.Id,
                            Uebersetzung = X.Uebersetzung,
                            OTimeStamp = X.OTimeStamp,
                            StandortKz = X.StandortKz
                        }
                    ).ToList();
            }
            return IList;
        }
        protected IList GetModifiedChildren(object Element, object Data)
        {
            IList IList = null;
            if (Element != null)
            {
                // Instance
                GruArtAufEinzelnutzen Instance = (GruArtAufEinzelnutzen)Element;
                // Workspace Children
                List<GruArtAufEinSprache> WSChildren = (Instance != null && Instance.GruArtAufEinSpraches != null) ?
                    Instance.GruArtAufEinSpraches.ToList() : new List<GruArtAufEinSprache>();
                // View Children
                List<GruArtAufEinSprache> ViewChildren = (List<GruArtAufEinSprache>)Data;
                // Modified Elements
                IList =
                    (from VC in ViewChildren
                        join WSC in WSChildren on VC.Id equals WSC.Id into Join
                        from J in Join
                        select VC
                    ).ToList();
            }
            return IList;
        }

        public IList GruSprachens
        {
            get
            {
                IList List = DbManager.ReadGruSprachenList();
                // Empty Element
                List.Insert(0, new GruSprachen() { Id = 0, Sprache = null });
                return List;
            }
        }
    }
}
