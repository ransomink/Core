using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_EASING, 
        menuName = Folder.SO  + Folder.BASE_VARIABLE + Folder.NAME_EASING, 
        order    = 4
    )]
    public class SO_Easing : SO_BaseVariable<Easings.Functions> {}
}
