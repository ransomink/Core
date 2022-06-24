using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_COLOR, 
        menuName = Folder.SO  + Folder.BASE_VARIABLE + Folder.NAME_COLOR, 
        order    = 3
    )]
    public class SO_Color : SO_BaseVariable<Color> {}
}
