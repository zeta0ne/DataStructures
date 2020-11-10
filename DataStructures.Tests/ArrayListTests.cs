using NUnit.Framework;
using System;
using DataStructures;

namespace DataStructures.Tests
{
    public class ArrayListTests
    {
        
        [TestCase(33, new int[3] { 1, 2, 3 }, new int[4] { 1, 2, 3, 33 } )]
        [TestCase(33, new int[0] { }, new int[1] { 33 })]
        public void AddToEndTest(int value, int[] array, int[] expArr )
        {
            ArrayList expected = new ArrayList(expArr);
            ArrayList actual = new ArrayList(array);

            actual.AddToEnd(value);

            Assert.AreEqual(expected, actual);

        }
    }
}