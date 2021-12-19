using UnityEngine;

namespace Ransom
{
    public class Lifetime : CustomBehaviour
    {
        #region Fields
        [Header("LIFESPAN")]
        [SerializeField] private bool _isAlive;
        #endregion Fields

        #region Properties
        public bool IsAlive
        { 
            get
            {
                if (Birth == -1) return _isAlive = false;
                if (Death != -1) return _isAlive = false;
                return _isAlive = true;
            }
            private set => _isAlive = value; 
        }
        [field: SerializeField] public float Birth { get; private set; } = -1;
        [field: SerializeField] public float Death { get; private set; } = -1;
        public float Lifespan { get  => IsAlive ? StaticTime.ScaledTime - Birth : Death - Birth; }
        #endregion Properties
    
        #region Methods
        protected virtual void OnInit()
        {
            IsAlive = true;
            Birth   = StaticTime.ScaledTime;
        }

        protected virtual void DeInit()
        {
            IsAlive = false;
            Death   = StaticTime.ScaledTime;
        }
        #endregion Methods
    }
}
