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
            if (Type == typeof(GruArtAufEinzelnutzen))
            {
                this._List = DbManager.GetListGruArtAufEinzelnutzen();
                this._Original = GlobalFunctions.CloneList(this._List);
            }
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

        public bool SaveChanges()
        {
            bool ReturnValue = false;
            if (Type == typeof(GruArtAufEinzelnutzen))
            {
                List<GruArtAufEinzelnutzen> Elements = (List<GruArtAufEinzelnutzen>)List;
                List<GruArtAufEinzelnutzen> BaseElements = (List<GruArtAufEinzelnutzen>)Original;
                // Finding Edit Elements
                List<GruArtAufEinzelnutzen> EditElements =
                    (from E in Elements
                     join B in BaseElements on E.Id equals B.Id into Join
                     from J in Join
                     select E
                    ).ToList();
                MessageBox.Show(String.Format("Edit {0} element(s).", EditElements.Count));

                // Finding Insert Elements
                List<GruArtAufEinzelnutzen> InsertElements = 
                    (from E in Elements
                     join B in BaseElements on E.Id equals B.Id into Join
                     from J in Join.DefaultIfEmpty()
                     where J == null && E != null
                     select E
                    ).ToList();
                MessageBox.Show(String.Format("Insert {0} element(s).", InsertElements.Count));

                // Finding Delete Elements
                List<GruArtAufEinzelnutzen> DeleteElements = 
                    (from B in BaseElements
                     join E in Elements on B.Id equals E.Id into Join
                     from J in Join.DefaultIfEmpty()
                     where J == null && B != null
                     select B
                    ).ToList();
                MessageBox.Show(String.Format("Delete {0} element(s).", DeleteElements.Count));
            }
            return ReturnValue;
        }
    }
}
