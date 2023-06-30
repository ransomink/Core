using UnityEditor;
using UnityEngine;

namespace Ransom.Editor
{
    public class SO_VariablePropertyDrawer<TType, TAsset> : PropertyDrawer where TAsset : SO_RuntimeObject<TType>
    {
        const int HorizontalSpace = 8;
        const int ValueLabelWidth = 16;
        const int UseValueLabelWidth = 16;
        private SerializedProperty _content = default;
        private SerializedProperty _useValue = default;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            int totalLines = 1;

            if (_useValue == null) { _useValue = property.FindPropertyRelative("_useValue"); }

            if (property.isExpanded) { totalLines += 1; }

            return (EditorGUIUtility.singleLineHeight * totalLines)
            + (EditorGUIUtility.standardVerticalSpacing * (totalLines - 1));
        }
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            Rect rectFoldout = new Rect(
                position.xMin, 
                position.yMin, 
                position.size.x, 
                EditorGUIUtility.singleLineHeight);
            property.isExpanded = EditorGUI.Foldout(rectFoldout, property.isExpanded, label);

            if (!property.isExpanded)
            {
                EditorGUI.PropertyField(position, property, label);
			    EditorGUI.EndProperty();
			    return;
            }

            int lines = 1;
            float labelWidth  = EditorGUIUtility.labelWidth;
            float lineHeight  = EditorGUIUtility.singleLineHeight;
            Rect rectUseValue = new Rect(
                position.xMin, 
                position.yMin + (lines++ * lineHeight), 
                (UseValueLabelWidth + (HorizontalSpace * 1.5f)) + labelWidth, 
                lineHeight);
            Rect rectContent  = new Rect(
                rectUseValue.xMax, 
                rectUseValue.yMin, 
                position.width - rectUseValue.width, 
                lineHeight);
            
            if (_useValue.boolValue) { _content = property.FindPropertyRelative("_value"); }
            else { _content = property.FindPropertyRelative("_asset"); }
            
            EditorGUI.PropertyField(rectUseValue, property.FindPropertyRelative("_useValue"));
            EditorGUI.PropertyField(rectContent, _content, GUIContent.none);

            EditorGUI.EndProperty();
        }
    }
}
