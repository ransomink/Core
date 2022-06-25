using UnityEngine;

namespace Ransom
{
    public abstract class SO_Singleton<T> : ScriptableObject where T : ScriptableObject
    {
        #region Fields
        private static T _instance = null;
        #endregion Fields

        #region Properties
        public  static T  Instance
        {
            get
            {
                if (_instance is null)
                {
                    var assets = Resources.FindObjectsOfTypeAll<T>();
                    if (assets == null || assets.Length == 0)
                    {
                        Debug.LogWarning($"Singleton <color=orange>{typeof(T)}</color> does not exist. Please create one.");
                    }
                    else if (assets.Length > 1)
                    {
                        Debug.LogWarning($"Singleton <color=orange>{typeof(T)}</color> has multiple instances. Remove immediately.");
                    }
                    else
                    {
                        _instance = assets[0];
                        _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
                    }
                }
                
                return _instance;
            }
        }
        #endregion Properties
    }
}
