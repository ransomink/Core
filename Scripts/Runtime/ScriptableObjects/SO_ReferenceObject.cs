using UnityEngine;

namespace Ransom
{
    public abstract class SO_ReferenceObject<T> : SO_RuntimeObject<T> where T : class
    {
        [SerializeField] protected bool _hasAssetReference = false;
        [SerializeField] private T _reference = default;

        public bool HasAssetReference => _hasAssetReference;
        public T Reference => _reference;
        public override T Value { get => Reference; set => SetReference(value); }
    
        public void SetReference(T reference) => _reference = reference;

        public override void Clear()
        {
            if (_hasAssetReference) { return; }

            _reference = null;
        }
    }
}
