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
    public class WsGruArtAufEinzelnutzen : Workspace
    {
        public override IList Deleted
        {
            get
            {
                IList IList = null;
                List<GruArtAufEinzelnutzen> Elements = (List<GruArtAufEinzelnutzen>)List;
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

        public override IList Added
        {
            get
            {
                IList IList = null;
                List<GruArtAufEinzelnutzen> Elements = (List<GruArtAufEinzelnutzen>)List;
                List<GruArtAufEinzelnutzen> BaseElements = (List<GruArtAufEinzelnutzen>)Original;
                // Finding Inserts
                IList =
                    (from E in Elements
                        join B in BaseElements on E.Id equals B.Id into Join
                        from J in Join.DefaultIfEmpty()
                        where J == null && E != null
                        select E
                    ).ToList();
                return IList;
            }
        }

        public override IList Modified
        {
            get
            {
                IList IList = null;
                List<GruArtAufEinzelnutzen> Elements = (List<GruArtAufEinzelnutzen>)List;
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

        public override object FindElement<T>(Predicate<T> Predicate)
        {
            List<GruArtAufEinzelnutzen> Collection = (List<GruArtAufEinzelnutzen>)List;
            Predicate<GruArtAufEinzelnutzen> Filter = (Predicate as Predicate<GruArtAufEinzelnutzen>);
            return Collection.Find(Filter);
        }

        public override bool SaveElement(object Element, object Data)
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

        protected override bool ActionSave()
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

        protected override void Initialize()
        {
            this._List = DbManager.GetListGruArtAufEinzelnutzen();
            this._Original = GlobalFunctions.CloneList(this._List);
        }

        protected override IList GetDeletedChildren(object Element, object Data)
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
        protected override IList GetAddedChildren(object Element, object Data)
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
                            OTimeStamp = X.OTimeStamp
                        }
                    ).ToList();
            }
            return IList;
        }
        protected override IList GetModifiedChildren(object Element, object Data)
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
    }
}
