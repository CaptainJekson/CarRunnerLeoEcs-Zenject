using UnityEngine;
using Leopotam.Ecs;
using CJ.VoxelCar.Player.Components;
using UnityEditor;
using CJ.VoxelCar.Player.Configuration;

namespace CJ.VoxelCar.Player.Systems
{
    public sealed class MovementPlayerSystem : IEcsRunSystem
    {
        RoadConfiguration _roadConfiguration;

        private EcsFilter<PlayerComponent> _filter;

        public MovementPlayerSystem(RoadConfiguration roadConfiguration)
        {
            _roadConfiguration = roadConfiguration;
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var player = ref _filter.Get1(i);

                Move(player);

                MoveSide(player, _roadConfiguration.PointsSide[player.TargetLineCount]);
            }
        }

        private void Move(PlayerComponent player)
        {
            player.PlayerObject.transform.position = Vector3.MoveTowards(player.PlayerObject.transform.position,
                player.PlayerObject.transform.position + Vector3.forward, player.Speed * Time.deltaTime);
        }

        private void MoveSide(PlayerComponent player, float targetX)
        {
            player.PlayerObject.transform.position = Vector3.MoveTowards(player.PlayerObject.transform.position,
                new Vector3(targetX, player.PlayerObject.transform.position.y,player.PlayerObject.transform.position.z),
                player.SideSpeed * Time.deltaTime);
        }
    }
}