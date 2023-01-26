using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace LikeADoom
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform _spawnPoint;

        private EnemyFactory _factory;
        private List<Enemy> _enemies;

        [Inject]
        public void Initialize(Player player)
        {
            _enemies = new List<Enemy>();
            _factory = new EnemyFactory(_enemyPrefab, player.transform);
            
            SpawnEnemy();
        }
        
        private void Update()
        {
            foreach (var enemy in _enemies)
                enemy.Act();
        }

        public void SpawnEnemy()
        {
            Enemy enemy = _factory.CreateAt(_spawnPoint.position, Quaternion.identity);
            _enemies.Add(enemy);
        }
    }
}