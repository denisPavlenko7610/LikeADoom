using LikeADoom.Environment.NonInteractable.Barrel;
using LikeADoom.FxSystem;
using UnityEngine;
using Zenject;

namespace LikeADoom.Core.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] SaveSystem.SaveSystem saveSystem;
        public override void InstallBindings()
        {
            IsNewGame();

            FxFactory fxFactory = new FxFactory();
            ObjFactory objFactory = new ObjFactory();

            Container.Bind<FxFactory>().FromInstance(fxFactory);
            Container.Bind<ObjFactory>().FromInstance(objFactory);
            Container.Bind<SaveSystem.SaveSystem>().FromInstance(saveSystem).AsSingle().NonLazy();
        }
        static void IsNewGame()
        {
            GameSettings.IsNewGame = !PlayerPrefs.HasKey(nameof(GameSettings.IsNewGame));
        }
    }
}