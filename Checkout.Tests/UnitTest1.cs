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
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestScan()
        {
            var input = new List<char>() {'A'};
            var sut = new TheCheckout();

            var current = input.Last();
            sut.Scan(current);
            var result = sut.Items;
            
            Assert.That(result, Is.EquivalentTo(new Dictionary<char, int>{{'A',1}}));

        }

        
    }
}