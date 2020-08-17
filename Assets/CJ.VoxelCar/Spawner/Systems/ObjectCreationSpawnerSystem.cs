using CJ.VoxelCar.Spawner.Components;
using CJ.VoxelCar.Spawner.Configuration;
using Leopotam.Ecs;
using UnityEngine;

namespace CJ.VoxelCar.Spawner.Systems
{
    class ObjectCreationSpawnerSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly SpawnersConfiguration _spawnersConfiguration;

        private EcsWorld _world;
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

                spawnerComponent.SpawnPosition.z = Random.Range(_spawnersConfiguration.Spawners[i].DistanceMin,
                    _spawnersConfiguration.Spawners[i].DistanceMax);
            }
        }

        public void Run()
        {
            foreach (var i in _spawnerFilter)
            {
                ref var spawnerComponent = ref _spawnerFilter.Get1(i);

                if (spawnerComponent.CurrentPosition.z > spawnerComponent.SpawnPosition.z)
                {
                    spawnerComponent.SpawnPosition.z += Random.Range(_spawnersConfiguration.Spawners[i].DistanceMin,
                        _spawnersConfiguration.Spawners[i].DistanceMax);

                    var randomObject = Random.Range(0, _spawnersConfiguration.Spawners[i].SpawnObjects.Count);

                    var objectEntity = _world.NewEntity();

                    ref var spawnedObjectsComponent = ref objectEntity.Get<SpawnedObjectsComponent>();
                    ref var destructionComponent = ref objectEntity.Get<DestructionComponent>();

                    var newObject = Object.Instantiate(_spawnersConfiguration.Spawners[i].SpawnObjects[randomObject],
                        spawnerComponent.CurrentPosition, Quaternion.identity);

                    spawnedObjectsComponent.SpawnedObject = newObject;
                    spawnedObjectsComponent.Entity = objectEntity;
                    destructionComponent.DestructionDistance = _spawnersConfiguration.Spawners[i].DistanceDestruction;
                }
            }
        }
    }
}