using NUnit.Framework;
using DataStructures.DLL;

namespace DataStructures.Tests
{
    public class DoubleLinkedListTests
    {
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        
        public void ConstructorTest(int[] array, int[] expArr)
        {
            DLL.DoubleLinkedList expected = new DLL.DoubleLinkedList(expArr);
            DLL.DoubleLinkedList actual = new DLL.DoubleLinkedList(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 4, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 8, 9)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 6, 7)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1, 2)]
        public void GetterTest(int[] array, int index, int expected)
        {
            DLL.DoubleLinkedList arr = new DoubleLinkedList(array);
            int actual = arr[index];
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 7, new int[] { 1, 2, 3, 4, 7 })]
        [TestCase(new int[] {  }, 7, new int[] { 7 })]
        public void AddToEndTest(int[] array, int value, int[] expArr)
        {
            DLL.DoubleLinkedList expected = new DLL.DoubleLinkedList(expArr);
            DLL.DoubleLinkedList actual = new DLL.DoubleLinkedList(array);
            actual.AddToEnd(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 7, new int[] { 7, 1, 2, 3, 4 })]
        [TestCase(new int[] {  }, 7, new int[] { 7 })]
        public void AddToBeginningTest(int[] array, int value, int[] expArr)
        {
            DLL.DoubleLinkedList expected = new DLL.DoubleLinkedList(expArr);
            DLL.DoubleLinkedList actual = new DLL.DoubleLinkedList(array);
            actual.AddToFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 7, 0, new int[] { 7, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 7, 3, new int[] { 1, 2, 3, 7, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 7, 2, new int[] { 1, 2, 7, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 7, 1, new int[] { 1, 7, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5}, 7, 2, new int[] { 1, 2, 7, 3, 4, 5 })]
        [TestCase(new int[] { }, 7, 0, new int[] { 7 })]
        public void AddToIndexTest(int[] array, int value, int index, int[] expArr)
        {
            DLL.DoubleLinkedList expected = new DLL.DoubleLinkedList(expArr);
            DLL.DoubleLinkedList actual = new DLL.DoubleLinkedList(array);
            actual.AddToIndex(value, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveFirstElementTest(int[] array, int[] expArr)
        {
            DLL.DoubleLinkedList expected = new DLL.DoubleLinkedList(expArr);
            DLL.DoubleLinkedList actual = new DLL.DoubleLinkedList(array);
            actual.RemoveFirstElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveLastElementTest(int[] array, int[] expArr)
        {
            DLL.DoubleLinkedList expected = new DLL.DoubleLinkedList(expArr);
            DLL.DoubleLinkedList actual = new DLL.DoubleLinkedList(array);
            actual.RemoveLastElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 5, new int[] { 1, 2, 3, 4, 5, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 1, 2, 3, 5, 6, 7 })]
        public void RemoveElementByIndexTest(int[] array, int index, int[] expArr)
        {
            DLL.DoubleLinkedList expected = new DLL.DoubleLinkedList(expArr);
            DLL.DoubleLinkedList actual = new DLL.DoubleLinkedList(array);
            actual.RemoveElementByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 1, 5, 6, 7 }, 1, 0)]
        [TestCase(new int[] { 1, 5, 3, 7, 3, 7, 9, 0, 3 }, 3, 2)]
        [TestCase(new int[] { 1, 1, 1, 3 }, 3, 3)]
        [TestCase(new int[] { 3 }, 3, 0)]
        public void GetIndexByValueTest(int[] array, int value, int expected)
        {
            DoubleLinkedList arr = new DoubleLinkedList(array);
            int actual = arr.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, 8, new int[] { 1, 2, 3, 8, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, 8, new int[] { 8, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6, 8, new int[] { 1, 2, 3, 4, 5, 6, 8 })]
        [TestCase(new int[] { 1 }, 0, 8, new int[] { 8 })]
        public void ChangeValueByIndexTest(int[] array, int index, int value, int[] exp)
        {
            DoubleLinkedList expected = new DoubleLinkedList(exp);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.ChangeValueByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void ReverseTest(int[] array, int[] exp)
        {
            DoubleLinkedList expected = new DoubleLinkedList(exp);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4 )]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetMaxValueTest(int[] array, int expected)
        {
            DoubleLinkedList arr = new DoubleLinkedList(array);
            int actual = arr.GetMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 3, 1, 4 }, 1)]
        [TestCase(new int[] { 2, 3, 0, 1 }, 0)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetMinValueTest(int[] array, int expected)
        {
            DoubleLinkedList arr = new DoubleLinkedList(array);
            int actual = arr.GetMinValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 10, 20, -1 }, 1)]
        [TestCase(new int[] { 0, -1 }, 0)]
        [TestCase(new int[] { 1, 0, -1 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3)]
        [TestCase(new int[] { 100, 2, -1, 200 }, 3)]
        [TestCase(new int[] { 100, 2, -1, 20 }, 0)]
        public void GetMaxValueIndexTest(int[] array, int expected)
        {
            DoubleLinkedList arr = new DoubleLinkedList(array);
            int actual = arr.GetMaxValueIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 10, 20, -1 }, 2)]
        [TestCase(new int[] { 0, -1 }, 1)]
        [TestCase(new int[] { 1, 0, -1 }, 2)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 100, 2, -1, 200 }, 2)]
        [TestCase(new int[] { 100, 2, -1, 20 }, 2)]
        public void GetMinValueIndexTest(int[] array, int expected)
        {
            DoubleLinkedList arr = new DoubleLinkedList(array);
            int actual = arr.GetMinValueIndex();
            Assert.AreEqual(expected, actual);
        }
    }
}
