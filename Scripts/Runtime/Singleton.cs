using UnityEngine;

namespace Ransom
{
    public class Singleton<T> : MonoBehaviour where T : Component
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
                
                if (_instance is null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance is null) _instance = CreateInstance();
                }

                return _instance;
            }
        }
        #endregion Properties

        #region Unity Callbacks
        protected virtual void Awake()
        {
            if (!(_instance is null))
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
            var @object  = new GameObject(name);
            @object.hideFlags = HideFlags.HideAndDontSave;
            var instance = @object.AddComponent<T>();
            DontDestroyOnLoad(@object);
            return instance;
        }

        private void Deactivate() => _isActive = false;
        #endregion Methods
    }
}
