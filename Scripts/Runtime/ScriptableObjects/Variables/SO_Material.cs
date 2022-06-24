using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_MATERIAL, 
        menuName = Folder.SO  + Folder.BASE_VARIABLE + Folder.NAME_MATERIAL, 
        order    = 8
    )]
    public class SO_Material : SO_BaseVariable<Material> {}
}
