using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Material, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Name_Material, 
        order    = 8
    )]
    public class SO_Material : SO_BaseVariable<Material> {}
}
