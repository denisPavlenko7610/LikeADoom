using System;
using External.Mini_First_Person_Controller.Scripts;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator _leftDoorAnimator;
    [SerializeField] private Animator _rightDoorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonMovement player))
        {
            SetDoor(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonMovement player))
        {
            SetDoor(false);
        }
    }

    private void SetDoor(bool enebled)
    {
        if (enebled)
        {
            _rightDoorAnimator.SetBool("DoorOpenBool", true);
            _leftDoorAnimator.SetBool("DoorOpenBool", true);
        }
        else
        {
            _rightDoorAnimator.SetBool("DoorOpenBool", false);
            _leftDoorAnimator.SetBool("DoorOpenBool", false);
        }
    }
}
