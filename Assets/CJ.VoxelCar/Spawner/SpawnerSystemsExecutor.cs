using CJ.VoxelCar.Spawner.Systems;
using Leopotam.Ecs;
using System;
using Zenject;

namespace CJ.VoxelCar.Spawner
{
    public class SpawnerSystemsExecutor : ITickable, IDisposable
    {
        private EcsSystems _systems;

        private SpawnerSystemsExecutor(EcsWorld world, PositionSpawnerRelativelyPlayerSystem generateObjectSystem,
            ObjectCreationSpawnerSystem objectCreationSpawnerSystem)
        {
            _systems = new EcsSystems(world, "SpawnerSystems");

            _systems
                .Add(generateObjectSystem)
                .Add(objectCreationSpawnerSystem);

            _systems.Init();

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
        }

        public void Tick()
        {
            _systems.Run();
        }

        public void Dispose()
        {
            _systems.Destroy();
        }
    }
}