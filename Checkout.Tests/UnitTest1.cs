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
            var sut = new TheCheckout();

            sut.Scan('A');
            Assert.That(sut.Items, Is.EquivalentTo(new Dictionary<char, int> { { 'A', 1 } }));

            sut.Scan('A');
            Assert.That(sut.Items, Is.EquivalentTo(new Dictionary<char, int> { { 'A', 2 } }));

            sut.Scan('B');
            Assert.That(sut.Items, Is.EquivalentTo(new Dictionary<char, int> { { 'A', 2 }, {'B', 1} }));
        }


    }
}