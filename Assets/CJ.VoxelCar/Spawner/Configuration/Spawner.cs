using System;
using System.Collections.Generic;
using UnityEngine;

namespace CJ.VoxelCar.Spawner.Configuration
{
    [Serializable]
    public class Spawn
    {
        public List<GameObject> SpawnObjects;
        public Vector3 Position;
        [Range(0, 200)] public float DistanceMin;
        [Range(0, 200)] public float DistanceMax;
        [Range(0, 500)] public float DistanceDestruction;
    }
}