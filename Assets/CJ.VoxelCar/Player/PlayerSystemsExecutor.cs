using CJ.VoxelCar.Player.Systems;
using Leopotam.Ecs;
using System;
using Zenject;

namespace CJ.VoxelCar.Player
{
    public class PlayerSystemsExecutor : ITickable, IDisposable
    {
        private readonly EcsSystems _systems;

        public PlayerSystemsExecutor(EcsWorld world, CreatePlayerCarSysmem createPlayerCarSysmem, MovementPlayerSystem movementPlayerSystem,
            PCControlPlayerSystem controlPlayerSystem)
        {
            _systems = new EcsSystems(world, "PlayerSystems");

            _systems
                .Add(createPlayerCarSysmem)
                .Add(movementPlayerSystem)
                .Add(controlPlayerSystem);

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

