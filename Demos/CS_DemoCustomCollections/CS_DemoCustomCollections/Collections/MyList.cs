using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoCustomCollections.Collections
{
    internal class MyList<T>: IEnumerable<T> where T: struct
    {
        private T[] items;
        private int count;

        public MyList()
        {
            items = new T[2];
            count = 0;
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                Resize();
            }
            items[count++] = item;
        }
        private void Resize()
        {
            var newItems = new T[items.Length * 2];
            Array.Copy(items, newItems, items.Length);
            items = newItems;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => count;

        public int Capacity => items.Length;

        public T this[int index] //indexer
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                items[index] = value;
            }
        }
    }
}
