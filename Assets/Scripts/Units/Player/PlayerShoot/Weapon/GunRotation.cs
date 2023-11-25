using UnityEngine;

namespace LikeADoom.Units.Player.PlayerShoot.Weapon
{
    public class GunRotation : MonoBehaviour
    {
        [SerializeField] Transform _targetRotation;

        void Update()
        {
            transform.rotation = _targetRotation.rotation;
        }
    }
}
