using System;
using UnityEngine;
using Leopotam;
using Zenject;
using Leopotam.Ecs;
using CJ.VoxelCar.Camera.Systems;

namespace CJ.VoxelCar.Camera
{
    public class CameraSystemsExecutor : ITickable, IDisposable
    {
        private EcsSystems _systems;

        private CameraSystemsExecutor(EcsWorld world, MovementCameraSystem movementCameraSystem)
        {
            _systems = new EcsSystems(world, "CameraSystems");

            _systems.Add(movementCameraSystem);

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

