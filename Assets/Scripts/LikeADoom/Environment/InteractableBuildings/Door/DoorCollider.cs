using UnityEngine;

public class DoorCollider : MonoBehaviour
{
   [SerializeField] private Collider _currentRigidCol;

    private void SetDoorCol()
    {
        _currentRigidCol.isTrigger = !_currentRigidCol.isTrigger;
        Debug.Log("GSSSS");
    }
}
