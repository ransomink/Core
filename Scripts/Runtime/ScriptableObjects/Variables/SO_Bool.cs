using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Bool, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Name_Bool, 
        order    = 2
    )]
    public class SO_Bool : SO_BaseVariable<bool> {}
}
