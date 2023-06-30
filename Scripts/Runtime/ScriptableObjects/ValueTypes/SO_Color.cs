using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Color, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_ValueType + Folder.Name_Color, 
        order    = 1
    )]
    public class SO_Color : SO_ValueObject<Color> {}
}
