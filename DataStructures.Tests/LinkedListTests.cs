using NUnit.Framework;
using DataStructures.LL;

namespace DataStructures.Tests
{
    public class LinkedListTests
    {
        [TestCase(new int[] { 1, 2, 3 }, 1, 4, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 0, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 0, 4, new int[] { 4, 1 })]
        public void AddByIndexTest(int[] array, int index, int value, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);

            actual.AddByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { }, 4, new int[] { 4 })]
        [TestCase(new int[] { 0 }, 4, new int[] { 4, 0 })]
        public void AddToBeginnigTest(int[] array, int value, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);

            actual.AddToBeginning(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 4, new int[] { 4 })]
        public void AddToEndTest(int[] array, int value, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);

            actual.AddToEnd(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 0 }, new int[] { })]
        //[TestCase(new int[] { }, new int[] { })] neg
        public void RemoveLastElementTest(int[] array, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);

            actual.RemoveLastElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 0 }, new int[] { })]
        public void RemoveFirstElementTest(int[] array, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);

            actual.RemoveFirstElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 3, 4, 5 })]
        //[TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4, 5 })] null ref neg
        public void RemoveElementByIndexTest(int[] array, int index, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);

            actual.RemoveElementByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetLengthTest(int[] array, int expected)
        {
            LL.LinkedList arr = new LL.LinkedList(array);
            int actual = arr.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 0 }, 0, 0)]
        //[TestCase(new int[] { }, 0, 0)] nullref neg
        public void GetValueByIndexTest(int[] array, int index, int expected)
        {
            LL.LinkedList arr = new LL.LinkedList(array);
            int actual = arr.GetValueByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 2)]
        [TestCase(new int[] { 0 }, 0, 0)]
        public void GetIndexByValueTest(int[] array, int value, int expected)
        {
            LL.LinkedList arr = new LL.LinkedList(array);
            int actual = arr.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 8, 1, new int[] { 1, 8, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 8, 0, new int[] { 8, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 8, 4, new int[] { 1, 2, 3, 4, 8 })]
        [TestCase(new int[] { 1 }, 8, 0, new int[] { 8 })]
        //[TestCase(new int[] { }, 8, 0, new int[] { 8 })] null ref
        public void ChangeValueByIndexTest(int[] array, int value, int index, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);

            actual.ChangeValueByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ReverseTest(int[] array, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 10, 20, -1 }, 20)]
        [TestCase(new int[] { 0, -1 }, 0)]
        [TestCase(new int[] { 1, 0, -1 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        //[TestCase(new int[] {  }, 0)] null ref
        public void GetMaxValueTest(int[] array, int expected)
        {
            LL.LinkedList arr = new LL.LinkedList(array);
            int actual = arr.GetMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 10, 20, -1 }, -1)]
        [TestCase(new int[] { 0, -1 }, -1)]
        [TestCase(new int[] { 1, 0, -1 }, -1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        public void GetMinValueTest(int[] array, int expected)
        {
            LL.LinkedList arr = new LL.LinkedList(array);
            int actual = arr.GetMinValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 10, 20, -1 }, 1)]
        [TestCase(new int[] { 0, -1 }, 0)]
        [TestCase(new int[] { 1, 0, -1 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3)]
        [TestCase(new int[] { 100, 2, -1, 200 }, 3)]
        [TestCase(new int[] { 100, 2, -1, 20 }, 0)]
        //[TestCase(new int[] {  }, 0)] null ref
        public void GetMaxValueIndexTest(int[] array, int expected)
        {
            LL.LinkedList arr = new LL.LinkedList(array);
            int actual = arr.GetMaxValueIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 10, 20, -1 }, 2)]
        [TestCase(new int[] { 0, -1 }, 1)]
        [TestCase(new int[] { 1, 0, -1 }, 2)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 100, 2, -1, 200 }, 2)]
        [TestCase(new int[] { 100, 2, -1, 20 }, 2)]
        //[TestCase(new int[] {  }, 0)] null ref
        public void GetMinValueIndexTest(int[] array, int expected)
        {
            LL.LinkedList arr = new LL.LinkedList(array);
            int actual = arr.GetMinValueIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 2, 9, 0 }, new int[] { 0, 2, 5, 9 })]
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(new int[] { 1, -91, 0 }, new int[] { -91, 0, 1 })]
        [TestCase(new int[] { 5, -91, 10 }, new int[] { -91, 5, 10 })]
        [TestCase(new int[] { 5, 20, 10, 1 }, new int[] { 1, 5, 10, 20 })]
        [TestCase(new int[] { 5 }, new int[] { 5 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortByAscendingTest(int[] array, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);
            actual.SortByAscending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 2, 9, 0 }, new int[] { 9, 5, 2, 0 })]
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(new int[] { 1, -91, 0 }, new int[] { 1, 0, -91 })]
        [TestCase(new int[] { 5, -91, 10 }, new int[] { 10, 5, -91 })]
        [TestCase(new int[] { 5, 20, 10, 1 }, new int[] { 20, 10, 5, 1 })]
        [TestCase(new int[] { 5 }, new int[] { 5 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortByDescendingTest(int[] array, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);
            actual.SortByDescending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 4, 1, 7, 1, 5, 3, 1 }, 1, new int[] { 2, 4, 7, 1, 5, 3, 1 })]
        [TestCase(new int[] { 1, 2, 4, 1, 7, 1, 5, 3, 1 }, 1, new int[] { 2, 4, 1, 7, 1, 5, 3, 1 })]
        [TestCase(new int[] { 1 }, 1, new int[] {  })]
        public void RemoveFirstValueTest(int[] array, int value, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);
            actual.RemoveFirstValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 4, 1, 7, 1, 5, 3, 1 }, 1, new int[] { 2, 4, 7, 5, 3 })]
        [TestCase(new int[] { 1, 2, 4, 1, 7, 1, 5, 3, 1 }, 1, new int[] { 2, 4, 7, 5, 3 })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        [TestCase(new int[] { 2, 1 }, 1, new int[] { 2 })]
        [TestCase(new int[] { 1, 2, 1 }, 1, new int[] { 2 })]
        [TestCase(new int[] { 1, 1, 1, 1 }, 1, new int[] { })]
        public void RemoveAllValuesTest(int[] array, int value, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);
            actual.RemoveAllValues(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 6, 8, 4 }, new int[] { 1, 2, 3 }, new int[] { 6, 8, 4, 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 1 }, new int[] { 0 }, new int[] { 1, 0 })]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        public void AddArrayToEndTest(int[] array, int[] add, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);
            actual.AddArrayToEnd(add);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 6, 8, 4 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 6, 8, 4 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        public void AddArrayToBeginningTest(int[] array, int[] add, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);
            actual.AddArrayToBeginning(add);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 6, 8, 4 }, new int[] { 1, 2, 3 }, 0, new int[] { 1, 2, 3, 6, 8, 4 })]
        [TestCase(new int[] { 6, 8, 4 }, new int[] { 1, 2, 3 }, 2, new int[] { 6, 8, 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, 0, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 0 }, 0, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, 1, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 6 }, 2, new int[] { 1, 2, 6, 3 })]
        public void AddArrayToIndexTest(int[] array, int[] add, int index, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);
            actual.AddArrayToIndex(add, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5}, 2, new int[] { 1, 2, 3 })]
        [TestCase(new int[] {1, 2, 3, 4, 5}, 4, new int[] { 1 })]
        [TestCase(new int[] {1, 2, 3, 4, 5}, 5, new int[] { })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        [TestCase(new int[] { 0 }, 1, new int[] { })]
        public void RemoveNElementsFromEndTest(int[] array, int amount, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);
            actual.RemoveNElementsFromEnd(amount);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        [TestCase(new int[] { 0 }, 1, new int[] { })]
        public void RemoveNElementsFromBeginningTest(int[] array, int amount, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);
            actual.RemoveNElementsFromBeginning(amount);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 2, new int[] { 1, 2, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 0, new int[] { 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 0, new int[] { })]
        [TestCase(new int[] { 1 }, 1, 0, new int[] { })]
        public void RemoveNElementsFromIndexTest(int[] array, int amount, int index, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);
            actual.RemoveNElementsFromIndex(amount, index);
            Assert.AreEqual(expected, actual);
        }

    }
}
