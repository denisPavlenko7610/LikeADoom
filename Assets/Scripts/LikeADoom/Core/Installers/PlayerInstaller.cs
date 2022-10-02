using UnityEngine;
using Zenject;

namespace LikeADoom
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player.Player _playerPrefab;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private Transform _parentRoot;


        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<Player.Player>(_playerPrefab.gameObject,
                _spawnPosition.position, Quaternion.identity, _parentRoot);
            Container.Bind<Player.Player>().FromInstance(playerInstance).AsSingle().NonLazy();
        }
    }
}