using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class JList<T> : IEnumerable<T>
    {
        static int capacityIncrementor = 5;

        T[] data;
        int count;
        int capacity;

        public JList()
        {
            count = 0;
            data = new T[5];
            capacity = 5;
        }

        public T this[int index]
        {
            get
            {
                if(index >= 0 && index < count)
                {
                    return data[index];
                }

                throw new ArgumentOutOfRangeException();
            }

            set
            {
                if(index >= 0 && index < count)
                {
                    data[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public static int CapacityIncrementor
        {
            get { return capacityIncrementor; }
        }

        public int Count
        {
            get { return count; }
        }

        public static JList<T> operator+ (JList<T> listA, JList<T> listB)
        {
            JList<JList<T>> jlists = new JList<JList<T>>();
            JList<T> output = new JList<T>();

            jlists.Add(listA);
            jlists.Add(listB);

            for(int i = 0; i < jlists.Count; i++)
            {
                for (int j = 0; j < jlists[i].Count; j++)
                {
                    output.Add(jlists[i][j]);
                }
            }

            return output;
        }

        public static JList<T> operator- (JList<T> listA, JList<T> listB)
        {
            JList<T> output = new JList<T>();
            int indexFound = listA.Find(listB);

            if(indexFound != -1)
            {
                int indexFoundEnd = indexFound + listB.Count - 1;
                for(int i = 0; i < listA.Count; i++)
                {
                    if(i < indexFound || i > indexFoundEnd)
                    {
                        output.Add(listA[i]);
                    }
                }
            }
            else
            {
                for(int i = 0; i < listA.Count; i++)
                {
                    output.Add(listA[i]);
                }
            }
            
            return output;
        }

        public void Add(T value)
        {
            if(IsNearCapacity(1))
            {
                IncreaseCapacity(count + 1);
            }

            data[count] = value;
            count++;
        }

        public int Find(T value)
        {
            int index = -1;

            for(int i = 0; i < count; i++)
            {
                if (data[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public int Find(T value, int startingIndex)
        {
            int index = -1;

            for(int i = startingIndex; i < count; i++)
            {
                if (data[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public int Find(JList<T> findJList)
        {
            int index = -2;
            int searchFromIndex = 0;

            do
            {
                int foundIndex = Find(findJList[0], searchFromIndex);
                if(foundIndex != -1  && foundIndex + findJList.count - 1 < count)
                {
                    int findJListIndex = 1;

                    for (int i = foundIndex + 1; i < foundIndex + findJList.Count; i++, findJListIndex++)
                    {
                        index = foundIndex;

                        if (!data[i].Equals(findJList[findJListIndex]))
                        {
                            searchFromIndex = foundIndex + 1;
                            index = -2;
                            break;
                        }
                    }
                }
                else
                {
                    index = -1;
                }

            } while (index == -2);

            return index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Insert(int index, T value)
        {
            if(index >= 0 && index < count)
            {
                if (IsNearCapacity(1))
                {
                    IncreaseCapacity(count + 1);
                }

                for (int i = count; i >= index; i--)
                {
                    data[i] = data[i - 1];
                }

                data[index] = value;
                count++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private bool IsNearCapacity(int expectedCountIncrease)
        {
            return Convert.ToDouble(count + expectedCountIncrease) >= 0.6;
        }

        private void IncreaseCapacity(int newCount)
        {
            int newCapacity = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(newCount * 2) / capacityIncrementor) * capacityIncrementor);

            T[] temporaryArray = new T[newCapacity];
            for(int i = 0; i < count; i++)
            {
                temporaryArray[i] = data[i];
            }

            data = temporaryArray;
            capacity = newCapacity;
        }

        public void Remove(T value)
        {
            int index = Find(value);

            if(index >= 0 && index < count)
            {
                RemoveAt(index);
            }
            else if(index != -1)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void RemoveAt(int index)
        {
            if(index >= 0 && index < count)
            {
                for (int i = index; i < count; i++)
                {
                    if (i != count - 1)
                    {
                        data[i] = data[i + 1];
                    }
                    else
                    {
                        data[i] = default(T);
                    }
                }
                count--;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }


        public static JList<U> Sort<U>(JList<U> list) where U : IComparable
        {
            bool didSwap = false;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].CompareTo(list[i + 1]) > 0)
                {
                    didSwap = true;
                    U temporary = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = temporary;
                }
            }

            if (didSwap)
            {
                return JList<U>.Sort<U>(list);
            }
            else
            {
                return list;
            }
        }

        public override string ToString()
        {
            string output = "{ ";

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    output += data[i].ToString() + ", ";
                }

                output = output.Substring(0, output.Length - 2);
            }

            return output + " }";
        }

        public static JList<T> Zip(JList<T> listA, JList<T> listB)
        {
            var output = new JList<T>();
            int smallestCount = listA.Count < listB.Count ? listA.Count : listB.Count;

            for(int i = 0; i < smallestCount; i++)
            {
                output.Add(listA[i]);
                output.Add(listB[i]);
            }

            return output;
        }
    }
}
