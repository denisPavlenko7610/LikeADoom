using UnityEngine;

namespace LikeADoom
{
    public class EnemyFactory 
    {
        private readonly Enemy _prefab;
        private readonly Transform _player;
        
        public EnemyFactory(Enemy prefab, Transform player)
        {
            _prefab = prefab;
            _player = player;
        }

        public Enemy CreateAt(Vector3 position, Quaternion rotation)
        {
            Enemy enemy = Object.Instantiate(_prefab, position, rotation);
            enemy.Initialize(_player);
            return enemy;
        }
    }
}