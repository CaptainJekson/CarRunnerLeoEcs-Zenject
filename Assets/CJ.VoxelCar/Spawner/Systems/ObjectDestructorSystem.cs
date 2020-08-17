using CJ.VoxelCar.Player.Components;
using CJ.VoxelCar.Spawner.Components;
using CJ.VoxelCar.Spawner.Configuration;
using Leopotam.Ecs;
using UnityEngine;

namespace CJ.VoxelCar.Spawner.Systems
{
    class ObjectDestructorSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent> _playerFilter;
        private EcsFilter<SpawnedObjectsComponent, DestructionComponent> _filter;

        public void Run()
        {
            ref var playerComponent = ref _playerFilter.Get1(0);

            foreach (var i in _filter)
            {
                ref var spawnedObjectComponent = ref _filter.Get1(i);
                ref var destructionComponent = ref _filter.Get2(i);

                if (Vector3.Distance(playerComponent.PlayerObject.transform.position,
                    spawnedObjectComponent.SpawnedObject.transform.position) > 
                    destructionComponent.DestructionDistance)
                {
                    Object.Destroy(spawnedObjectComponent.SpawnedObject);
                    spawnedObjectComponent.Entity.Destroy();
                }
            }
        }
    }
}
