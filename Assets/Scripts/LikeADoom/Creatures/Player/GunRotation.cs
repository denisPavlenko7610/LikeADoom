using UnityEngine;

namespace LikeADoom
{
    public class GunRotation : MonoBehaviour
    {
        [SerializeField] private Transform _targetRotation;

        void Update()
        {
            transform.rotation = _targetRotation.rotation;
        }
    }
}
