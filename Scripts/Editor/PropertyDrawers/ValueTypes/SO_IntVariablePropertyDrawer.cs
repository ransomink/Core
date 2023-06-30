using UnityEditor;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_IntVariable))]
    public class SO_IntVariablePropertyDrawer : SO_VariablePropertyDrawer<int, SO_Int> {}
}
