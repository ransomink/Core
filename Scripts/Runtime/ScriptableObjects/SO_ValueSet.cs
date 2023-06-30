using UnityEngine;

namespace Ransom
{
    public class SO_ValueSet<T> : SO_RuntimeSet<T> where T : struct
    {
        
        [Header("SETTINGS")]
        [SerializeField] private bool _useDefaultValue = false;

        [Header("FIELDS")]
        [SerializeField] protected T _defaultValue = default(T);

        public override void Clear()
        {
            if (!_useDefaultValue)
            {
                base.Clear();
                return;
            }

            var  count = Count;
            for (var i = count - 1; i >= 0; --i)
            {
                _items[i] = _defaultValue;
            }
            
        }
    }
}
