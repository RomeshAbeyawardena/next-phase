using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Shared.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Removes the first occurance of a specific object from an IEnumerable&lt;T&gt;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> Remove<T>(this IEnumerable<T> value, T item)
        {
            var valueList = new List<T>(value);
            valueList.Remove(item);
            return valueList.ToArray();
        }
    }
}
