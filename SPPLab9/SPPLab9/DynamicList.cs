using System;
using System.Collections;
using System.Collections.Generic;

namespace SPPLab9
{
    public class DynamicList<T> : IEnumerable<T>
    {

        private T[] arrayList { get; set; }
        public int count { get; set; }
        private const int size = 10;


        public DynamicList()
        {
            arrayList = new T[size];
        }

        public void Add(T element)
        {
            Resize();
            arrayList[count++] = element;
        }

        public void Remove(T element)
        {
            RemoveAt(Array.IndexOf(arrayList, element));
        }

        public void RemoveAt(int index)
        {
            var newContainer = new T[arrayList.Length - 1];
            Array.Copy(arrayList, newContainer, index);
            Array.Copy(arrayList, index + 1, newContainer, index, arrayList.Length - index - 1);
            arrayList = newContainer;
            count--;
        }

        public void Clear()
        {
            arrayList = Array.Empty<T>();
            count = 0;
        }

        private void Resize()
        {
            if (count != arrayList.Length)
            {
                return;
            }

            T[] tmpContainer = new T[arrayList.Length + size];
            Array.Copy(arrayList, tmpContainer, arrayList.Length);
            arrayList = tmpContainer;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < count; i++)
            {
                yield return arrayList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
