using UnityEditor;
using UnityEngine;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_AnimationCurveVariable))]
    public class SO_AnimationCurveVariablePropertyDrawer : SO_VariablePropertyDrawer<AnimationCurve, SO_AnimationCurve> {}
}
