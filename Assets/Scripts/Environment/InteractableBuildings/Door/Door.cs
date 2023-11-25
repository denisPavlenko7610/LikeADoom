using UnityEngine;

namespace LikeADoom.Environment.InteractableBuildings.Door
{
    public class Door : MonoBehaviour
    {
        [SerializeField] DoorAnimationSystem doorAnimationSystem;
        [SerializeField] DoorTrigger doorTrigger;

        void OnValidate()
        {
            if (!doorAnimationSystem)
                doorAnimationSystem = gameObject.GetComponent<DoorAnimationSystem>();

            if (!doorTrigger)
                doorTrigger = gameObject.GetComponent<DoorTrigger>();
        }

        void OnEnable()
        {
            doorTrigger.OnDoorEnterTriggeredHandler += PlayDoorAnimation;
            doorTrigger.OnDoorExitTriggeredHandler += PlayDoorAnimation;
        }

        void OnDisable()
        {
            doorTrigger.OnDoorEnterTriggeredHandler -= PlayDoorAnimation;
            doorTrigger.OnDoorExitTriggeredHandler -= PlayDoorAnimation;
        }

        void PlayDoorAnimation(bool isOpen)
        {
            doorAnimationSystem.PlayDoorAnimation(isOpen);
        }
    }
}