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

        public T this[int index]
        {
            get
            {
                if(index >= 0 && index < count)
                {
                    return data[index];
                }

                throw new IndexOutOfRangeException();
            }

            set
            {
                if(index >= 0 && index < count)
                {
                    data[index] = value;
                }

                throw new IndexOutOfRangeException();
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

        public void Insert(int index, T value)
        {

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
