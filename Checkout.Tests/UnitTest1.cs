using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Checkout;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void BuildUpItemsDataStructure()
        {
            var sut = new TheCheckout(PricingRules());

            sut.Scan('A');
            Assert.That(sut.Items, Is.EquivalentTo(new Dictionary<char, int> { { 'A', 1 } }));

            sut.Scan('A');
            Assert.That(sut.Items, Is.EquivalentTo(new Dictionary<char, int> { { 'A', 2 } }));

            sut.Scan('B');
            Assert.That(sut.Items, Is.EquivalentTo(new Dictionary<char, int> { { 'A', 2 }, { 'B', 1 } }));
        }

        [Test]
        public void TestTotals()
        {
            var goods = "A";
            var total = Price(goods);
            Assert.That(total, Is.EqualTo(50));
        }

        private static int Price(string goods)
        {
            var pricingRules = PricingRules();

            var sut = new TheCheckout(pricingRules);
            var items = goods.ToCharArray();
            foreach (var item in items)
            {
                sut.Scan(item);
            }

            return sut.GetTotal();
        }

        private static Dictionary<char, Dictionary<int, int>> PricingRules()
        {
            return new Dictionary<char, Dictionary<int, int>>()
            {
                {'A', new Dictionary<int, int>()
                    {
                        {1, 50},
                        {3, 130},
                    }
                },
                {'B', new Dictionary<int, int>()
                    {
                        {1, 30 },
                        {2, 45 }
                    }
                },
                {'C', new Dictionary<int, int>()
                    {
                        {1, 20}
                    }
                },
                {'D', new Dictionary<int, int>()
                    {
                        {1,15 }
                    }
                }
            };
        }
    }
}