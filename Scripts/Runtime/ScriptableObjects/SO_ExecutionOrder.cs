using System.Collections.Generic;
using UnityEngine;

namespace Ransom
{
    public class SO_ExecutionOrder : Singleton<SO_ExecutionOrder>
    {
        #region Fields
        [SerializeField] private List<SO_Manager> _start = new List<SO_Manager>();
        [SerializeField] private List<SO_Manager> _fixedUpdate = new List<SO_Manager>();
        [SerializeField] private List<SO_Manager> _baseUpdate = new List<SO_Manager>();
        [SerializeField] private List<SO_Manager> _lateUpdate = new List<SO_Manager>();
        [SerializeField] private List<SO_Manager> _destroy = new List<SO_Manager>();
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
            var count = _start.Count;
            if (count == 0) { return; }

            for (var i = 0; i < count; ++i) _start[i].OnStart();
        }

        protected virtual void OnFixedUpdate()
        {
            var count = _fixedUpdate.Count;
            if (count == 0) { return; }

            for (var i = 0; i < count; ++i) _fixedUpdate[i].OnFixedUpdate();
        }

        protected virtual void OnUpdate()
        {
            var count = _baseUpdate.Count;
            if (count == 0) { return; }

            for (var i = 0; i < count; ++i) _baseUpdate[i].OnUpdate();
        }

        protected virtual void OnLateUpdate()
        {
            var count = _lateUpdate.Count;
            if (count == 0) { return; }

            for (var i = 0; i < count; ++i) _lateUpdate[i].OnLateUpdate();
        }

        protected virtual void OnDestroy()
        {
            var count = _destroy.Count;
            if (count == 0) { return; }

            for (var i = 0; i < count; ++i) _destroy[i].OnDestroy();
        }
        #endregion Unity Callbacks
    }
}
