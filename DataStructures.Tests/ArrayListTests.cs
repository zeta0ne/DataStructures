using NUnit.Framework;
using System;
using DataStructures;

namespace DataStructures.Tests
{
    public class ArrayListTests
    {   //конструктор можно не тестировать
        
        [TestCase(33, new int[3] { 1, 2, 3 }, new int[4] { 1, 2, 3, 33 } )]
        [TestCase(33, new int[0] { }, new int[1] { 33 })]
        public void AddToEndTest(int value, int[] array, int[] expArr )
        {
            ArrayList expected = new ArrayList(expArr);
            ArrayList actual = new ArrayList(array);
            actual.AddToEnd(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(33, new int[] { 1, 2, 3 }, new int[] { 33, 1, 2, 3 })]
        [TestCase(33, new int[] { }, new int[] { 33 })]
        [TestCase(33, new int[3] { 0, 0, 0 }, new int[4] { 33, 0, 0, 0 })]
        public void AddToFirstTest(int value, int[] array, int[] expArr)
        {
            ArrayList expected = new ArrayList(expArr);
            ArrayList actual = new ArrayList(array);
            actual.AddToFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 7, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 7, 3, 4, 5 })]
        [TestCase(0, 33, new int[] { }, new int[] { 33 })]
        [TestCase(0, 33, new int[3] { 0, 0, 0 }, new int[4] { 33, 0, 0, 0 })]
        public void AddToIndexTest(int index, int value, int[] array, int[] expArr)
        {
            ArrayList expected = new ArrayList(expArr);
            ArrayList actual = new ArrayList(array);
            actual.AddToIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0, new int[] { 1 }, new int[0] { })]
        public void RemoveTest(int index, int[] array, int[]expArr)
        {
            ArrayList expected = new ArrayList(expArr);
            ArrayList actual = new ArrayList(array);
            actual.RemoveIndex(index);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveLastTest(int[] array, int[] expArr)
        {
            ArrayList expected = new ArrayList(expArr);
            ArrayList actual = new ArrayList(array);
            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0] { }, 0, 0)]
        public void GetLengthTest(int[] array, int expected, int actual)
        {
            ArrayList arr = new ArrayList(array);
            actual = arr.GetLength(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, 3)]
        public void GetValueByIndexTest(int[] array, int index, int expected )
        {
            ArrayList arr = new ArrayList(array);
            int actual = arr.GetValueByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 3, 2)]
        public void GetIndexByValueTest(int[] array, int value, int expected)
        {
            ArrayList arr = new ArrayList(array);
            int actual = arr.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 8, new int[] { 1, 2, 3, 8, 5 })]
        
        public void ChangeValueByIndexTest(int[] array, int index, int value, int[] expArr)
        {
            ArrayList expected = new ArrayList(expArr);
            ArrayList actual = new ArrayList(array);
            actual.ChangeValueByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 0, 8, new int[] { 8 })]
        public void ChangeValueByIndexTestNegative(int[] array, int index, int value, int[] expArr)
        {
            ArrayList expected = new ArrayList(expArr);
            ArrayList actual = new ArrayList(array);
            
            Assert.Throws <IndexOutOfRangeException> (()=>
            {
                actual.ChangeValueByIndex(index, value);
            });

        }

    }
}