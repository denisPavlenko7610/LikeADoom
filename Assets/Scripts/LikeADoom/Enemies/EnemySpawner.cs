using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace LikeADoom.LikeADoom.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform _spawnPoint;

        private EnemyFactory _factory;
        private List<Enemy> _enemies;

        [Inject]
        public void Initialize(Player player, IPlayerTransformProvider provider)
        {
            _factory = new EnemyFactory(_enemyPrefab, provider.Transform);
            _enemies = new List<Enemy>();
            
            SpawnEnemy();
        }

        private void Update()
        {
            foreach (var enemy in _enemies)
                enemy.Act();
        }

        private void SpawnEnemy()
        {
            Enemy enemy = _factory.CreateAt(_spawnPoint.position, _spawnPoint.rotation);
            _enemies.Add(enemy);
        }
    }
}