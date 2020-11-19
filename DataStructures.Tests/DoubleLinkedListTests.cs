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
    }
}
