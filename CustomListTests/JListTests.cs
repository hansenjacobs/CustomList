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
        public void Find_JListInJList_ReturnIndexWhereJListStarts()
        {
            // Arrange
            int itemsToAdd = 40;
            JList<int> j = new JList<int>();
            JList<int> find = new JList<int>();
            for(int i =0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }
            find.Add(5);
            find.Add(6);
            find.Add(7);
            find.Add(8);
            find.Add(9);
            find.Add(10);

            // Act
            int actual = j.Find(find);

            // Assert
            int expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_JListNotInJList_ReturnNegativeOne()
        {
            // Arrange
            int itemsToAdd = 40;
            JList<int> j = new JList<int>();
            JList<int> find = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }
            find.Add(50);
            find.Add(60);
            find.Add(70);
            find.Add(80);
            find.Add(90);
            find.Add(100);

            // Act
            int actual = j.Find(find);

            // Assert
            int expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_ProvideStartingIndex_ReturnsIndexOfFirstFound()
        {
            // Arrange
            JList<int> j = new JList<int>();
            j.Add(0);
            j.Add(1);
            j.Add(0);
            j.Add(1);
            j.Add(2);
            j.Add(3);

            // Act
            int actual = j.Find(1, 2);

            // Assert
            int expected = 3;
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
        public void Iteration_EmptyList_ForLoopResultsMatchForEachLoop()
        {
            // Arrange
            JList<int> j = new JList<int>();

            // Act
            string actual = "";
            foreach (int number in j)
            {
                actual += number.ToString() + ", ";
            }

            // Assert
            string expected = "";
            for (int i = 0; i < j.Count; i++)
            {
                expected += j[i].ToString() + ", ";
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Iteration_ListWitItems_ForLoopResultsMatchForEachLoop()
        {
            // Arrange
            int itemsToAdd = 40;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            string actual = "";
            foreach(int number in j)
            {
                actual += number.ToString() + ", ";
            }

            // Assert
            string expected = "";
            for(int i = 0; i < j.Count; i++)
            {
                expected += j[i].ToString() + ", ";
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorMinus_JListInJList_CountDecreases()
        {
            // Arrange
            int itemsToAdd = 40;
            JList<int> j = new JList<int>();
            for(int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }
            var k = new JList<int>() { 2, 3, 4, 5 };
            var l = new JList<int>();

            // Act
            l = j - k;

            // Assert
            int expected = j.Count - k.Count;
            int actual = l.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorMinus_JListInJList_ListIsRemoved()
        {
            // Arrange
            int itemsToAdd = 40;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }
            var k = new JList<int>() { 2, 3, 4, 5 };
            var l = new JList<int>();

            // Act
            l = j - k;

            // Assert
            bool itemsFound = false;
            for(int i = 0; i < l.Count; i++)
            {
                for(int index = 0; index < k.Count; index++)
                {
                    if(l[i] == k[index])
                    {
                        itemsFound = true;
                        break;
                    }
                }
                if (itemsFound) { break; }
            }
            Assert.IsFalse(itemsFound);
        }

        [TestMethod]
        public void OperatorMinus_JListNotInJList_CountRemainsSame()
        {
            // Arrange
            int itemsToAdd = 40;
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }
            var k = new JList<int>() { 2, 3, 4, 59 };
            var l = new JList<int>();

            // Act
            l = j - k;

            // Assert
            int expected = j.Count;
            int actual = l.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorPlus_OneEmptyLists_ContainsNonEmptyList()
        {
            // Arrange
            int itemsToAdd = 10;
            JList<int> j = new JList<int>();
            JList<int> k = new JList<int>();
            JList<int> l = new JList<int>();
            for(int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            l = j + k;

            // Assert
            bool validNewList = true;
            for (int i = 0; i < l.Count; i++)
            {
                if(i < j.Count)
                {
                    if(j[i] != l[i])
                    {
                        validNewList = false;
                        break;
                    }
                }
                else
                {
                    validNewList = false;
                    break;
                }
            }
            Assert.IsTrue(validNewList);
        }

        [TestMethod]
        public void OperatorPlus_TwoEmptyLists_CountEqualsZero()
        {
            // Arrange
            JList<int> j = new JList<int>();
            JList<int> k = new JList<int>();
            JList<int> l = new JList<int>();

            // Act
            l = j + k;

            // Assert
            int expected = j.Count + k.Count;
            int actual = l.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorPlus_TwoListsWithItems_CountEqualsSumOfCount()
        {
            // Arrange
            int itemsToAdd = 10;
            JList<int> j = new JList<int>();
            JList<int> k = new JList<int>();
            JList<int> l = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }
            for (int i = 0; i < itemsToAdd; i++)
            {
                k.Add(i*10);
            }

            // Act
            l = j + k;

            // Assert
            int expected = j.Count + k.Count;
            int actual = l.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OperatorPlus_TwoListsWithItems_NewListContainsBothOldLists()
        {
            // Arrange
            int itemsToAdd = 10;
            JList<int> j = new JList<int>();
            JList<int> k = new JList<int>();
            JList<int> l = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }
            for (int i = 0; i < itemsToAdd; i++)
            {
                k.Add(i * 10);
            }

            // Act
            l = j + k;

            // Assert
            bool validNewList = true;

            for (int i = 0; i < j.Count; i++)
            {
                if(j[i] != l[i])
                {
                    validNewList = false;
                    break;
                }
            }

            if (validNewList)
            {
                for (int i = 0; i < k.Count; i++)
                {
                    if(k[i] != l[i+j.Count])
                    {
                        validNewList = false;
                        break;
                    }
                }
            }

            Assert.IsTrue(validNewList);
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
        public void Sort_ListOfUnsortedValue_CountRemainsSame()
        {
            // Arrange
            var j = new JList<int>() { 5, 3, 7, 2, 6, 4, 1 };

            // Act
            int expected = j.Count;
            j = JList<int>.Sort<int>(j);

            // Assert
            int actual = j.Count;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Sort_ListOfUnsortedValues_StringOutputInSortedOrder()
        {
            // Arrange
            var j = new JList<int>() { 5, 3, 7, 2, 6, 4, 1 };

            // Act
            j = JList<int>.Sort<int>(j);

            // Assert
            string expected = "{ 1, 2, 3, 4, 5, 6, 7 }";
            string actual = j.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_MultipleItemsInList_OutputCSVString()
        {
            // Arrange
            int itemsToAdd = 10;
            string expected = "{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }";
            JList<int> j = new JList<int>();
            for (int i = 0; i < itemsToAdd; i++)
            {
                j.Add(i);
            }

            // Act
            string actual = j.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_NoItemsInList_EmptyString()
        {
            // Arrange
            string expected = "{  }";
            JList<int> j = new JList<int>();

            // Act
            string actual = j.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Zip_TwoEqualCountLists_CheckValues()
        {
            // Arrange
            var odd = new JList<int>() { 1, 3, 5, 7 };
            var even = new JList<int>() { 2, 4, 6, 8 };
            var numbers = new JList<int>();

            // Act
            numbers = JList<int>.Zip(odd, even);

            // Assert
            string expected = "{ 1, 2, 3, 4, 5, 6, 7, 8 }";
            string actual = numbers.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Zip_TwoUnequalCountLists_CountEqualSmallerListTimesTwo()
        {
            // Arrange
            var odd = new JList<int>() { 1, 3, 5, 7, 9, 11 };
            var even = new JList<int>() { 2, 4, 6, 8 };
            var numbers = new JList<int>();

            // Act
            numbers = JList<int>.Zip(odd, even);

            // Assert
            int expected = odd.Count < even.Count ? odd.Count * 2 : even.Count * 2;
            int actual = numbers.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Zip_TwoEqualCountLists_CountEqualsSumOfCount()
        {
            // Arrange
            var odd = new JList<int>() { 1, 3, 5, 7 };
            var even = new JList<int>() { 2, 4, 6, 8 };
            var numbers = new JList<int>();

            // Act
            numbers = JList<int>.Zip(odd, even);

            // Assert
            int expected = odd.Count + even.Count;
            int actual = numbers.Count;
            Assert.AreEqual(expected, actual);
        }

    }
}
