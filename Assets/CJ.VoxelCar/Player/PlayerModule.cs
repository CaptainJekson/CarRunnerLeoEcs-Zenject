using CJ.VoxelCar.Player.Configuration;
using CJ.VoxelCar.Player.Systems;
using Zenject;

namespace CJ.VoxelCar.Player
{
    public class PlayerModule : Installer<PlayerModule>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerConfiguration>().FromScriptableObjectResource("PlayerConfiguration").AsSingle();
            Container.Bind<RoadConfiguration>().FromScriptableObjectResource("RoadConfiguration").AsSingle();

            Container.Bind<CreatePlayerCarSystem>().AsSingle();
            Container.Bind<MovementPlayerSystem>().AsSingle();
            Container.Bind<PCControlPlayerSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<PlayerSystemsExecutor>().AsSingle().NonLazy();
        }
    }
}

