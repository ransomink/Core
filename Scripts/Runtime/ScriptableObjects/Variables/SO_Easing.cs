using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.New + Folder.Name_Easing, 
        menuName = Folder.SO  + Folder.Base_Variable + Folder.Name_Easing, 
        order    = 4
    )]
    public class SO_Easing : SO_BaseVariable<Easings.Functions> {}
}
