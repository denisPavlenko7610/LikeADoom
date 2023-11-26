using LikeADoom.Units.Player;
using UnityEngine;
using Zenject;

namespace LikeADoom.Core.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] Player _playerPrefab;
        [SerializeField] Transform _spawnPosition;
        [SerializeField] Transform _parentRoot;
        
        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<Player>(_playerPrefab.gameObject,
                _spawnPosition.position, Quaternion.identity, _parentRoot);
            
            Container.Bind<Player>().FromInstance(playerInstance).AsSingle().NonLazy();
            Container.BindInterfacesTo<ElevatedPlayerPosition>().FromNew().AsSingle();
        }
    }
}