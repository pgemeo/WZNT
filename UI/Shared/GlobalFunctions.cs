using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Shared
{
    public class GlobalFunctions
    {
        public static Type GetListElementsType(IList Collection)
        {
            if (Collection == null)
            {
                return null;
            }
            else
            {
                return Collection.GetType().GenericTypeArguments.Single();
            }
        }
    }
}
