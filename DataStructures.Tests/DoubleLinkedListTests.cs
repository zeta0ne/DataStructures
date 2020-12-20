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
            DLL.DoubleLinkedList arr = new DLL.DoubleLinkedList(array);
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
    }
}
