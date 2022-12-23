using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Int, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Name_Int, 
        order    = 7
    )]
    public class SO_Int : SO_BaseVariable<int>
    {
        public override bool Clampable => true;

        protected override bool AreEqual(int a, int b)
        {
            return a == b;
        }

        protected override int ClampValue(int value)
        {
            if (value.CompareTo(MinClampedValue) < 0) return MinClampedValue;
            if (value.CompareTo(MaxClampedValue) > 0) return MaxClampedValue;
            return value;
        }
    }
}
