﻿using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class TheCheckout
    {
        private readonly Dictionary<char, Dictionary<int, int>> _pricingRules;
        private readonly Dictionary<char, int> _items = new Dictionary<char, int>();

        public TheCheckout(Dictionary<char, Dictionary<int, int>> pricingRules)
        {
            _pricingRules = pricingRules;
        }

        public Dictionary<char, int> Items => _items;

        public void Scan(char current)
        {
            if (_items.ContainsKey(current))
            {
                _items[current] += 1;
            }
            else
            {
                _items.Add(current, 1);
            }
        }

        public int GetTotal()
        {
            if (!_items.Any()) return 0;

            var total = 0;
            foreach (var item in _items)
            {
                var itemPrice = PriceItem(item);
                total += itemPrice;
            }
            return total;
        }

        private int PriceItem(KeyValuePair<char, int> item)
        {
            var subTotal = 0;
            var quantity = item.Value;
            while (quantity > 0)
            {
                var quantityKey = _pricingRules[item.Key].Keys.Last(i => i <= quantity);
                subTotal += _pricingRules[item.Key][quantityKey];
                quantity -= quantityKey;
            }

            return subTotal;
        }
    }
}
