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
    public abstract class Workspace
    {
        protected IList _List;
        protected IList _Original;
        
        protected Workspace()
        {
            Initialize();
        }

        protected IList Original
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

        protected virtual bool ActionSave()
        {
            bool ReturnValue = false;
            return ReturnValue;
        }

        protected virtual IList Deleted
        {
            get
            {
                IList IList = null;
                return IList;
            }
        }

        protected virtual IList Added
        {
            get
            {
                IList IList = null;
                return IList;
            }
        }

        protected virtual IList Modified
        {
            get
            {
                IList IList = null;
                return IList;
            }
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

        //
        // Public
        //
        
        public IList List
        {
            get
            {
                return _List;
            }
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

        public virtual object FindElement<T>(Predicate<T> Predicate) where T : class
        {
            return null;
        }

        public virtual bool SaveElement(object Element, object Data)
        {
            bool ReturnValue = false;
            return ReturnValue;
        }
    }
}
