using System;
using LikeADoom.Enums;
using UnityEngine;

namespace LikeADoom.Player
{
    public class DoorTrigger : MonoBehaviour
    {
        public event Action<bool> onDoorEnterTriggeredHandler;
        public event Action<bool> onDoorExitTriggeredHandler;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMovement player))
            {
                SetDoorState(DoorStates.Open);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerMovement player))
            {
                SetDoorState(DoorStates.Close);
            }
        }

        private void SetDoorState(DoorStates doorState)
        {
            var isOpen = doorState == DoorStates.Open;
            if (isOpen)
            {
                onDoorEnterTriggeredHandler?.Invoke(isOpen);
            }
            else
            {
                onDoorExitTriggeredHandler?.Invoke(isOpen);
            }
        }
    }
}
