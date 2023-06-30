using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Easing, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_ValueType + Folder.Name_Easing, 
        order    = 2
    )]
    public class SO_Easing : SO_ValueObject<Easings.Functions> {}
}
