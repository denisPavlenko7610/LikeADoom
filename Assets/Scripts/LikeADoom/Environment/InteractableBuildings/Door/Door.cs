using UnityEngine;

namespace LikeADoom.Player
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private DoorAnimationSystem doorAnimationSystem;
        [SerializeField] private DoorTrigger doorTrigger;

        private void OnValidate()
        {
            if (!doorAnimationSystem)
            {
                doorAnimationSystem = gameObject.GetComponent<DoorAnimationSystem>();
            }

            if (!doorTrigger)
            {
                doorTrigger = gameObject.GetComponent<DoorTrigger>();
            }
        }

        private void OnEnable()
        {
            doorTrigger.onDoorEnterTriggeredHandler += PlayDoorAnimation;
            doorTrigger.onDoorExitTriggeredHandler += PlayDoorAnimation;
        }

        private void OnDisable()
        {
            doorTrigger.onDoorEnterTriggeredHandler -= PlayDoorAnimation;
            doorTrigger.onDoorExitTriggeredHandler -= PlayDoorAnimation;
        }

        private void PlayDoorAnimation(bool isOpen)
        {
            doorAnimationSystem.PlayDoorAnimation(isOpen);
        }
    }
}