using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomList;

namespace CustomListTests
{
    [TestClass]
    public class JListTests
    {
        [TestMethod]
        public void Add_AddItem_CountIncreasesByOne()
        {
            // Arrange
            JList<int> j = new JList<int>();

            // Act
            j.Add(10);

            //Assert
            int expected = 1;
            int actual = j.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItem_ItemAddedToEnd()
        {
            //Arrange
            int expected = 20;
            JList<int> j = new JList<int>();

            //Act
            j.Add(10);
            j.Add(expected);

            //Assert
            int actual = j[j.Count - 1];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItem_CapacityIncreased()
        {
            //Arrange
            JList<int> j = new JList<int>();
            int itemsToAdd = 9;

            //Act
            for(int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            //Assert
            int expected = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(itemsToAdd * 2) / JList<int>.CapacityIncrementor) * JList<int>.CapacityIncrementor);
            int actual = j.Capacity;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveMiddleIndex_CountDecreasesByOne()
        {
            // Arrange
            int itemsToAdd = 4;
            JList<int> j = new JList<int>();

            // Act
            for(int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            j.RemoveAt(1);

            //Assert
            int expected = itemsToAdd - 1;
            int actual = j.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveMiddleIndex_IndexAfterRemoveEqualsIndexPlusOneBefore()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = 1;
            JList<int> j = new JList<int>();

            // Act
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            int expected = j[index + 1];

            j.RemoveAt(index);

            //Assert
            int actual = j[index];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveMiddleIndex_IndexRemovedMinusOneValueRemainsSame()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = 1;
            JList<int> j = new JList<int>();

            // Act
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            int expected = j[index - 1];

            j.RemoveAt(index);

            //Assert
            int actual = j[index - 1];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAt_RemoveInvlidIndex_IndexOutOfRangeException()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = 10;
            JList<int> j = new JList<int>();

            // Act
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            j.RemoveAt(index);

            //Assert

        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAt_RemoveNegativeIndex_IndexOutOfRangeException()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = -1;
            JList<int> j = new JList<int>();

            // Act
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            j.RemoveAt(index);

            //Assert

        }

        [TestMethod]
        public void Indexer_ValidIndex_ReturnValueAtIndex()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = 1;
            int expected = index;
            JList<int> j = new JList<int>();

            // Act
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Assert
            int actual = j[index];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_InvalidIndex_IndexOutOfRangeException()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = 10;
            JList<int> j = new JList<int>();

            // Act
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Assert
            int actual = j[index];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_NegativeIndex_IndexOutOfRangeException()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = -1;
            JList<int> j = new JList<int>();

            // Act
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Assert
            int actual = j[index];
        }
    }
}
