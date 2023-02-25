using LikeADoom.Creatures;
using LikeADoom.Shooting;
using RDTools.AutoAttach;
using UnityEngine;

namespace LikeADoom
{
    [RequireComponent(typeof(PlayerHealth)),
     RequireComponent(typeof(PlayerView))]
    public class Player : MonoBehaviour
    {
        [SerializeField, Attach] private PlayerView _view;
        [SerializeField, Attach] private PlayerHealth _health;
        [SerializeField] private WeaponControl _weapon;

        private void Awake()
        {
            _health.Changed += OnChanged;
            _health.Dying += OnDying;
        }

        private void OnDestroy()
        {
            _health.Changed -= OnChanged;
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

        private void OnChanged(int damage)
        {
            _view.PlayPlayerHurtAnimation();
            ShowCurrentStats();
        }

        private void ShowCurrentStats()
        {
            _view.ShowArmorLeft(_health.Armor, _health.MaxArmor);
            _view.ShowHealthLeft(_health.Health, _health.MaxHealth);
        }

        private void OnDying()
        {
            Destroy(gameObject);
        }
    }
}