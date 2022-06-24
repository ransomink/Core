using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_ANIM_CURVE, 
        menuName = Folder.SO  + Folder.BASE_VARIABLE + Folder.NAME_ANIM_CURVE, 
        order    = 0
    )]
    public class SO_AnimationCurve : SO_BaseVariable<AnimationCurve> {}
}
