using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_VECTOR, 
        menuName = Folder.SO  + Folder.BASE_VARIABLE + Folder.NAME_VECTOR, 
        order    = 10
    )]
    public class SO_Vector : SO_BaseVariable<Vector3> {}
}
