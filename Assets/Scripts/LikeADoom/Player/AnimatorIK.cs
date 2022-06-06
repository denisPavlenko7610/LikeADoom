using UnityEngine;

namespace LikeADoom.Player
{
    public class AnimatorIK : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] Transform _targetObjectRight;
        [SerializeField] Transform _targetObjectLeft;

        void OnAnimatorIK(int layerIndex)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKPosition(AvatarIKGoal.RightHand, _targetObjectRight.position);
            //animator.SetIKRotation(AvatarIKGoal.RightHand, _targetObjectLeft.rotation);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, _targetObjectLeft.position);
            //animator.SetIKRotation(AvatarIKGoal.LeftHand, _targetObjectRight.rotation);
        }
    }
}
