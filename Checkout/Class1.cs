using System;
using System.Collections.Generic;

namespace Checkout
{
    public class TheCheckout
    {
        Dictionary<char, int> _items = new Dictionary<char, int>();

        public Dictionary<char, int> Items => _items;

        public void Scan(char current)
        {
            _items.Add(current, 1);
        }
    }
}
