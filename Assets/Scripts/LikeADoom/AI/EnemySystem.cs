using System.Collections.Generic;
using UnityEngine;

namespace LikeADoom
{
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _factory;

        private List<Enemy> _enemies;

        private void Awake()
        {
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
            Enemy enemy = _factory.Create();
            _enemies.Add(enemy);
        }
    }
}