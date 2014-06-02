using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.WZNTServices;
using Services;

namespace UI.Shared
{
    public class Workspace
    {
        protected IList _List;
        protected IList _Original;
        protected Type _Type;

        public Workspace(Type Type)
        {
            this._Type = Type;
            Initialize();
        }
        
        public IList List
        {
            get {
                return _List;
            }
        }

        public IList Original
        {
            get
            {
                return _Original;
            }
        }

        public Type Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        public IList Deleted
        {
            get
            {
                IList IList = null;
                if (Type == typeof(GruArtAufEinzelnutzen))
                {
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
                    //MessageBox.Show(String.Format("Delete {0} element(s).", DeleteElements.Count));
                }
                return IList;
            }
        }

        public IList Added
        {
            get
            {
                IList IList = null;
                if (Type == typeof(GruArtAufEinzelnutzen))
                {
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
                    //MessageBox.Show(String.Format("Insert {0} element(s).", InsertElements.Count));
                }
                return IList;
            }
        }

        public IList Modified
        {
            get
            {
                IList IList = null;
                if (Type == typeof(GruArtAufEinzelnutzen))
                {
                    List<GruArtAufEinzelnutzen> Elements = (List<GruArtAufEinzelnutzen>)List;
                    List<GruArtAufEinzelnutzen> BaseElements = (List<GruArtAufEinzelnutzen>)Original;
                    // Finding Edits
                    IList =
                        (from E in Elements
                         join B in BaseElements on E.Id equals B.Id into Join
                         from J in Join
                         select E
                        ).ToList();
                    //MessageBox.Show(String.Format("Edit {0} element(s).", EditElements.Count));
                }
                return IList;
            }
        }

        public object FindElement<T>(Predicate<T> Predicate) where T : class
        {
            if (Type == typeof(GruArtAufEinzelnutzen))
            {
                List<GruArtAufEinzelnutzen> Collection = (List<GruArtAufEinzelnutzen>)List;
                Predicate<GruArtAufEinzelnutzen> Filter = (Predicate as Predicate<GruArtAufEinzelnutzen>);
                return Collection.Find(Filter);
            }
            return null;
        }

        public bool SaveElement(object Element, object Data)
        {
            bool ReturnValue = false;
            if (Element != null)
            {
                if (Type == typeof(GruArtAufEinzelnutzen))
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
            }
            return ReturnValue;
        }

        public bool SaveChanges()
        {
            bool ReturnValue = false;

            if (Type == typeof(GruArtAufEinzelnutzen))
            {
                List<GruArtAufEinzelnutzen> InsertElements = (List<GruArtAufEinzelnutzen>)Added;
                List<GruArtAufEinzelnutzen> DeleteElements = (List<GruArtAufEinzelnutzen>)Deleted;
                List<GruArtAufEinzelnutzen> EditElements = (List<GruArtAufEinzelnutzen>)Modified;
                // Db Operations
                int Ins = DbManager.InsertGruArtAufEinzelnutzen(InsertElements);
                MessageBox.Show(String.Format("{0} element(s) has been inserted.", Ins));
                int Del = DbManager.DeleteGruArtAufEinzelnutzen(DeleteElements);
                MessageBox.Show(String.Format("{0} element(s) has been deleted.", Del));
                int Upd = DbManager.UpdateGruArtAufEinzelnutzen(EditElements);
                MessageBox.Show(String.Format("{0} element(s) has been updated.", Upd));
                // Refresh Workspace
                Refresh();
                // Return
                ReturnValue = true;
            }
            return ReturnValue;
        }

        private void Initialize()
        {
            if (Type == typeof(GruArtAufEinzelnutzen))
            {
                this._List = DbManager.GetListGruArtAufEinzelnutzen();
                this._Original = GlobalFunctions.CloneList(this._List);
            }
        }

        private void Refresh()
        {
            Initialize();
        }

        private IList GetDeletedChildren(object Element, object Data)
        {
            IList IList = null;
            if (Element != null)
            {
                if (Type == typeof(GruArtAufEinzelnutzen))
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
            }
            return IList;
        }
        private IList GetAddedChildren(object Element, object Data)
        {
            IList IList = null;
            if (Element != null)
            {
                if (Type == typeof(GruArtAufEinzelnutzen))
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
            }
            return IList;
        }
        private IList GetModifiedChildren(object Element, object Data)
        {
            IList IList = null;
            if (Element != null)
            {
                if (Type == typeof(GruArtAufEinzelnutzen))
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
            }
            return IList;
        }
    }
}
