using System.Collections.Generic;
using NUnit.Framework;

namespace Checkout.Tests
{
    public class TheCheckoutTests
    {
        [Test]
        public void TestIncremental()
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
            Assert.That(Price(""), Is.EqualTo(0));
            Assert.That(Price("A"), Is.EqualTo(50));
            Assert.That(Price("AB"), Is.EqualTo(80));
            Assert.That(Price("CDBA"), Is.EqualTo(115));

            Assert.That(Price("AA"), Is.EqualTo(100));
            Assert.That(Price("AAA"), Is.EqualTo(130));
            Assert.That(Price("AAAA"), Is.EqualTo(180));
            Assert.That(Price("AAAAA"), Is.EqualTo(230));
            Assert.That(Price("AAAAAA"), Is.EqualTo(260));

            Assert.That(Price("AAAB"), Is.EqualTo(160));
            Assert.That(Price("AAABB"), Is.EqualTo(175));
            Assert.That(Price("AAABBD"), Is.EqualTo(190));
            Assert.That(Price("DABABA"), Is.EqualTo(190));
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