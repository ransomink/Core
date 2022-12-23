using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_AnimCurve, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Name_AnimCurve, 
        order    = 0
    )]
    public class SO_AnimationCurve : SO_BaseVariable<AnimationCurve> {}
}
