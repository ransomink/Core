using UnityEngine;

namespace Ransom
{
    public sealed class Lifetime : CustomBehaviour
    {
        #region Fields
        [Header("LIFESPAN")]
        [SerializeField] private bool _restartOnEnable = true;
        [SerializeField] private bool _isAlive = default;
        #endregion Fields

        #region Properties
        [field: SerializeField] public float Birth { get; private set; } = -1f;
        [field: SerializeField] public float Death { get; private set; } = -1f;
        public bool IsAlive
        { 
            get
            {
                if (_isAlive) { return true; }
                if (Birth == -1f) { return _isAlive = false; }
                if (Death != -1f) { return _isAlive = false; }
                return _isAlive = true;
            }
            private set => _isAlive = value;
        }
        public float Lifespan
        {
            get
            {
                if (IsAlive) { return StaticTime.UnscaledTime - Birth; }
                return (Death - Birth);
            }
        }
        #endregion Properties

        #region Unity Callbacks
        private void Reset()
        {
            IsAlive = default;
            Birth = -1;
            Death = -1;
        }

        private void OnEnable()
        {
            if (!_restartOnEnable) return;
            OnInit();
        }

        private void OnDisable()
        {
            if (!_restartOnEnable) return;
            DeInit();
        }
        #endregion Unity Callbacks
    
        #region Methods
        public void OnInit()
        {
            Reset();
            IsAlive = true;
            Birth   = StaticTime.UnscaledTime;
        }

        public void DeInit()
        {
            IsAlive = false;
            Death   = StaticTime.UnscaledTime;
        }
        #endregion Methods
    }
}
