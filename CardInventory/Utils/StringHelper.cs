using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CardInventory.Utils
{
    public static class StringHelper
    {
        public static string DecodedHtml(this string _input)
        {
            return HttpUtility.HtmlDecode(_input);
        }
        public static string TrimOnce(this string _input, string _letter)
        {
            string result = _input.Trim();
            if (result.StartsWith(_letter))
                result = result.Substring(1);

            if (result.EndsWith(_letter))
                result = result.Substring(0, result.Length - 1);

            return result;
        }

    }
}
