using CJ.VoxelCar.Player.Components;
using CJ.VoxelCar.Player.Configuration;
using CJ.VoxelCar.Spawner.Configuration;
using Leopotam.Ecs;
using UnityEngine;

namespace CJ.VoxelCar.Spawner.Systems
{
    class ObjectCreationSpawnerSystem : IEcsRunSystem
    {
        SpawnersConfiguration _spawnersConfiguration;

        private EcsFilter<SpawnerComponent> _filter;

        public ObjectCreationSpawnerSystem(SpawnersConfiguration spawnersConfiguration)
        {
            _spawnersConfiguration = spawnersConfiguration;
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                Debug.Log(i);

                ref var spawnerComponent = ref _filter.Get1(i);
                Generate(_spawnersConfiguration, spawnerComponent, i);
            }
        }

        private void Generate(SpawnersConfiguration spawnersConfiguration, SpawnerComponent spawnerComponent, int index)
        {
            Object.Instantiate(spawnersConfiguration.Spawners[index].SpawnObject,
                spawnerComponent.CurrentPosition,
                Quaternion.identity);
        }
    }
}
