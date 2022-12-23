using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Camera, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Name_Camera, 
        order    = 3
    )]
    public class SO_Camera : SO_BaseVariable<Camera> {}
}
