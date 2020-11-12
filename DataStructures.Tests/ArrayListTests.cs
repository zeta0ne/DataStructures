using NUnit.Framework;
using System;
using DataStructures;

namespace DataStructures.Tests
{
    public class ArrayListTests
    {   //����������� ����� �� �����������
        
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

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ReverseTest(int[] array, int[] expArr)
        {
            ArrayList expected = new ArrayList(expArr);
            ArrayList actual = new ArrayList(array);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 6, 0 }, 6 )]
        //[TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 0, 0, 0, -1 }, 0)]
        public void GetMaxValueTest(int[] array, int expected)
        {
            ArrayList arr = new ArrayList(array);
            int actual = arr.GetMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 6, 0 }, 0)]
        //[TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 0, 0, 0, -1 }, -1)]
        public void GetMinValueTest(int[] array, int expected)
        {
            ArrayList arr = new ArrayList(array);
            int actual = arr.GetMinValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 6, 0 }, 1)]
        //[TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 0, 0, 0, -1 }, 0)]
        public void GetMaxValueIndexTest(int[] array, int expected)
        {
            ArrayList arr = new ArrayList(array);
            int actual = arr.GetMaxValueIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 6, 0 }, 2)]
        [TestCase(new int[] { 1, 0, 7 }, 1)]
        [TestCase(new int[] { 0, 0, 0, -1 }, 3)]
        public void GetMinValueIndexTest(int[] array, int expected)
        {
            ArrayList arr = new ArrayList(array);
            int actual = arr.GetMinValueIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 0)]
        public void GetMinValueIndexTestNegative(int[] array, int expected)
        {
            ArrayList arr = new ArrayList(array);
            
            Assert.Throws<IndexOutOfRangeException>(()=>
            {
                int actual = arr.GetMinValueIndex();
            });
        }

    }
}