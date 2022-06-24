using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_CAMERA, 
        menuName = Folder.SO  + Folder.BASE_VARIABLE + Folder.NAME_CAMERA, 
        order    = 3
    )]
    public class SO_Camera : SO_BaseVariable<Camera> {}
}
