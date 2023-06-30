using UnityEditor;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_BoolVariable))]
    public class SO_BoolVariablePropertyDrawer : SO_VariablePropertyDrawer<bool, SO_Bool> {}
}
