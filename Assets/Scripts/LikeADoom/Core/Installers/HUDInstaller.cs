
using UnityEngine;
using Zenject;

namespace LikeADoom
{
    public class HUDInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _hudPrefab;
        [SerializeField] private Transform _parentRoot;

        public override void InstallBindings()
        {
            var hud = Container.InstantiatePrefabForComponent<Canvas>(_hudPrefab, _parentRoot);
            Container.Bind<Canvas>().FromInstance(hud);
        }
    }
}
