using UnityEngine;
using UnityEngine.Events;

namespace Ransom
{
    public abstract class SO_ValueObject<T> : SO_RuntimeObject<T> where T : struct
    {
        #region Fields
        public event UnityAction<T> ValueChanged = delegate {};
        
        // [Header("SETTINGS")]
        [SerializeField] private bool _isReadOnly = false;
        [SerializeField] private bool _useDefaultValue = false;

        // [Header("FIELDS")]
        [SerializeField] protected T _defaultValue = default(T);
        [SerializeField] protected T _value = default(T);

        protected T _oldValue;
        #endregion Fields
        
        #region Properties
        public virtual T DefaultValue { get => _defaultValue; set => _defaultValue = value; }
        public bool  IsReadOnly { get => _isReadOnly; set => _isReadOnly = value; }
        public override T Value { get => _value; set => _value = SetValue(value); }
        public T   RuntimeValue { get; set; }
        #endregion Properties

        #region Unity Callbacks
        // public void OnAfterDeserialize()
        // {
        //     OnEnable();
        //     RuntimeValue = Value;
        // }

        // public void OnBeforeSerialize() {}
        protected void OnEnable() => Clear();
        #endregion Unity Callbacks

        #region Methods
        public override void Clear()
        {
            if (_useDefaultValue)
            {
                Value = _defaultValue;
                return;
            }

            Value = default;
        }

        public virtual T SetValue(SO_ValueObject<T> obj) => SetValue(obj.Value);

        public virtual T SetValue(T newValue)
        {
            if (_isReadOnly)
            {
                ReadOnlyWarning();
                return _value;
            }

            if (AreEqual(_oldValue, newValue)) { return _value; }
            
            OnValueChanged(newValue);
            _oldValue = _value;
            return newValue;
        }

        protected virtual bool AreEqual(T a, T b) => a.Equals(b);

        protected void OnValueChanged(T value) => ValueChanged?.Invoke(value);

        protected void ReadOnlyWarning()
        {
            if (!_isReadOnly) { return; }
            Debug.Log($"<color=yellow><b>[WARNING]</b></color> Attempted to set value on <color=magenta>{name}</color> but value is readonly!", this);
        }

        public override string ToString() => _value.ToString();

        public static implicit operator T(SO_ValueObject<T> obj) => obj.Value;
        #endregion Methods
    }
}
