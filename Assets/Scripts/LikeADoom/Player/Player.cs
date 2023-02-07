using LikeADoom.Shooting;
using UnityEngine;

namespace LikeADoom
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private WeaponControl _weapon;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _weapon.Shoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _weapon.Reload();
            }
        }
    }
}