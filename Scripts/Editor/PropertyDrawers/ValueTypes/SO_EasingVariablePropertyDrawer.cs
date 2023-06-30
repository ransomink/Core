using UnityEditor;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_EasingVariable))]
    public class SO_EasingVariablePropertyDrawer : SO_VariablePropertyDrawer<Easings.Functions, SO_Easing> {}
}
