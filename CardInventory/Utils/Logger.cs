using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventory.Utils
{
    public static class Logger
    {
        public static void PrintDebug(string _content)
        {
            string content = _content.Replace("                                   ", "");
            Console.WriteLine(content);
        }
    }
}
