using UnityEngine;

namespace Ransom
{
    public abstract class CustomBehaviour : MonoBehaviour, IUpdate, ILateUpdate, IFixedUpdate
    {
        #region Fields
        [Header("BASE")]
        [SerializeField] protected Transform _transform = default;
        [SerializeField] private bool _isDestroyed = false;

        [Header("SETTINGS")]
        [SerializeField] private bool _useBaseUpdate  = false;
        [SerializeField] private bool _useLateUpdate  = false;
        [SerializeField] private bool _useFixedUpdate = false;
        #endregion Fields

        #region Properties
        public bool IsDestroyed
        {
            get 
            {
                if (_isDestroyed) { return true; }

                _isDestroyed = CheckIfDestroyed();

                return _isDestroyed;
            }
        }
        #endregion Properties
    
        #region Unity Callbacks
        protected virtual void Awake()
        {
            if (_transform == null) { _transform = transform; }
        }

        private void OnEnable()
        {
            if (_useBaseUpdate) { UpdateDispatcher.Instance.BaseUpdateCollection.Add(this); }
            if (_useLateUpdate) { UpdateDispatcher.Instance.LateUpdateCollection.Add(this); }
            if (_useFixedUpdate) { UpdateDispatcher.Instance.FixedUpdateCollection.Add(this); }
        }

        private void OnDisable()
        {
            if (_useBaseUpdate) { UpdateDispatcher.Instance.BaseUpdateCollection.Remove(this); }
            if (_useLateUpdate) { UpdateDispatcher.Instance.LateUpdateCollection.Remove(this); }
            if (_useFixedUpdate) { UpdateDispatcher.Instance.FixedUpdateCollection.Remove(this); }
        }

        public virtual void OnFixedUpdate() {}
        
        public virtual void OnUpdate() {}

        public virtual void OnLateUpdate() {}
        #endregion Unity Callbacks

        #region Methods
        public bool CheckIfDestroyed()
        {
            var uo = this as UnityEngine.Object;
            return /*((object)uo is null) &&*/ uo == null;
        }

        public void SetToDestroy() => _isDestroyed = true;
        #endregion
    }
}
