using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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

            var current = input.Last();
            var actual = new Dictionary<char, int>();
            actual.Add(current,1);
            var result = actual;
            
            Assert.That(result, Is.EquivalentTo(new Dictionary<char, int>{{'A',1}}));

        }
    }
}