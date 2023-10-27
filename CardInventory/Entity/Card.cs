using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventory.Entity
{
    public class Card : INotifyPropertyChanged
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
            _quantity = 0;
            _quantitymodifier = 0;
            _pricebought = 0m;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int _quantity;
        private int _quantitymodifier;
        private decimal _pricebought;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SetCode { get; set; }
        public string Name { get; set; }
        public string JapaneseName { get; set; }
        public string Rarity { get; set; }
        public string Category { get; set; }
        public int Quantity 
        {
            get { return this._quantity; }
            set
            {
                if (this._quantity != value)
                {
                    this._quantity = value;
                    OnPropertyChanged(nameof(Card.Quantity));
                }
            }
        }
        public int QtyModifier
        {
            get { return this._quantitymodifier; }
            set
            {
                if (this._quantitymodifier != value)
                {
                    this._quantitymodifier = value;
                    OnPropertyChanged(nameof(Card.QtyModifier));
                }
            }
        }
        public decimal PriceBought
        {
            get { return this._pricebought; }
            set
            {
                if (this._pricebought != value)
                {
                    this._pricebought = value;
                    OnPropertyChanged(nameof(Card.PriceBought));
                }
            }
        }
    }
}
