using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace System.Linq
{
    public static partial class Enumerable
    {
        /// <summary>
        /// Idea from Gemini
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static ulong Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, ulong> selector)
        {
            ulong sum = 0;
            foreach (var item in source)
            {
                sum += selector(item);
            }
            return sum;
        }
    }
}