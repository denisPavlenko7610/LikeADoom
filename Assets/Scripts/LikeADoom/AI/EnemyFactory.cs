using UnityEngine;

namespace LikeADoom
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Transform _spawnPoint;

        private Transform _player;
        
        public void Initialize(Transform player)
        {
            _player = player;
        }

        public Enemy Create() => 
            CreateAt(_spawnPoint.position, Quaternion.identity);

        public Enemy CreateAt(Vector3 position, Quaternion rotation)
        {
            Enemy enemy = Instantiate(_prefab, position, rotation);
            enemy.Initialize(_player);
            return enemy;
        }
    }
}