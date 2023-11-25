using LikeADoom.Core;
using LikeADoom.Core.SaveSystem;
using LikeADoom.Core.SaveSystem.Interfaces;
using LikeADoom.Units.Enemies.StateMachine;
using LikeADoom.Units.Enemies.Targeting;
using LikeADoom.Units.Player.Health;
using RDTools.AutoAttach;
using System;
using UnityEngine;

namespace LikeADoom.Units.Enemies
{
    public class Enemy : MonoBehaviour, ISavable
    {
        [SerializeField, Attach] Health _health;
        [SerializeField, Attach] EnemyAttack _attack;
        [SerializeField, Attach] EnemyMovement _movement;
        [SerializeField, Attach] DistanceChecker _checker;

        EnemyStateMachine _stateMachine;
        public int Id { get; private set; }
        public SaveSystemGo SaveSystem { get; private set; }

        public event Action<Enemy> Dead;

        void OnEnable()
        {
            _health.Damaged += OnDamaged;
            _health.Dying += OnDying;
        }

        void OnDestroy()
        {
            _health.Damaged -= OnDamaged;
            _health.Dying -= OnDying;
        }

        public void Init(Transform target, SaveSystemGo saveSystem)
        {
            SaveSystem = saveSystem;
            
            Targeting.Targeting targeting = new Targeting.Targeting(target, _checker);
            _stateMachine = new EnemyStateMachine(transform, targeting, _attack, _movement);
            
            targeting.Start();
        }

        void Start()
        {
            if (GameSettings.IsNewGame)
                Id = Guid.NewGuid().GetHashCode();
            else 
                SaveSystem.Load<EnemySaveData>();
        }

        public void Act() => _stateMachine.Act();

        void OnDamaged(int damage)
        {
            _stateMachine.SwitchTo(EnemyStates.EnemyStates.Stunned);
        }

        void OnDying()
        {
            Dead?.Invoke(this);
        }
        public ISavableData Save()
        {
            return new EnemySaveData(Id, transform.position, transform.rotation);
        }
        public void Load(ISavableData saveData)
        {
            EnemySaveData enemySaveData = (EnemySaveData)saveData;
            
            Id = enemySaveData.Id;
            transform.position = enemySaveData.Position;
            transform.rotation = enemySaveData.Rotation;
        }
        public Type Type() => typeof(EnemySaveData);
    }
}