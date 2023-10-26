using CardInventory.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventory.Data
{
    public static class ExportFormats
    {
        public static string CSV_Sanitize(string _input)
        {
            var escape_char = new string[] { "\"", "'", ","  };
            if (escape_char.Any(x => _input.Contains(x)))
            {
                return "\"" + _input.Replace("\"", "\"\"") + "\"";
            }
            return _input;
        }
        public static string ExportCSV(List<Card> _list)
        {
            if (_list == null || _list.Count <= 0)
                return "";

            var header_arr = new string[]
            {
                "Folder Name",
                "Quantity",
                "Trade Quantity",
                "Card Name",
                "Set Code",
                "Set Name",
                "Card Number",
                "Rarity",
                "Condition",
                "Printing",
                "Language",
                "Price Bought",
                "Date Bought",
                "LOW",
                "MID",
                "MARKET",
            };
            var c_list = _list.Select(x =>
                "OCG" + "," +
                $"{ x.Quantity }" + "," +
                "0" + "," +
                $"{ CSV_Sanitize(x.Name) }" + "," +
                $"{ x.SetCode.Substring(0, 4) }" + "," +
                "" + "," +
                $"{ x.SetCode }" + "," +
                $"{ CSV_Sanitize(x.Rarity) }" + "," +
                "NearMint" + "," +
                "1st Edition" + "," +
                "Japanese" + "," +
                "0.00" + "," +
                "" + "," +
                "" + "," +
                "" + "," +
                ""
            );

            return "";//TODO: Return list results.
        }
    }
}
