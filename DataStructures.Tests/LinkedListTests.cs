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
        [TestCase(new int[] {  }, 4, new int[] { 4 })]
        [TestCase(new int[] { 0 }, 4, new int[] { 4, 0 })]
        public void AddToBeginnigTest(int[] array, int value, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);

            actual.AddToBeginning(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] {  }, 4, new int[] { 4 })]
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
        public void RemoveElementByIndexTest(int[] array, int index, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);

            actual.RemoveElementByIndex(index);
            Assert.AreEqual(expected, actual);
        }
    }
}
