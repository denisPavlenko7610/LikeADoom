using UnityEngine;

namespace LikeADoom
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _spawnPoint;

        public Enemy Create()
        {
            Enemy enemy = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            enemy.Initialize(_player);
            return enemy;
        }
    }
}