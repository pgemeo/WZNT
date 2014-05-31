using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Shared
{
    public class Workspace
    {
        protected IList _Workspace;
        public IList List
        { 
            get { return _Workspace; }
            set { _Workspace = value; }
        }

    }
}
