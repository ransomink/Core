using System.Collections.Generic;
using UnityEngine;

namespace Ransom
{
    public abstract class SO_RuntimeSet<T> : ScriptableObject
    {
        [SerializeField] private List<T> _collection;
    
        public IReadOnlyList<T> Collection => _collection;

        private void Add(T item) => _collection.Add(item);

        private bool Remove(T item) => _collection.Remove(item);
    }
}
