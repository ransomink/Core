using UnityEditor;
using UnityEngine;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_VectorVariable))]
    public class SO_VectorVariablePropertyDrawer : SO_VariablePropertyDrawer<Vector3, SO_Vector> {}
}
