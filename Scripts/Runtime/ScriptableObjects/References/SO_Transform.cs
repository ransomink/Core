using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Transform, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_Reference + Folder.Name_Transform, 
        order    = 5
    )]
    public class SO_Transform : SO_ReferenceObject<Transform> {}
}
