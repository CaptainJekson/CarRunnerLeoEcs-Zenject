using CJ.VoxelCar.Player.Components;
using CJ.VoxelCar.Player.Configuration;
using Leopotam.Ecs;
using UnityEngine;

namespace CJ.VoxelCar.Player.Systems
{
    public class PCControlPlayerSystem : IEcsRunSystem
    {
        RoadConfiguration _roadConfiguration;
        PlayerConfiguration _playerConfiguration;

        private EcsFilter<PlayerComponent> _filter;

        public PCControlPlayerSystem(RoadConfiguration roadConfiguration, PlayerConfiguration playerConfiguration)
        {
            _roadConfiguration = roadConfiguration;
            _playerConfiguration = playerConfiguration;
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var player = ref _filter.Get1(i);

                if (Input.GetKeyDown(_playerConfiguration.MovementRigth) && player.TargetLineCount < _roadConfiguration.PointsSide.Count - 1)
                    ++player.TargetLineCount;
                if (Input.GetKeyDown(_playerConfiguration.MovementLeft) && player.TargetLineCount > 0)
                    --player.TargetLineCount;
            }
        }
    }
}


