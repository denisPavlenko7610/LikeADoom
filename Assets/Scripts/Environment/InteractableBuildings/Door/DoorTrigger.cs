using LikeADoom.Enums;
using LikeADoom.Units.Player;
using System;
using UnityEngine;

namespace LikeADoom.Environment.InteractableBuildings.Door
{
    public class DoorTrigger : MonoBehaviour
    {
        public event Action<bool> OnDoorEnterTriggeredHandler;
        public event Action<bool> OnDoorExitTriggeredHandler;
        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                SetDoorState(DoorStates.Open);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
                SetDoorState(DoorStates.Close);
        }

        void SetDoorState(DoorStates doorState)
        {
            var isOpen = doorState == DoorStates.Open;
            if (isOpen)
                OnDoorEnterTriggeredHandler?.Invoke(true);
            else
                OnDoorExitTriggeredHandler?.Invoke(false);
        }
    }
}
