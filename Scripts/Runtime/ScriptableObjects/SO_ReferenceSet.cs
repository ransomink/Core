using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ransom
{
    public class SO_ReferenceSet<T> : SO_RuntimeSet<T> where T : class
    {
        [SerializeField] protected bool _hasAssetReference = false;

        public bool HasAssetReference => _hasAssetReference;

        public override void Clear()
        {
            if (_hasAssetReference) { return; }
            
            base.Clear();
        }
    }
}
