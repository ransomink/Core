using UnityEditor;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_EasingCurveVariable))]
    public class SO_EasingCurveVariablePropertyDrawer : SO_VariablePropertyDrawer<EasingCurve, SO_EasingCurve> {}
}
