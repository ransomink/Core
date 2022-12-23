using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Gradient, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Name_Gradient, 
        order    = 6
    )]
    public class SO_Gradient : SO_BaseVariable<Gradient> {}
}
