using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace LikeADoom
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _factory;

        private List<Enemy> _enemies;

        [Inject]
        public void Initialize(Player player)
        {
            _enemies = new List<Enemy>();
            _factory.Initialize(player.transform);
            
            SpawnEnemy();
        }
        
        private void Update()
        {
            foreach (var enemy in _enemies)
                enemy.Act();
        }

        public void SpawnEnemy()
        {
            Enemy enemy = _factory.Create();
            _enemies.Add(enemy);
        }
    }
}