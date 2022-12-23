using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ransom
{
    [DefaultExecutionOrder(-500)]
    public sealed class UpdateDispatcher : Singleton<UpdateDispatcher>
    {
        #region Fields
        private readonly List<IUpdate> _baseUpdate = new List<IUpdate>(1024);
        private readonly List<ILateUpdate> _lateUpdate = new List<ILateUpdate>(256);
        private readonly List<IFixedUpdate> _fixedUpdate = new List<IFixedUpdate>(512);

        public static event Action OnUpdate = delegate {};
        public static event Action OnLateUpdate  = delegate {};
        public static event Action OnFixedUpdate = delegate {};
        #endregion Fields

        #region Properties
        public List<IUpdate> BaseUpdateCollection => _baseUpdate;
        public List<ILateUpdate> LateUpdateCollection => _lateUpdate;
        public List<IFixedUpdate> FixedUpdateCollection => _fixedUpdate;
        #endregion Properties
        
        #region Unity Callbacks
        private void Update()
        {
            OnUpdate?.Invoke();

            var count = _baseUpdate.Count;
            if (count == 0) { return; }

            for (var i = 0; i < count; ++i) _baseUpdate[i].OnUpdate();
        }

        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();

            var count = _lateUpdate.Count;
            if (count == 0) { return; }

            for (var i = 0; i < count; ++i) _lateUpdate[i].OnLateUpdate();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();

            var count = _fixedUpdate.Count;
            if (count == 0) { return; }

            for (var i = 0; i < count; ++i) _fixedUpdate[i].OnFixedUpdate();
        }
        #endregion Unity Callbacks

        #region Methods
        public static Coroutine StartGlobalCoroutine(IEnumerator coroutine) => Instance.StartCoroutine(coroutine);
        public static void StopGlobalCoroutine(IEnumerator coroutine) => Instance.StopCoroutine(coroutine);
        public static void StopGlobalCoroutine(Coroutine coroutine) => Instance.StopCoroutine(coroutine);
        #endregion Methods
    }
}
