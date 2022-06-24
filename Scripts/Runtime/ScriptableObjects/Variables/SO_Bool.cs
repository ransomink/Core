using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_BOOL, 
        menuName = Folder.SO  + Folder.BASE_VARIABLE + Folder.NAME_BOOL, 
        order    = 2
    )]
    public class SO_Bool : SO_BaseVariable<bool> {}
}
