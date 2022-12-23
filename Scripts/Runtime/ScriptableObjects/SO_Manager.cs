using UnityEngine;

namespace Ransom
{
    public class SO_Manager : ScriptableObject, IManager
    {
        public virtual void OnAwake() {}
        public virtual void OnEnable() {}
        public virtual void OnStart() {}
        public virtual void OnFixedUpdate() {}
        public virtual void OnUpdate() {}
        public virtual void OnLateUpdate() {}
        public virtual void OnDisable() {}
        public virtual void OnDestroy() {}
    }
}
