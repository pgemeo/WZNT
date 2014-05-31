using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace UI.Shared
{
    public static class GlobalFunctions
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
        public static IList CloneList(IList List)
        {
            if(List != null)
            {
                BinaryFormatter Formatter = new BinaryFormatter();
                MemoryStream Stream = new MemoryStream();
                Formatter.Serialize(Stream, List);
                Stream.Position = 0;
                return (IList)Formatter.Deserialize(Stream);
            }
            return null;
        } 
    }
}
