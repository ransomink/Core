using UnityEditor;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_StringVariable))]
    public class SO_StringVariablePropertyDrawer : SO_VariablePropertyDrawer<string, SO_String> {}
}
