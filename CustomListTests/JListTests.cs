using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomList;

namespace CustomListTests
{
    [TestClass]
    public class JListTests
    {
        [TestMethod]
        public void Add_AddItem_CapacityIncreased()
        {
            // Arrange
            JList<int> j = new JList<int>();
            int itemsToAdd = 9;

            // Act
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Assert
            int expected = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(itemsToAdd * 2) / JList<int>.CapacityIncrementor) * JList<int>.CapacityIncrementor);
            int actual = j.Capacity;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItem_CountIncreasesByOne()
        {
            // Arrange
            JList<int> j = new JList<int>();

            // Act
            j.Add(10);

            // Assert
            int expected = 1;
            int actual = j.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItem_ItemAddedToEnd()
        {
            // Arrange
            int expected = 20;
            JList<int> j = new JList<int>();

            // Act
            j.Add(10);
            j.Add(expected);

            // Assert
            int actual = j[j.Count - 1];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_ValueNotInList_ReturnsNegativeOne()
        {
            // Arrange
            JList<int> j = new JList<int>();
            j.Add(0);
            j.Add(1);
            j.Add(1);
            j.Add(2);
            j.Add(3);

            // Act
            int actual = j.Find(4);

            // Assert
            int expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_ValueInList_ReturnsIndexOfFirstFound()
        {
            // Arrange
            JList<int> j = new JList<int>();
            j.Add(0);
            j.Add(1);
            j.Add(1);
            j.Add(2);
            j.Add(3);

            // Act
            int actual = j.Find(1);

            // Assert
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Insert_InvalidIndex_IndexOutOfRangeException()
        {
            // Arrange
            int itemsToAdd = 40;
            int index = 40;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            j.Insert(index, 100);

            // Assert
        }

        [TestMethod]
        public void Insert_ValidIndex_CountIncreases()
        {
            // Arrange
            int itemsToAdd = 40;
            int index = 19;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            int expected = j.Count + 1;
            j.Insert(index, 100);

            // Assert
            int actual = j.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_ValidIndex_ValueAppearsAtSpecifiedIndex()
        {
            // Arrange
            int itemsToAdd = 40;
            int index = 19;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            int expected = 100;
            j.Insert(index, expected);

            // Assert
            int actual = j[index];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_ValidIndex_ValueAtIndexMovesRight()
        {
            // Arrange
            int itemsToAdd = 40;
            int index = 19;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            int expected = j[index];
            j.Insert(index, 100);

            // Assert
            int actual = j[index + 1];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_ValidIndex_ValueAtLeftRemainsSame()
        {
            // Arrange
            int itemsToAdd = 40;
            int index = 19;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            int expected = j[index - 1];
            j.Insert(index, 100);

            // Assert
            int actual = j[index - 1];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_ValueInList_ValueIsRemoved()
        {
            // Arrange
            JList<int> j = new JList<int>();
            j.Add(0);
            j.Add(1);
            j.Add(2);
            j.Add(3);
            j.Add(4);

            // Act
            j.Remove(2);

            // Assert
            int expected = -1;
            int actual = j.Find(2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_ValueNotInList_ListCountRemainsUnchanged()
        {
            // Arrange
            JList<int> j = new JList<int>();
            j.Add(0);
            j.Add(1);
            j.Add(2);
            j.Add(3);
            j.Add(4);
            int expected = j.Count;

            // Act
            j.Remove(5);

            // Assert
            int actual = j.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_InvalidIndex_IndexOutOfRangeException()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = 10;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            j.RemoveAt(index);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_NegativeIndex_IndexOutOfRangeException()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = -1;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            j.RemoveAt(index);

            // Assert

        }

        [TestMethod]
        public void RemoveAt_RemoveMiddleIndex_CountDecreasesByOne()
        {
            // Arrange
            int itemsToAdd = 4;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            j.RemoveAt(1);

            // Assert
            int expected = itemsToAdd - 1;
            int actual = j.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveMiddleIndex_IndexToLeftRemainsSame()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = 1;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            int expected = j[index - 1];

            // Act
            j.RemoveAt(index);

            // Assert
            int actual = j[index - 1];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveMiddleIndex_IndexToRightShiftLeftOne()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = 1;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }
            int expected = j[index + 1];

            // Act
            j.RemoveAt(index);

            // Assert
            int actual = j[index];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_InvalidIndex_IndexOutOfRangeException()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = 10;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            int actual = j[index];

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_NegativeIndex_IndexOutOfRangeException()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = -1;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            int actual = j[index];

            // Assert

        }

        [TestMethod]
        public void Indexer_ValidIndex_ReturnValueAtIndex()
        {
            // Arrange
            int itemsToAdd = 4;
            int index = 1;
            int expected = index;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            int actual = j[index];

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
