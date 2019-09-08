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
            var sut = new TheCheckout();

            sut.Scan('A');
            Assert.That(sut.Items, Is.EquivalentTo(new Dictionary<char, int> { { 'A', 1 } }));

            sut.Scan('A');
            Assert.That(sut.Items, Is.EquivalentTo(new Dictionary<char, int> { { 'A', 2 } }));

            sut.Scan('B');
            Assert.That(sut.Items, Is.EquivalentTo(new Dictionary<char, int> { { 'A', 2 }, { 'B', 1 } }));
        }

        public void RepresentPricingRules()
        {
            var pricingRules = new Dictionary<char, Dictionary<int, int>>()
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

            var sut = new TheCheckout(pricingRules);
        }

    }
}