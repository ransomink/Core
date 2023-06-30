using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Easing + Folder.Name_Curve, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_ValueType + Folder.Name_Easing + Folder.Name_Curve, 
        order    = 3
    )]
    public class SO_EasingCurve : SO_ValueObject<EasingCurve> {}
}
