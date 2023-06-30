using UnityEditor;
using UnityEngine;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_TransformVariable))]
    public class SO_TransformVariablePropertyDrawer : SO_VariablePropertyDrawer<Transform, SO_Transform> {}
}
