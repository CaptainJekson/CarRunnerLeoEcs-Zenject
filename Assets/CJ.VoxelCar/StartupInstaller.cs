using CJ.VoxelCar.Camera;
using CJ.VoxelCar.Player;
using CJ.VoxelCar.Spawner;
using Leopotam.Ecs;
using Zenject;

namespace CJ.VoxelCar
{
    public class StartupInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var world = new EcsWorld();
            Container.BindInterfacesAndSelfTo<DefaultSystemsExecutor>().AsSingle().NonLazy();

            Container.BindInstance(world);

            PlayerModule.Install(Container);
            CameraModule.Install(Container);
            SpawnerModule.Install(Container);
        }
    }
}

