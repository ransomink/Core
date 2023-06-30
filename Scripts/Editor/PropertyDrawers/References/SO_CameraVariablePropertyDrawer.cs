using UnityEditor;
using UnityEngine;

namespace Ransom.Editor
{
    [CustomPropertyDrawer(typeof(SO_CameraVariable))]
    public class SO_CameraVariablePropertyDrawer : SO_VariablePropertyDrawer<Camera, SO_Camera> {}
}
