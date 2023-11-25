using LikeADoom.HUD;
using UnityEngine;
using Zenject;

namespace LikeADoom.Core.Installers
{
    public class HUDInstaller : MonoInstaller
    {
        [SerializeField] Canvas _hudPrefab;
        [SerializeField] Transform _parentRoot;

        public override void InstallBindings()
        {
            var hud = Container.InstantiatePrefabForComponent<Canvas>(_hudPrefab, _parentRoot);
            Container.Bind<Canvas>().FromInstance(hud);

            var ammoBar = hud.GetComponentInChildren<AmmoBar>();
            var armorBar = hud.GetComponentInChildren<ArmorBar>();
            var healthBar = hud.GetComponentInChildren<HealthBar>();
            
            Container.Bind<AmmoBar>().FromInstance(ammoBar).AsSingle();
            Container.Bind<ArmorBar>().FromInstance(armorBar).AsSingle();
            Container.Bind<HealthBar>().FromInstance(healthBar).AsSingle();
        }
    }
}
