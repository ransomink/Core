using UnityEngine;

namespace Ransom
{
    public abstract class SO_NumericObject<T> : SO_ValueObject<T> where T : struct
    {
        #region Fields
        [Header("SETTINGS")]
        [SerializeField] private bool _useClamp = false;
        [SerializeField] private bool _useMinClamp = false;
        [SerializeField] private bool _useMaxClamp = false;

        // [Header("FIELDS")]
        [SerializeField] protected T _minClampedValue = default(T);
        [SerializeField] protected T _maxClampedValue = default(T);
        #endregion Fields
        
        #region Properties
        public virtual T MinClampedValue
        {
            get
            {
                if (!_useClamp || !_useMinClamp) { return default(T); }
                return _minClampedValue;
            }
        }
        public virtual T MaxClampedValue
        {
            get
            {
                if (!_useClamp || !_useMaxClamp) { return default(T); }
                return _maxClampedValue;
            }
        }
        public bool UseMinClamp => _useMinClamp;
        public bool UseMaxClamp => _useMaxClamp;
        #endregion Properties

        #region Methods
        protected abstract T ClampValue(T value);

        public override T SetValue(T newValue)
        {
            if (IsReadOnly)
            {
                ReadOnlyWarning();
                return _value;
            }

            if (_useClamp)
            {
                newValue  = ClampValue(newValue);
                _useClamp = true;
            }
            
            if (AreEqual(_oldValue, newValue)) { return _value; }
            
            OnValueChanged(newValue);
            _oldValue = _value;
            return newValue;
        }
        #endregion Methods
    }
}
