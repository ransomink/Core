using UnityEngine;

namespace Ransom
{
    public abstract class SO_RuntimeObject : ScriptableObject
    {
        [ContextMenu("Clear")]
        public virtual void Clear() {}

        public virtual void Reset() => Clear();
    }

    public abstract class SO_RuntimeObject<T> : SO_RuntimeObject
    {
        public abstract T Value { get; set; }
        public override void Reset() => base.Reset();
    }
}
