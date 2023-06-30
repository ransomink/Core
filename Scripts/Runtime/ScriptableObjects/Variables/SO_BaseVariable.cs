using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace Ransom
{
    public abstract class SO_BaseVariable<T> : ScriptableObject, INotifyPropertyChanged // where T : IEquatable<T>
    {
        #region Fields
        public event UnityAction<T> ValueChanged = delegate {};
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
        
        [Header("SETTINGS")]
        [SerializeField] private bool _readOnly  = false;
        [SerializeField] private bool _isClamped = false;
        [SerializeField] private bool _useDefaultValue = false;

        [Header("FIELDS")]
        [SerializeField] protected T _value = default(T);
        [SerializeField] protected T _defaultValue = default(T);
        [SerializeField] protected T _minClampedValue = default(T);
        [SerializeField] protected T _maxClampedValue = default(T);

        private T _oldValue;
        #endregion Fields
        
        #region Properties
        public virtual bool Clampable { get; } = false;

        public virtual T DefaultValue
        {
            get => _defaultValue;
            set => _defaultValue = value;
        }

        public virtual T MinClampedValue
        {
            get
            {
                if (!Clampable) { return default(T); }
                else { return _minClampedValue; }
            }
        }

        public virtual T MaxClampedValue
        {
            get
            {
                if (!Clampable) { return default(T); }
                else { return _maxClampedValue; }
            }
        }
        
        public virtual T Value
        {
            get => _value;
            set
            {
                _value = SetValue(value);
                // if (!EqualityComparer<T>.Default.Equals(_value, value))
                // {
                //     _value = value;
                //     // OnPropertyChanged();
                //     ValueChanged(_value);
                // }
            }
        }
        #endregion Properties

        #region Unity Callbacks
        protected virtual void OnEnable()
        {
            if (_useDefaultValue)
            {
                Clear();
                return;
            }

            _oldValue = _value;
        }
        #endregion Unity Callbacks

        #region Methods
        public virtual T SetValue(SO_BaseVariable<T> variable) => SetValue(variable.Value);

        public virtual T SetValue(T newValue)
        {
            if (_readOnly)
            {
                ReadOnlyWarning();
                return _value;
            }

            if (Clampable && !_isClamped)
            {
                newValue = ClampValue(newValue);
                _isClamped = true;
            }
            
            if (AreEqual(_oldValue, newValue)) { return _value; }
            
            // OnPropertyChanged();
            OnValueChanged(newValue);
            _oldValue = _value;
            return newValue;
        }

        protected virtual bool AreEqual(T a, T b)
        {
            if (a != null) { return a.Equals(b); }
            return b == null;
        }

        protected abstract T ClampValue(T value);

        protected void OnPropertyChanged([CallerMemberName] string name = null) 
        {
            // var handler = PropertyChanged;
            // var e = PropertyChangedEventArgs.Empty;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected void OnValueChanged(T value) => ValueChanged?.Invoke(value);

        private void Clear()
        {
            if (_useDefaultValue)
            {
                Value = _defaultValue;
                return;
            }

            Value = default;
        }

        private void ReadOnlyWarning()
        {
            if (!_readOnly) { return; }
            Debug.Log($"Attempted to set value on <color=magenta>{name}</color>, but value is readonly!", this);
        }

        public override string ToString() => (_value == null) ? "Null value." : _value.ToString();

        public static implicit operator T(SO_BaseVariable<T> variable) => variable.Value;
        #endregion Methods
    }
}
