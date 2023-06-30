using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Vector, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_ValueType + Folder.Name_Vector, 
        order    = 6
    )]
    public class SO_Vector : SO_ValueObject<Vector3> {}
}
