using System.Collections.Generic;
using UnityEngine;

namespace Ransom
{
    public class SO_ExecutionOrder : Singleton<SO_ExecutionOrder>
    {
        #region Fields
        [SerializeField] private List<SO_Manager> _start;
        [SerializeField] private List<SO_Manager> _fixedUpdate;
        [SerializeField] private List<SO_Manager> _baseUpdate;
        [SerializeField] private List<SO_Manager> _lateUpdate;
        [SerializeField] private List<SO_Manager> _destroy;
        #endregion Fields
        
        #region Unity Callbacks
        protected virtual void OnEnable()
        {
            UpdateDispatcher.OnFixedUpdate += OnFixedUpdate;
            UpdateDispatcher.OnUpdate      += OnUpdate;
            UpdateDispatcher.OnLateUpdate  += OnLateUpdate;
        }

        protected virtual void OnDisable()
        {
            UpdateDispatcher.OnFixedUpdate -= OnFixedUpdate;
            UpdateDispatcher.OnUpdate      -= OnUpdate;
            UpdateDispatcher.OnLateUpdate  -= OnLateUpdate;
        }

        protected virtual void Start()
        {
            if (_start is null) { return; }

            var count = _start.Count;
            for (var i = 0; i < count; ++i) _start[i].OnStart();
        }

        protected virtual void OnFixedUpdate()
        {
            if (_fixedUpdate is null) { return; }

            var count = _fixedUpdate.Count;
            for (var i = 0; i < count; ++i) _fixedUpdate[i].OnFixedUpdate();
        }

        protected virtual void OnUpdate()
        {
            if (_baseUpdate is null) { return; }

            var count = _baseUpdate.Count;
            for (var i = 0; i < count; ++i) _baseUpdate[i].OnUpdate();
        }

        protected virtual void OnLateUpdate()
        {
            if (_lateUpdate is null) { return; }

            var count = _lateUpdate.Count;
            for (var i = 0; i < count; ++i) _lateUpdate[i].OnLateUpdate();
        }

        protected virtual void OnDestroy()
        {
            if (_destroy is null) { return; }

            var count = _destroy.Count;
            for (var i = 0; i < count; ++i) _destroy[i].OnDestroy();
        }
        #endregion Unity Callbacks
    }
}
