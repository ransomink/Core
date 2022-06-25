using UnityEngine;

namespace Ransom
{
    public class CustomBehaviour : MonoBehaviour
    {
        #region Fields
        [SerializeField] private bool _isDestroyed;
        [SerializeField] private Transform _transform;
        #endregion Fields

        #region Properties
        public bool IsDestroyed => _isDestroyed = CheckIfDestroyed();
        public bool IsNull => this is null || this as object is null;
        protected Transform MyTransform => _transform;
        #endregion Properties
    
        #region Unity Callbacks
        protected virtual void Awake()
        {
            if (_transform == null) _transform = transform;
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
