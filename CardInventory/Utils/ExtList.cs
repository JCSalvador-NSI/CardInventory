using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventory.Utils
{
    public static class ExtList
    {
        public static bool IsNotEmpty<T>(this ICollection<T> list)
        {
            return list != null && list.Count > 0;
        }
    }
}
