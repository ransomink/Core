using UnityEngine;

namespace Ransom
{
    public abstract class SO_BaseReference<TType, TAsset> where TAsset : SO_BaseVariable<TType>
    {
        [SerializeField] protected bool   _useValue  = true;
        [SerializeField] protected TType  _value;

        [Space]
        [SerializeField] protected bool   _editAsset = false;
        [SerializeField] protected TAsset _asset;

        private TAsset _reference;

        public TAsset Asset
        {
            get => _asset;
            set
            {
                _useValue = false;
                _asset = value;
            }
        }

        public bool IsValueDefined => _useValue || _asset != null;

        public TType Value
        { 
            get
            {
                if (_useValue || ReferenceEquals(_asset, null)) return _value;
                return _asset.Value;
            }
            set
            {
                // if (_useValue || ReferenceEquals(_asset, null)) _value = value;
                // else _asset.Value = value;
                if (!_useValue && !ReferenceEquals(_asset, null)) _asset.Value = value;
                else
                {
                    _useValue = true;
                    _value = value;
                }
            }
        }

        public void UpdateAsset() => _reference = _asset;

        public static implicit operator TType(SO_BaseReference<TType, TAsset> reference) => reference.Value;
    }
}
