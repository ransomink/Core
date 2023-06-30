using UnityEditor;
using UnityEngine;

namespace Ransom.Editor
{
    [CustomEditor(typeof(SO_ValueObject<>))]
    [CanEditMultipleObjects]
    public class SO_ValueObjectEditor : UnityEditor.Editor
    {
        protected const float GroupWidth = 96;
        protected const float LabelWidth = 48;
        protected const int HorizontalSpace = 8;
        private SerializedProperty _isReadOnly;
        private SerializedProperty _useDefault;
        private SerializedProperty _defaultValue;
        private SerializedProperty _value;
        private GUIContent _valueContent = new GUIContent();
        
        protected virtual void OnEnable()
        {
            SetGUIContent();
            SetProperties();
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.BeginHorizontal();
            {
                DrawGUI();
            }
            EditorGUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
        }

        protected virtual void DrawGUI()
        {
            DrawSettings();
            DrawValues();
        }

        private void DrawSettings()
        {
            var labelWidth = EditorGUIUtility.labelWidth;
            var groupWidth = LabelWidth + (HorizontalSpace * 4f);
            EditorGUIUtility.labelWidth = groupWidth;
            
            EditorGUILayout.BeginVertical(GUILayout.MaxWidth(groupWidth + 15));
            {
                EditorGUILayout.LabelField("SETTINGS", EditorStyles.boldLabel, GUILayout.MaxWidth(groupWidth));
                EditorGUILayout.PropertyField(_isReadOnly, new GUIContent("Is ReadOnly"), GUILayout.MaxWidth(groupWidth));
                EditorGUILayout.PropertyField(_useDefault, new GUIContent("Use Default"), GUILayout.MaxWidth(groupWidth));
                if (_isReadOnly.boolValue) { _useDefault.boolValue = true; }
            }
            EditorGUILayout.EndVertical();
            
            EditorGUIUtility.labelWidth = labelWidth;
        }

        private void DrawValues()
        {
            var labelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = LabelWidth + (HorizontalSpace * 1);
            
            EditorGUILayout.Space(HorizontalSpace * 3f, false);
            
            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
            {
                EditorGUILayout.LabelField("VALUES", EditorStyles.boldLabel);
                using (new EditorGUI.DisabledScope(_useDefault.boolValue))
                {
                    EditorGUILayout.PropertyField(_value, new GUIContent("Value"), GUILayout.ExpandWidth(true));
                }
                using (new EditorGUI.DisabledScope(_isReadOnly.boolValue || !_useDefault.boolValue))
                {
                    EditorGUILayout.PropertyField(_defaultValue, new GUIContent("Default"), GUILayout.ExpandWidth(true));
                }
            }
            EditorGUILayout.EndVertical();

            EditorGUIUtility.labelWidth = labelWidth;
        }

        protected virtual void SetGUIContent()
        {
            _valueContent.text = "VALUES";
            _valueContent.tooltip = "Assign default and initial values.";
        }

        protected virtual void SetProperties()
        {
            _isReadOnly = serializedObject.FindProperty("_isReadOnly");
            _useDefault = serializedObject.FindProperty("_useDefaultValue");
            _defaultValue = serializedObject.FindProperty("_defaultValue");
            _value = serializedObject.FindProperty("_value");
        }
    }
}
