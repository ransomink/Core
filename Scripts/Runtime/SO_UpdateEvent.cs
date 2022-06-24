using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NEW + Folder.NAME_UPDATE + Folder.NAME_EVENT, 
        menuName = Folder.SO  + Folder.BASE_UPDATE + Folder.NAME_DISPATCHER, 
        order    = 0
    )]
    public class SO_UpdateEvent : SO_RuntimeSet<Manager> {}
}
