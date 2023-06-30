using UnityEditor;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_FloatVariable))]
    public class SO_FloatVariablePropertyDrawer : SO_VariablePropertyDrawer<float, SO_Float> {}
}
