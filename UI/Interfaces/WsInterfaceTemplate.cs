using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Workspaces;

namespace UI.Interfaces
{
    public abstract class WsInterfaceTemplate
    {
        protected WsTemplate _Workspace;

        public WsInterfaceTemplate()
        {
            _Workspace = new WsUnknown();
        }

        protected virtual void Initialize()
        { }
        protected WsTemplate Workspace
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
