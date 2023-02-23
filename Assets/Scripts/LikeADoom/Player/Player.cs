using LikeADoom.Entities;
using LikeADoom.Shooting;
using RDTools.AutoAttach;
using UnityEngine;

namespace LikeADoom
{
    [RequireComponent(typeof(Health))]
    public class Player : MonoBehaviour
    {
        [SerializeField, Attach] private Health _health;
        [SerializeField] private WeaponControl _weapon;

        private void Awake()
        {
            _health.Dying += OnDying;
        }

        private void OnDestroy()
        {
            _health.Dying -= OnDying;
        }

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

            if (Input.GetKeyDown(KeyCode.V))
            {
                _weapon.MeleeHit();
            }
        }

        private void OnDying()
        {
            Destroy(gameObject);
        }
    }
}