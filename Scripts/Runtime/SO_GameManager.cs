using System.Collections.Generic;
using UnityEngine;

namespace Ransom
{
    public class SO_GameManager : Singleton<GameManager>
    {
        #region Fields
        // [SerializeField] private SO_UpdateEvent _baseUpdate;
        // [SerializeField] private SO_UpdateEvent _lateUpdate;
        // [SerializeField] private SO_UpdateEvent _fixedUpdate;
        [SerializeField] private List<Manager> _start;
        [SerializeField] private List<Manager> _baseUpdate;
        [SerializeField] private List<Manager> _lateUpdate;
        [SerializeField] private List<Manager> _fixedUpdate;
        [SerializeField] private List<Manager> _destroy;
        #endregion Fields
        
        #region Unity Callbacks
        protected virtual void OnEnable()
        {
            UpdateManager.OnFixedUpdate += OnFixedUpdate;
            UpdateManager.OnUpdate      += OnUpdate;
            UpdateManager.OnLateUpdate  += OnLateUpdate;
        }

        protected virtual void OnDisable()
        {
            UpdateManager.OnFixedUpdate -= OnFixedUpdate;
            UpdateManager.OnUpdate      -= OnUpdate;
            UpdateManager.OnLateUpdate  -= OnLateUpdate;
        }

        protected virtual void Start()
        {
            if (ReferenceEquals(_start, null)) return;
            var count = _start.Count;
            for (var i = 0; i < count; ++i) _start[i].OnStart();
        }

        protected virtual void OnFixedUpdate()
        {
            if (ReferenceEquals(_fixedUpdate, null)) return;
            var count = _fixedUpdate.Count;
            for (var i = 0; i < count; ++i) _fixedUpdate[i].OnFixedUpdate();
        }

        protected virtual void OnUpdate()
        {
            if (ReferenceEquals(_baseUpdate, null)) return;
            var count = _baseUpdate.Count;
            for (var i = 0; i < count; ++i) _baseUpdate[i].OnUpdate();
        }

        protected virtual void OnLateUpdate()
        {
            if (ReferenceEquals(_lateUpdate, null)) return;
            var count = _lateUpdate.Count;
            for (var i = 0; i < count; ++i) _lateUpdate[i].OnLateUpdate();
        }

        protected virtual void OnDestroy()
        {
            if (ReferenceEquals(_destroy, null)) return;
            var count = _destroy.Count;
            for (var i = 0; i < count; ++i) _destroy[i].OnDestroy();
        }
        #endregion Unity Callbacks
    }
}
