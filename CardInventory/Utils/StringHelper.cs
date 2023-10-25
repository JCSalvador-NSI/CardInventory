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

    }
}
