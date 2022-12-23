using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Vector, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Name_Vector, 
        order    = 10
    )]
    public class SO_Vector : SO_BaseVariable<Vector3> {}
}
