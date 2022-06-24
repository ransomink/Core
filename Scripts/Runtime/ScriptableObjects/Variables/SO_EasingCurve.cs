using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_EASING + Folder.NAME_CURVE, 
        menuName = Folder.SO  + Folder.BASE_VARIABLE + Folder.NAME_EASING + Folder.NAME_CURVE, 
        order    = 4
    )]
    public class SO_EasingCurve : SO_BaseVariable<EasingCurve> {}
}
