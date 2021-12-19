using UnityEngine;

namespace Ransom
{
    public class CustomBehaviour : MonoBehaviour
    {
        #region Fields
        [SerializeField] private bool _isDestroyed;
        private Transform _transform;
        #endregion Fields

        #region Properties
        public bool IsDestroyed => _isDestroyed = CheckIfDestroyed();
        protected Transform MyTransform => _transform;
        #endregion Properties
    
        #region Unity Callbacks
        protected virtual void Awake()
        {
            _transform = transform;
        }
        #endregion Unity Callbacks

        #region Methods
        private bool CheckIfDestroyed()
        {
            var target = this as UnityEngine.Object;
            return (!ReferenceEquals(target, null) && target is null);
        }
        #endregion
    }
}
