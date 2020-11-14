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
        [TestCase(new int[] {  }, 0)]
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
        public void ChangeValueByIndex(int[] array, int value, int index, int[] expArr)
        {
            LL.LinkedList expected = new LL.LinkedList(expArr);
            LL.LinkedList actual = new LL.LinkedList(array);

            actual.ChangeValueByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }


    }
}
