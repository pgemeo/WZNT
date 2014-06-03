using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.WZNTServices;
using Services;

namespace UI.Workspaces
{
    public abstract class Workspace
    {
        protected IList _List;
        protected IList _Original;
        
        public Workspace()
        {
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

        protected void Refresh()
        {
            Initialize();
        }

        public bool SaveChanges()
        {
            bool ReturnValue = false;
            // DDLs
            ReturnValue = ActionSave();
            // Refresh Workspace
            Refresh();
            return ReturnValue;
        }

        protected virtual bool ActionSave()
        {
            bool ReturnValue = false;
            return ReturnValue;
        }

        public virtual IList Deleted
        {
            get
            {
                IList IList = null;
                return IList;
            }
        }

        public virtual IList Added
        {
            get
            {
                IList IList = null;
                return IList;
            }
        }

        public virtual IList Modified
        {
            get
            {
                IList IList = null;
                return IList;
            }
        }

        public virtual object FindElement<T>(Predicate<T> Predicate) where T : class
        {
            return null;
        }

        public virtual bool SaveElement(object Element, object Data)
        {
            bool ReturnValue = false;
            return ReturnValue;
        }

        protected virtual void Initialize()
        { }

        protected virtual IList GetDeletedChildren(object Element, object Data)
        {
            IList IList = null;
            return IList;
        }
        protected virtual IList GetAddedChildren(object Element, object Data)
        {
            IList IList = null;
            return IList;
        }
        protected virtual IList GetModifiedChildren(object Element, object Data)
        {
            IList IList = null;
            return IList;
        }
    }
}
