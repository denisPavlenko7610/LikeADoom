using LikeADoom.LikeADoom.Environment.NonInteractable.Barrel;
using LikeADoom.LikeADoom.FxSystem;
using Zenject;

namespace LikeADoom
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            FxFactory fxFactory = new FxFactory();
            ObjFactory objFactory = new ObjFactory();

            Container.Bind<FxFactory>().FromInstance(fxFactory);
            Container.Bind<ObjFactory>().FromInstance(objFactory);
        }
    }
}