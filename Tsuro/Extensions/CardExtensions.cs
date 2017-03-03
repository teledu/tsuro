using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsuro.Extensions
{
    public static class CardExtensions
    {
        public static IEnumerable<string> SplitIntoPairs(this string str)
        {
            for (var index = 0; index < str.Length; index += 2)
            {
                yield return str.Substring(index, Math.Min(2, str.Length - index));
            }
        }
    }
}
