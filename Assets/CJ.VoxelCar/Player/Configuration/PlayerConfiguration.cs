using UnityEngine;
using Zenject;

namespace CJ.VoxelCar.Player.Configuration
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "Configuration/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        public GameObject PlayerObject;
        public Vector3 StartPosition;
        public float Speed;
        public float SideSpeed;

        [Header("Control")]
        public KeyCode MovementRigth;
        public KeyCode MovementLeft;
    }
}

