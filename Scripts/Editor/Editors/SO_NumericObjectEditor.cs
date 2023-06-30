using UnityEditor;
using UnityEngine;

namespace Ransom.Editor
{
    [CustomEditor(typeof(SO_NumericObject<>), true)]
    [CanEditMultipleObjects]
    public class SO_NumericObjectEditor : SO_ValueObjectEditor
    {
        private bool _hasUseMinClampChanged = false;
        private bool _hasUseMaxClampChanged = false;
        private bool _prevUseMinClamp = false;
        private bool _prevUseMaxClamp = false;
        private SerializedProperty _useClamp;
        private SerializedProperty _useMinClamp;
        private SerializedProperty _useMaxClamp;
        private SerializedProperty _minClampedValue;
        private SerializedProperty _maxClampedValue;
        private GUIContent _clampContent = new GUIContent();
        private GUIContent _minClampContent = new GUIContent();
        private GUIContent _maxClampContent = new GUIContent();

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        private void DrawClamp()
        {
            var labelWidth = EditorGUIUtility.labelWidth;
            var groupWidth = LabelWidth + ((HorizontalSpace * 2f));
            EditorGUIUtility.labelWidth = groupWidth;
            
            EditorGUILayout.Space(HorizontalSpace * 3f, false);

            EditorGUILayout.BeginVertical(GUILayout.MinWidth(GroupWidth + (HorizontalSpace * 20)),
                GUILayout.ExpandWidth(true));
            {
                _useClamp.boolValue = EditorGUILayout.BeginToggleGroup(_clampContent, _useClamp.boolValue);
                {
                    if (_useClamp.boolValue)
                    {
                        if (_hasUseMinClampChanged)
                        {
                            _hasUseMinClampChanged = false;
                            _useMinClamp.boolValue = _prevUseMinClamp;
                        }

                        if (_hasUseMaxClampChanged)
                        {
                            _hasUseMaxClampChanged = false;
                            _useMaxClamp.boolValue = _prevUseMaxClamp;
                        }
                    }

                    float maxWidth = (groupWidth + 15) + (HorizontalSpace * 1.5f);
                    EditorGUILayout.BeginHorizontal();
                    {
                        _useMinClamp.boolValue = EditorGUILayout.Toggle("Use Min",
                            _useMinClamp.boolValue,
                            GUILayout.MaxWidth(maxWidth));
                        using (new EditorGUI.DisabledScope(!_useMinClamp.boolValue))
                        {
                            EditorGUILayout.PropertyField(_minClampedValue, 
                                _minClampContent,
                                GUILayout.ExpandWidth(true));
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    {
                        _useMaxClamp.boolValue = EditorGUILayout.Toggle("Use Max", 
                            _useMaxClamp.boolValue, 
                            GUILayout.MaxWidth(maxWidth));
                        using (new EditorGUI.DisabledScope(!_useMaxClamp.boolValue))
                        {
                            EditorGUILayout.PropertyField(_maxClampedValue, 
                                _maxClampContent,
                                GUILayout.ExpandWidth(true));
                        }                      
                    }
                    EditorGUILayout.EndHorizontal();
                    
                    if (!_useClamp.boolValue)
                    {
                        if (!_hasUseMinClampChanged)
                        {
                            _hasUseMinClampChanged = true;
                            _prevUseMinClamp = _useMinClamp.boolValue;
                        }

                        if (!_hasUseMaxClampChanged)
                        {
                            _hasUseMaxClampChanged = true;
                            _prevUseMaxClamp = _useMaxClamp.boolValue;
                        }  
                        
                        _useMinClamp.boolValue = false;
                        _useMaxClamp.boolValue = false;
                    }
                }

                EditorGUIUtility.labelWidth = labelWidth;
                EditorGUILayout.EndToggleGroup();
            }
            EditorGUILayout.EndVertical();
        }
        
        protected override void DrawGUI()
        {
            base.DrawGUI();
            DrawClamp();
        }

        protected override void SetGUIContent()
        {
            base.SetGUIContent();
            _clampContent.text = "CLAMP";
            _clampContent.tooltip = "Restrict the value between a minimum and maximum limit.";
            _minClampContent.tooltip = "Minimum clamped value.";
            _maxClampContent.tooltip = "Maximum clamped value.";
        }

        protected override void SetProperties()
        {
            base.SetProperties();
            _useClamp = serializedObject.FindProperty("_useClamp");
            _useMinClamp = serializedObject.FindProperty("_useMinClamp");
            _useMaxClamp = serializedObject.FindProperty("_useMaxClamp");
            _minClampedValue = serializedObject.FindProperty("_minClampedValue");
            _maxClampedValue = serializedObject.FindProperty("_maxClampedValue");
        }
    }
}
