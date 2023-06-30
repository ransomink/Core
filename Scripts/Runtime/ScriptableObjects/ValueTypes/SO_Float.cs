using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Float, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_ValueType + Folder.Name_Float, 
        order    = 4
    )]
    public class SO_Float : SO_NumericObject<float> 
    {
        protected override bool AreEqual(float a, float b) => Mathf.Approximately(a, b);

        protected override float ClampValue(float value)
        {
            // return Mathf.Clamp(value, MinClampedValue, MaxClampedValue);
            if (value.CompareTo(MinClampedValue) < 0) { return MinClampedValue; }
            if (value.CompareTo(MaxClampedValue) > 0) { return MaxClampedValue; }
            return value;
        }
    }
}
