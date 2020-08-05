using System.Collections.Generic;
using UnityEngine;

namespace CJ.VoxelCar.Player.Configuration
{
    [CreateAssetMenu(fileName = "RoadConfiguration", menuName = "Configuration/RoadConfiguration")]
    public class RoadConfiguration : ScriptableObject
    {
        [Header("RoadPoints")]
        public List<float> PointsSide;
    }
}
