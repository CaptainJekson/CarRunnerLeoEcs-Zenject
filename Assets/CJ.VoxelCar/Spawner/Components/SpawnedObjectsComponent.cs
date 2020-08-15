using Leopotam.Ecs;
using UnityEngine;

namespace CJ.VoxelCar.Spawner.Components
{
    public struct SpawnedObjectsComponent
    {
        public EcsEntity Entity;
        public GameObject SpawnedObject;
    }
}
