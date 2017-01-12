using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.ASP.Extensions
{
    public static class StringExtensions
    {
        public static int CoerceToInt(this string text, int defaultValue)
        {
            int num = defaultValue;
            return int.TryParse(text, out num) ? num : defaultValue;
        }

        public static int CoerceToInt(this string text)
        {
            return CoerceToInt(text, -1);
        }
    }
}
