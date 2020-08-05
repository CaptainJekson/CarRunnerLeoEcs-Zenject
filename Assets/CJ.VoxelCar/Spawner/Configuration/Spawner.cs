using System;
using UnityEngine;

namespace CJ.VoxelCar.Spawner.Configuration
{
    [Serializable]
    public class Spawner
    {
        public GameObject SpawnObject;
        public Vector3 Position;
        [Range(0, 100)] public float _distanceMin;
        [Range(0, 100)] public float _distanceMax;
        [Range(0, 200)] public float _initDistance;
        [Range(0, 200)] public float _destructionDistance;
        public bool _isInitDistance;
    }
}