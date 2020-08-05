using CJ.VoxelCar.Camera.Configuration;
using CJ.VoxelCar.Camera.SceneObjects;
using CJ.VoxelCar.Player.Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CJ.VoxelCar.Camera.Systems
{
    class MovementCameraSystem : IEcsInitSystem, IEcsRunSystem
    {
        CameraConfiguration _cameraConfiguration;
        private EcsWorld _world;
        private EcsFilter<CameraComponent> _filterCamera;
        private EcsFilter<PlayerComponent> _filterPlayer;

        public MovementCameraSystem(CameraConfiguration cameraConfiguration)
        {
            _cameraConfiguration = cameraConfiguration;
        }

        public void Init()
        {
            var camera = Object.FindObjectOfType<CameraObject>();
            var cameraEntity = _world.NewEntity();
            ref var cameraComponent = ref cameraEntity.Get<CameraComponent>();
            cameraComponent.CameraObject = camera.gameObject;
        }

        public void Run()
        {
            foreach (var i in _filterCamera)
            {
                ref var camera = ref _filterCamera.Get1(i);
                ref var player = ref _filterPlayer.Get1(i);

                FollowTarget(camera.CameraObject.transform, player.PlayerObject.transform, _cameraConfiguration.CameraZoom);
            }
        }

        public void FollowTarget(Transform camera, Transform target, float cameraZoom)
        {
            camera.position = new Vector3(camera.position.x, camera.position.y, target.position.z - cameraZoom);
        }
    }
}
