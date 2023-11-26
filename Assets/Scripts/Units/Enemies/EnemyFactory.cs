using LikeADoom.Core.SaveSystem;
using UnityEngine;

namespace LikeADoom.Units.Enemies
{
    public class EnemyFactory 
    {
        readonly Enemy _prefab;
        readonly Transform _player;
        
        public EnemyFactory(Enemy prefab, Transform player)
        {
            _prefab = prefab;
            _player = player;
        }

        public Enemy CreateAt(Vector3 position, Quaternion rotation, SaveSystem saveSystem)
        {
            Enemy enemy = Object.Instantiate(_prefab, position, rotation);
            enemy.Init(_player, saveSystem);
            return enemy;
        }
    }
}