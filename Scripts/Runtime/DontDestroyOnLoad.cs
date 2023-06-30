using UnityEngine;

namespace Ransom
{
    [DisallowMultipleComponent]
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void OnEnable() => DontDestroyOnLoad(this);
    }
}
