using CJ.VoxelCar.Spawner.Components;
using CJ.VoxelCar.Player.Components;
using CJ.VoxelCar.Spawner.Configuration;
using Leopotam.Ecs;
using UnityEngine;

namespace CJ.VoxelCar.Spawner.Systems
{
    sealed class PositionSpawnerRelativelyPlayerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private SpawnersConfiguration _spawnersConfiguration;

        private EcsWorld _world;
        private EcsFilter<PlayerComponent> _playerFilter;
        private EcsFilter<SpawnerComponent> _spawnerFilter;

        public PositionSpawnerRelativelyPlayerSystem(SpawnersConfiguration spawnersConfiguration)
        {
            _spawnersConfiguration = spawnersConfiguration;
        }
        
        public void Init()
        {
            for (int i = 0; i < _spawnersConfiguration.Spawners.Count; i++)
            {
                var spawnerEntity = _world.NewEntity();
                spawnerEntity.Get<SpawnerComponent>();
            }
        }

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                ref var player = ref _playerFilter.Get1(i);

                foreach (var j in _spawnerFilter)
                {
                    ref var spawner = ref _spawnerFilter.Get1(j);
                    spawner.CurrentPosition = GetSpawnerPosition(player, _spawnersConfiguration, j);
                }
            }
        }

        private Vector3 GetSpawnerPosition(PlayerComponent player, SpawnersConfiguration spawnersConfiguration, int indexSpawner)
        {
            return new Vector3(spawnersConfiguration.Spawners[indexSpawner].Position.x,
                spawnersConfiguration.Spawners[indexSpawner].Position.y,
                player.PlayerObject.transform.position.z + spawnersConfiguration.Spawners[indexSpawner].Position.z);
        }
    }
}