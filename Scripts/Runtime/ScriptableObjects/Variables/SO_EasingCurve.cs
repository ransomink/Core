using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Easing + Folder.Name_Curve, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Name_Easing + Folder.Name_Curve, 
        order    = 4
    )]
    public class SO_EasingCurve : SO_BaseVariable<EasingCurve> {}
}
