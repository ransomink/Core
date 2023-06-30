using UnityEditor;
using UnityEngine;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_GradientVariable))]
    public class SO_GradientVariablePropertyDrawer : SO_VariablePropertyDrawer<Gradient, SO_Gradient> {}
}
