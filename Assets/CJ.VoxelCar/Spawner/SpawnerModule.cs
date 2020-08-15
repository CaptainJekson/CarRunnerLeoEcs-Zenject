using CJ.VoxelCar.Spawner.Configuration;
using CJ.VoxelCar.Spawner.Systems;
using Leopotam.Ecs;
using Zenject;

namespace CJ.VoxelCar.Spawner
{
    sealed class SpawnerModule : Installer<SpawnerModule>
    {
        public override void InstallBindings()
        {
            Container.Bind<SpawnersConfiguration>().FromScriptableObjectResource("SpawnersConfiguration").AsSingle();

            Container.Bind<PositionSpawnerRelativelyPlayerSystem>().AsSingle();
            Container.Bind<ObjectCreationSpawnerSystem>().AsSingle();
            Container.Bind<ObjectDestructorSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<SpawnerSystemsExecutor>().AsSingle().NonLazy();
        }
    }
}