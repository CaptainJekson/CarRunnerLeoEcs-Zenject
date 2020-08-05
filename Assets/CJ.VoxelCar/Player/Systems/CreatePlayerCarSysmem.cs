using CJ.VoxelCar.Player.Components;
using CJ.VoxelCar.Player.Configuration;
using Leopotam.Ecs;
using UnityEngine;

namespace CJ.VoxelCar.Player.Systems
{
    public class CreatePlayerCarSysmem : IEcsInitSystem
    {
        private PlayerConfiguration _playerConfiguration;
        private RoadConfiguration _roadConfiguration;
        private EcsWorld _world;

        public CreatePlayerCarSysmem(PlayerConfiguration playerConfiguration, RoadConfiguration roadConfiguration)
        {
            _playerConfiguration = playerConfiguration;
            _roadConfiguration = roadConfiguration;
        }

        public void Init()
        {
            var playerEntity = _world.NewEntity();
            ref var playerComponent =  ref playerEntity.Get<PlayerComponent>();
            
            playerComponent.PlayerObject = CreateViewPlayer();

            playerComponent.SideSpeed = _playerConfiguration.SideSpeed;
            playerComponent.Speed = _playerConfiguration.Speed;
            playerComponent.TargetLineCount = _roadConfiguration.PointsSide.Count / 2;  //Find middle line
        }

        private int GetMidNumber(int number)
        {
            return number / 2;
        }

        private GameObject CreateViewPlayer()
        {
            var newPlayer = Object.Instantiate(_playerConfiguration.PlayerObject, _playerConfiguration.StartPosition, Quaternion.identity);

            return newPlayer;
        }
    }
}

