using UnityEditor;
using UnityEngine;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_MaterialVariable))]
    public class SO_MaterialVariablePropertyDrawer : SO_VariablePropertyDrawer<Material, SO_Material> {}
}
