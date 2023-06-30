using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(WarningAttribute))]
public class WarningDrawer: PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var _colour = GUI.color;
        var warning = attribute as WarningAttribute;

        if (!property.objectReferenceValue)
        {
            GUI.color = warning.color;
            EditorGUI.PropertyField(position, property, label);
            GUI.color = _colour;
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}