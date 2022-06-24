using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_FLOAT, 
        menuName = Folder.SO  + Folder.BASE_VARIABLE + Folder.NAME_FLOAT, 
        order    = 5
    )]
    public class SO_Float : SO_BaseVariable<float> 
    {
        public override bool Clampable => true;

        protected override bool AreEqual(float a, float b)
        {
            return Mathf.Abs(a - b) < Mathf.Epsilon;
        }

        protected override float ClampValue(float value)
        {
            // return Mathf.Clamp(value, MinClampedValue, MaxClampedValue);
            if (value.CompareTo(MinClampedValue) < 0) return MinClampedValue;
            if (value.CompareTo(MaxClampedValue) > 0) return MaxClampedValue;
            return value;
        }
    }
}
