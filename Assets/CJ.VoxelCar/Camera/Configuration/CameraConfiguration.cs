using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace CJ.VoxelCar.Camera.Configuration
{
    [CreateAssetMenu(fileName = "CameraConfiguration", menuName = "Configuration/CameraConfiguration")]
    public class CameraConfiguration : ScriptableObject
    {
        [Range(0, 30)] public float CameraZoom;
    }
}

