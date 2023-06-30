using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ransom
{
    public abstract class SO_RuntimeSet<T> : SO_RuntimeObject, IList<T>
    {
        [SerializeField] protected List<T> _items;

        public T this[int index] { get => _items[index]; set => _items[index] = value; }

        public IReadOnlyList<T> Items => _items;

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        public override void Clear() => _items.Clear();

        public bool Contains(T item) => _items.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

        public int IndexOf(T item) => _items.IndexOf(item);

        public void Insert(int index, T item) => _items.Insert(index, item);

        public void RemoveAt(int index) => _items.RemoveAt(index);

        private void Add(T item) => _items.Add(item);

        void ICollection<T>.Add(T item) => Add(item);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private bool Remove(T item) => _items.Remove(item);

        bool ICollection<T>.Remove(T item) => Remove(item);
    }
}
