using UnityEngine;

namespace Ransom
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        #region Fields
        private static bool _isActive = true;
        private static T    _instance = null;
        #endregion Fields

        #region Properties
        public  static T Instance
        {
            get
            {
                if (!_isActive)
                {
                    Debug.LogWarning($"Singleton Instance <color=orange>{typeof(T)}</color> is already destroyed. Returning null.");
                    return null;
                }
                
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null) _instance = CreateInstance();
                }

                return _instance;
            }
        }
        #endregion Properties

        #region Unity Callbacks
        protected virtual void Awake()
        {
            if ((_instance != null))
            {
                Destroy(gameObject);
                return;
            }
            _instance = this as T;
            DontDestroyOnLoad(this);
        }

        private void OnApplicationQuit() => Deactivate();

        // private void OnDestroy() => Deactivate();
        #endregion Unity Callbacks
        
        #region Methods
        protected static T CreateInstance()
        {
            var name = $"{typeof(T).ToString()}Instance";
            return CreateInstance(name);
        }

        protected static T CreateInstance(string name)
        {
            var go = new GameObject(name);
            go.hideFlags = HideFlags.HideAndDontSave;
            var instance = go.AddComponent<T>();
            DontDestroyOnLoad(go);
            return instance;
        }

        private void Deactivate() => _isActive = false;
        #endregion Methods
    }
}
