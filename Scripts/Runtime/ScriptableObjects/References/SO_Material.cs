using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Material, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_Reference + Folder.Name_Material, 
        order    = 3
    )]
    public class SO_Material : SO_ReferenceObject<Material> {}
}
