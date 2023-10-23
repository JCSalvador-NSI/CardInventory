using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventory.Entity
{
    public class Card
    {
        public Card()
        {
            //
        }

        public Card(string _setcode, string _name, string _japname, string _rarity, string _category)
        {
            SetCode = _setcode;
            Name = _name;
            JapaneseName = _japname;
            Rarity = _rarity;
            Category = _category;
            Quantity = 0;
        }

        public string SetCode { get; set; }
        public string Name { get; set; }
        public string JapaneseName { get; set; }
        public string Rarity { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}
