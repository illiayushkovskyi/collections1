using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections
{
    static class ListExtentsion
    {
        public static IEnumerable<T> FilterWithYield<T>(this IEnumerable<T> source, Func<T, bool> conditions)
        {
            foreach (var item in source)
            {
                if (conditions(item))
                {
                    yield return item;
                }
            }
        }

    }
}
