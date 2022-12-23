using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Color, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Name_Color, 
        order    = 3
    )]
    public class SO_Color : SO_BaseVariable<Color> {}
}
