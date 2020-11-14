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
            LinkedList expected = new LinkedList(expArr);
            LinkedList actual = new LinkedList(array);

            actual.AddByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] {  }, 4, new int[] { 4 })]
        [TestCase(new int[] { 0 }, 4, new int[] { 4, 0 })]
        public void AddToBeginnigTest(int[] array, int value, int[] expArr)
        {
            LinkedList expected = new LinkedList(expArr);
            LinkedList actual = new LinkedList(array);

            actual.AddToBeginning(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] {  }, 4, new int[] { 4 })]
        public void AddToEndTest(int[] array, int value, int[] expArr)
        {
            LinkedList expected = new LinkedList(expArr);
            LinkedList actual = new LinkedList(array);

            actual.AddToEnd(value);
            Assert.AreEqual(expected, actual);
        }
    }
}
