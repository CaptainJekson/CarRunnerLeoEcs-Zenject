using System;
using System.Collections.Generic;
using UnityEngine;

namespace CJ.VoxelCar.Spawner.Configuration
{
    [Serializable]
    public class Spawner
    {
        public List<GameObject> SpawnObjects;
        public Vector3 Position;
        [Range(0, 200)] public float _distanceMin;
        [Range(0, 200)] public float _distanceMax;
    }
}