using LikeADoom.Utils;
using UnityEngine;

namespace LikeADoom
{
    public class DoorAnimationSystem : MonoBehaviour
    {
        [SerializeField] private Animator _leftDoorAnimator;
        [SerializeField] private Animator _rightDoorAnimator;

        public void PlayDoorAnimation(bool isOpen)
        {
            _rightDoorAnimator.SetBool(AnimationConstants.DoorOpenBool, isOpen);
            _leftDoorAnimator.SetBool(AnimationConstants.DoorOpenBool, isOpen);
        }
    }
}