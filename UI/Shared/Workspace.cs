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
        protected Type _Type;

        public Workspace(Type Type)
        {
            this._Type = Type;
            if (Type == typeof(GruArtAufEinzelnutzen))
            {
                this._List = DbManager.GetListGruArtAufEinzelnutzen();
            }
        }
        
        public IList List
        {
            get {
                return _List;
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
    }
}
