using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_STRING, 
        menuName = Folder.SO  + Folder.BASE_VARIABLE + Folder.NAME_STRING, 
        order    = 9
    )]
    public class SO_String : SO_BaseVariable<string> {}
}
