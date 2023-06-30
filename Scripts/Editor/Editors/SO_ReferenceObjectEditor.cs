using UnityEditor;
using UnityEngine;

namespace Ransom.Editor
{
    [CustomEditor(typeof(SO_ReferenceObject<>), true)]
    public class SO_ReferenceObjectEditor : UnityEditor.Editor
    {
        protected const float LabelWidth = 48;
        protected const int HorizontalSpace = 8;
        private SerializedProperty _hasAsset;
        private SerializedProperty _reference;
        private GUIContent _referenceContent = new GUIContent();

        private void OnEnable()
        {
            SetGUIContent();
            SetProperties();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawGUI();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawGUI()
        {
            EditorGUILayout.LabelField("SETTINGS", EditorStyles.boldLabel);
            
            var labelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = LabelWidth + (HorizontalSpace * 2f);
                
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.PropertyField(_hasAsset, _referenceContent, GUILayout.MaxWidth((LabelWidth + 15) + (HorizontalSpace * 2)));
                
                EditorGUILayout.Space(HorizontalSpace * 3f, false);
                
                EditorGUIUtility.labelWidth = LabelWidth + (HorizontalSpace * 3f);
                EditorGUILayout.PropertyField(_reference, GUILayout.ExpandWidth(true));
            }
            EditorGUILayout.EndHorizontal();

            EditorGUIUtility.labelWidth = labelWidth;
        }

        public void SetGUIContent()
        {
            _referenceContent.text = "Has Asset";
            _referenceContent.tooltip = "If we are referencing an asset from the Project. If so, do not reset.";
        }

        public void SetProperties()
        {
            _hasAsset  = serializedObject.FindProperty("_hasAssetReference");
            _reference = serializedObject.FindProperty("_reference");
        }
    }
}
