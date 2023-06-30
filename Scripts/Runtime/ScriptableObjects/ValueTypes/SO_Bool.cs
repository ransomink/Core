using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Bool, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_ValueType + Folder.Name_Bool, 
        order    = 0
    )]
    public class SO_Bool : SO_ValueObject<bool> {}
}
