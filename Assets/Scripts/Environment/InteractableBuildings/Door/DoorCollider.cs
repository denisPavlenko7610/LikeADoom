using UnityEngine;
namespace LikeADoom.Environment.InteractableBuildings.Door
{
    public class DoorCollider : MonoBehaviour
    {
        [SerializeField] Collider _currentRigidCol;

        void SetDoorCol()
        {
            _currentRigidCol.isTrigger = !_currentRigidCol.isTrigger;
            Debug.Log("GSSSS");
        }
    }
}
