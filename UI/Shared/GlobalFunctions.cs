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
        public static List<T> CloneList<T>(List<T> oldList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, oldList);
            stream.Position = 0;
            return (List<T>)formatter.Deserialize(stream);
        } 
    }
}
