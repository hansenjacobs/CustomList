using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class JList<T>
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

        public T this[int index]
        {
            get { return data[index]; }
            private set { data[index] = value; }
        }

        public void Add(T value)
        {
            if(isNearCapacity(1))
            {
                IncreaseCapacity(count + 1);
            }

            data[count] = value;
            count++;
        }

        private bool isNearCapacity(int expectedCountIncrease)
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

        public void Insert(int index, T value)
        {

        }

        public void Remove(T value)
        {

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
                throw new IndexOutOfRangeException();
            }

        }

    }
}
