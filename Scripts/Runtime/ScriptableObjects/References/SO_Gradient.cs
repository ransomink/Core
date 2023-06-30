using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Gradient, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Type_Reference + Folder.Name_Gradient, 
        order    = 2
    )]
    public class SO_Gradient : SO_ReferenceObject<Gradient> {}
}
