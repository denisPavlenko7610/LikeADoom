using LikeADoom.Constants;
using UnityEngine;

namespace LikeADoom.Environment.InteractableBuildings.Door
{
    public class DoorAnimationSystem : MonoBehaviour
    {
        [SerializeField] Animator _leftDoorAnimator;
        [SerializeField] Animator _rightDoorAnimator;

        public void PlayDoorAnimation(bool isOpen)
        {
            _rightDoorAnimator.SetBool(AnimationConstants.DoorOpenBool, isOpen);
            _leftDoorAnimator.SetBool(AnimationConstants.DoorOpenBool, isOpen);
        }
    }
}