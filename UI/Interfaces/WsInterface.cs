using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Workspaces;

namespace UI.Interfaces
{
    public abstract class WsInterface
    {
        protected Workspace _Workspace;

        public WsInterface()
        {
            _Workspace = new WsUnknown();
        }

        protected virtual void Initialize()
        { }
        protected Workspace Workspace
        {
            get
            {
                return _Workspace;
            }
        }
        
        public bool Save()
        {
            return _Workspace.SaveChanges();
        }
        public virtual void Clear()
        { }
    }
}
