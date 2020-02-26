using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Extensions
{
    static class RandomExtensions
    {
        public static IEnumerable<int> GetRandomIntValues(this Random rnd, int Count, int Min, int Max)
        {
            for (var i = 0; i < Count; i++)
                yield return rnd.Next(Min, Max);
        }

        public static T NextValue<T>(this Random rnd, params T[] Variants)
        {
            return Variants[rnd.Next(0, Variants.Length)];
        }
    }
}
