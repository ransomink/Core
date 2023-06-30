using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_String, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_Reference + Folder.Name_String, 
        order    = 4
    )]
    public class SO_String : SO_ReferenceObject<string> {}
}
