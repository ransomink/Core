using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Ransomink
{
    // Original by DYLAN ENGELMAN http://jupiterlighthousestudio.com/custom-inspectors-unity/
    // Altered by Brecht Lecluyse http://www.brechtos.com
    
    [CustomPropertyDrawer(typeof(TagAttribute))]
    public class TagPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.String)
            {
                EditorGUI.BeginProperty(position, label, property);
                var attrib = this.attribute as TagAttribute;

                if (attrib.UseDefaultTagFieldDrawer)
                {
                    property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
                }
                else
                {
                    // generate the taglist + custom tags
                    var index   = -1;
                    var tagList = new List<string>();
                    var propertyString = property.stringValue;

                    tagList.Add("<NoTag>");
                    tagList.AddRange(UnityEditorInternal.InternalEditorUtility.tags);

                    if (propertyString == "")
                    {
                        // The tag is empty
                        // first index is the special <NoTag> entry
                        index = 0;
                    }
                    else
                    {
                        // check if there is an entry that matches the entry and get the index
                        // we skip index 0 as that is a special custom case
                        for (var i = 1; i < tagList.Count; i++)
                        {
                            if (tagList[i] != propertyString) continue;
                            index = i;
                            break;
                        }
                    }
                    
                    //Draw the popup box with the current selected index
                    index = EditorGUI.Popup(position, label.text, index, tagList.ToArray());

                    //Adjust the actual string value of the property based on the selection
                    property.stringValue = index >= 1 ? tagList[index] : "";
                }
                
                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}
