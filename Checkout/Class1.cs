﻿using System;
using System.Collections.Generic;

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
            return _pricingRules['A'][1];
        }
    }
}
