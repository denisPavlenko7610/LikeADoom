using LikeADoom.Core.SaveSystem;
using LikeADoom.Environment.NonInteractable.Barrel;
using LikeADoom.FxSystem;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace LikeADoom.Core.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [FormerlySerializedAs("saveSystemGo")] [SerializeField] SaveSystem.SaveSystem saveSystem;
        public override void InstallBindings()
        {
            IsNewGame();

            FxFactory fxFactory = new FxFactory();
            ObjFactory objFactory = new ObjFactory();

            Container.Bind<FxFactory>().FromInstance(fxFactory);
            Container.Bind<ObjFactory>().FromInstance(objFactory);
            Container.Bind<SaveSystem.SaveSystem>().FromInstance(saveSystem);
        }
        static void IsNewGame()
        {
            GameSettings.IsNewGame = !PlayerPrefs.HasKey(nameof(GameSettings.IsNewGame));
        }
    }
}