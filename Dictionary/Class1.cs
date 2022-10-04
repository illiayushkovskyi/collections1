using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class KeyValuePair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }

    internal class MyDictionaryIsFullException : Exception
    {
        public MyDictionaryIsFullException(string message) : base(message)
        {
        }
    }

    class MyDictionary<TKey, TValue> : IEnumerable, IEnumerator
    {
        private KeyValuePair<TKey, TValue>[] array;

        int position = -1;
        public int Count { get; private set; } = 0;
        public object Current => array[position];

        public void Add(TKey key, TValue value)
        {
            if (Count >= array.Length)
                throw new MyDictionaryIsFullException("MyDictionary is full");
            array[Count] = new KeyValuePair<TKey, TValue> { Key = key, Value = value };
            Count++;
        }


        public TValue this[TKey index]
        {
            get
            {
                foreach (var item in array)
                {
                    if (Equals(item.Key, index))
                    {
                        return item.Value;
                    }
                }

                throw new KeyNotFoundException();
            }
            set
            {
                foreach (var item in array)
                {
                    if (Equals(item.Key, index))
                    {
                        item.Value = value;
                    }
                }

                throw new KeyNotFoundException();
            }
        }

      

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position < Count - 1)
            {
                position++;
                return true;
            }

            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}