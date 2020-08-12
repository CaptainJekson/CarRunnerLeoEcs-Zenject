using CJ.VoxelCar.Player.Components;
using CJ.VoxelCar.Spawner.Configuration;
using Leopotam.Ecs;
using UnityEngine;

namespace CJ.VoxelCar.Spawner.Systems
{
    class ObjectCreationSpawnerSystem : IEcsRunSystem, IEcsInitSystem
    {
        private SpawnersConfiguration _spawnersConfiguration;

        private EcsFilter<SpawnerComponent> _spawnerFilter;

        public ObjectCreationSpawnerSystem(SpawnersConfiguration spawnersConfiguration)
        {
            _spawnersConfiguration = spawnersConfiguration;
        }

        public void Init()
        {
            foreach (var i in _spawnerFilter)
            {
                ref var spawnerComponent = ref _spawnerFilter.Get1(i);

                spawnerComponent.SpawnPosition.z = Random.Range(_spawnersConfiguration.Spawners[i]._distanceMin,
                    _spawnersConfiguration.Spawners[i]._distanceMax);
            }
        }

        public void Run()
        {
            foreach (var i in _spawnerFilter)
            {
                ref var spawnerComponent = ref _spawnerFilter.Get1(i);

                if (spawnerComponent.CurrentPosition.z > spawnerComponent.SpawnPosition.z)
                {
                    spawnerComponent.SpawnPosition.z += Random.Range(_spawnersConfiguration.Spawners[i]._distanceMin,
                        _spawnersConfiguration.Spawners[i]._distanceMax);

                    var randomObject = Random.Range(0, _spawnersConfiguration.Spawners[i].SpawnObjects.Count);

                    Object.Instantiate(_spawnersConfiguration.Spawners[i].SpawnObjects[randomObject],
                        spawnerComponent.CurrentPosition, Quaternion.identity);
                }
            }
        }
    }
}
