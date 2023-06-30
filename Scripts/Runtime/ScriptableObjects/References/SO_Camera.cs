using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Camera, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_Reference + Folder.Name_Camera, 
        order    = 1
    )]
    public class SO_Camera : SO_ReferenceObject<Camera> {}
}
