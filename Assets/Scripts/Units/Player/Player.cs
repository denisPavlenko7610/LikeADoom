using LikeADoom.Core;
using LikeADoom.Core.SaveSystem;
using LikeADoom.Core.SaveSystem.Interfaces;
using LikeADoom.Units.Player.Health;
using LikeADoom.Units.Player.PlayerShoot.Weapon;
using System;
using UnityEngine;
using Zenject;

namespace LikeADoom.Units.Player
{
    [RequireComponent(typeof(PlayerHealth)),
     RequireComponent(typeof(PlayerView))]
    public class Player : MonoBehaviour, ISavable
    {
        [SerializeField] PlayerView _view;
        [SerializeField] PlayerHealth _health;
        [SerializeField] WeaponControl _weapon;

        SaveSystemGo _saveSystem;
        int Id { get; set; }

        [Inject]
        public void Init(SaveSystemGo saveSystem)
        {
            _saveSystem = saveSystem;
        }

        void OnEnable()
        {
            _health.HealthChanged += OnHealthChanged;
            _health.Dying += OnDying;
        }

        void OnDisable()
        {
            _health.HealthChanged -= OnHealthChanged;
            _health.Dying -= OnDying;
        }

        void Start()
        {
            if (GameSettings.IsNewGame)
                Id = Guid.NewGuid().GetHashCode();
            else
                _saveSystem.Load<PlayerSaveData>();
            
            UpdateParams();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _weapon.Shoot();
            else if (Input.GetKeyDown(KeyCode.R))
                _weapon.Reload();
            else if (Input.GetKeyDown(KeyCode.V))
                _weapon.MeleeHit();
        }

        void OnHealthChanged(int damage)
        {
            if (damage > 0)
                _view.PlayPlayerHurtAnimation(); //Need to change logic
            
            UpdateParams();
        }

        void OnDying()
        {
            Destroy(gameObject);
        }

        public ISavableData Save()
        {
            return new PlayerSaveData(Id, transform.position, transform.rotation,
                _health.CurrentHealth, _health.CurrentArmor);
        }
        public void Load(ISavableData saveData)
        {
            PlayerSaveData playerSaveData = (PlayerSaveData)saveData;
            Id = playerSaveData.Id;

            transform.position = playerSaveData.Position;
            transform.rotation = playerSaveData.Rotation;
            _health.UpdateParams(playerSaveData.CurrentHealth, playerSaveData.CurrentArmor);
        }
        void UpdateParams()
        {
            _health.Init();

            _view.UpdateHealth(_health.CurrentHealth, _health.MaxHealth);
            _view.UpdateArmor(_health.CurrentArmor, _health.MaxArmor);
        }
        public Type Type() => typeof(PlayerSaveData);
    }
}