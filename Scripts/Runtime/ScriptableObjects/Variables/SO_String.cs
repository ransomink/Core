using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_String, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Name_String, 
        order    = 9
    )]
    public class SO_String : SO_BaseVariable<string> {}
}
