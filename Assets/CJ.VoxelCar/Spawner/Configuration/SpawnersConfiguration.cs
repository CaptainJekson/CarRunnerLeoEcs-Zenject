using System.Collections.Generic;
using UnityEngine;

namespace CJ.VoxelCar.Spawner.Configuration
{
    [CreateAssetMenu(fileName = "SpawnersConfiguration", menuName = "Configuration/SpawnersConfiguration")]
    public class SpawnersConfiguration : ScriptableObject
    {
        public List<Spawn> Spawners;
    }
}


