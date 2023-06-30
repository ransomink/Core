using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Int, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_ValueType + Folder.Name_Int, 
        order    = 5
    )]
    public class SO_Int : SO_NumericObject<int>
    {
        protected override bool AreEqual(int a, int b) => (a == b);

        protected override int ClampValue(int value)
        {
            if (value.CompareTo(MinClampedValue) < 0) return MinClampedValue;
            if (value.CompareTo(MaxClampedValue) > 0) return MaxClampedValue;
            return value;
        }
    }
}
