using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_GRADIENT, 
        menuName = Folder.SO  + Folder.BASE_VARIABLE + Folder.NAME_GRADIENT, 
        order    = 6
    )]
    public class SO_Gradient : SO_BaseVariable<Gradient> {}
}
