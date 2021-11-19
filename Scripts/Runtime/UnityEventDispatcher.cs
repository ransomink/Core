using System;
using System.Collections;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Ransom
{
    [DefaultExecutionOrder(-500)]
    public class UnityEventDispatcher : MonoBehaviour
    {
        #region Fields
        private static UnityEventDispatcher _instance;

        public static event Action OnUpdate      = delegate {};
        public static event Action OnLateUpdate  = delegate {};
        public static event Action OnFixedUpdate = delegate {};
        #endregion Fields
        
        #region Constructors
        // Automatically create UnityEventDispatcher when invoked in any way
        static UnityEventDispatcher()
        {
            // Clean up our instance while inside the Editor to prevent runtime errors
            #if UNITY_EDITOR
            EditorApplication.playModeStateChanged += (x) =>
            {
                if (x == PlayModeStateChange.ExitingPlayMode)
                {
                    if (_instance != null) Destroy(_instance);
                }
            };
            #endif

            GameObject go = new GameObject("UnityEventDispatcher", typeof(UnityEventDispatcher));
            // Hide our shameful disregard of Unity best practices
            go.hideFlags  = HideFlags.HideAndDontSave;
        }
        #endregion Constructors

        #region Unity Callbacks
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()      => OnUpdate();

        private void LateUpdate()  => OnLateUpdate();

        private void FixedUpdate() => OnFixedUpdate();
        #endregion Unity Callbacks

        #region Methods
        // Global coroutine helper function
        public static Coroutine StartGlobalCoroutine(IEnumerator coroutine)
        {
            return _instance.StartCoroutine(coroutine);
        }
        #endregion Methods
    }
}
