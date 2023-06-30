using UnityEditor;
using UnityEngine;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_ColorVariable))]
    public class SO_ColorVariablePropertyDrawer : SO_VariablePropertyDrawer<Color, SO_Color> {}
}
