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

        public string SetCode { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public int Quantity { get; set; }
    }
}
