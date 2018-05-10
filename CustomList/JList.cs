using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class JList<T>
    {
        static int capacityIncrement = 5;

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

        public static int CapacityIncrement
        {
            get { return capacityIncrement; }
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

        }

        public void Insert(int index, T value)
        {

        }

        public void Remove(T value)
        {

        }

        public void RemoveAt(int index)
        {

        }

    }
}
