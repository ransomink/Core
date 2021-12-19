using System;
using System.Collections;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Ransom
{
    [DefaultExecutionOrder(-500)]
    public class UpdateManager : Singleton<UpdateManager>
    {
        #region Fields
        public static event Action OnUpdate = delegate {};
        public static event Action OnLateUpdate  = delegate {};
        public static event Action OnFixedUpdate = delegate {};
        #endregion Fields
        
        #region Constructors
        // Automatically create UnityUpdateManager when invoked in any way
        static UpdateManager()
        {
            // Clean up our instance while inside the Editor to prevent runtime errors
            #if UNITY_EDITOR
            EditorApplication.playModeStateChanged += (x) =>
            {
                if (x == PlayModeStateChange.ExitingPlayMode)
                {
                    if (!(Instance is null)) Destroy(Instance);
                }
            };
            #endif

            GameObject go = new GameObject("UnityUpdateManager", typeof(UpdateManager));
            go.hideFlags  = HideFlags.HideAndDontSave;
        }
        #endregion Constructors

        #region Unity Callbacks
        private void Update() => OnUpdate();
        private void LateUpdate()  => OnLateUpdate();
        private void FixedUpdate() => OnFixedUpdate();
        #endregion Unity Callbacks

        #region Methods
        public static Coroutine StartGlobalCoroutine(IEnumerator coroutine) => Instance.StartCoroutine(coroutine);
        public static void StopGlobalCoroutine(Coroutine coroutine) => Instance.StopCoroutine(coroutine);
        #endregion Methods
    }
}
