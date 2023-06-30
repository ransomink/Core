using UnityEngine;

namespace Ransom
{
    public class SO_Variable<TType, TAsset> where TAsset : SO_RuntimeObject<TType>
    {
        [SerializeField] protected bool   _useValue  = true;
        [SerializeField] protected TType  _value = default;

        [Space]
        [SerializeField] protected bool   _editAsset = false;
        [SerializeField] protected TAsset _asset = default;

        private TAsset _reference = default;

        public TAsset Asset
        {
            get => _asset;
            set
            {
                _useValue = false;
                _asset = value;
            }
        }
        public bool IsValueDefined => (_useValue || _asset != null);
        public TType Value
        { 
            get
            {
                if (_useValue || _asset == null) { return _value; }
                return _asset.Value;
            }
            set
            {
                if (_useValue || _asset == null)
                {
                    _useValue = true;
                    _value = value;
                    return;
                }
                
                if (_asset != null) { _asset.Value = value; }
            }
        }

        public void UpdateAsset() => _reference = _asset;

        public static implicit operator TType(SO_Variable<TType, TAsset> variable) => variable.Value;
    }
}
