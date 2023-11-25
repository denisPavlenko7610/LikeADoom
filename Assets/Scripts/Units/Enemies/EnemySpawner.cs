using LikeADoom.Core.SaveSystem;
using LikeADoom.Units.Player;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace LikeADoom.Units.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] Enemy _enemyPrefab;
        [SerializeField] Transform _spawnPoint;

        EnemyFactory _factory;
        List<Enemy> _enemies;
        SaveSystemGo _saveSystemGo;

        [Inject]
        public void Initialize(Units.Player.Player player, IPlayerTransformProvider provider, SaveSystemGo saveSystem)
        {
            _factory = new EnemyFactory(_enemyPrefab, provider.Transform);
            _enemies = new List<Enemy>();
            
            SpawnEnemy(saveSystem);
        }

        void Update()
        {
            foreach (var enemy in _enemies)
                enemy.Act();
        }

        void SpawnEnemy(SaveSystemGo saveSystem)
        {
            Enemy enemy = _factory.CreateAt(_spawnPoint.position, _spawnPoint.rotation, saveSystem);
            enemy.Dead += OnEnemyDead;
            _enemies.Add(enemy);
        }

        void OnEnemyDead(Enemy enemy)
        {
            _enemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }
    }
}