using CJ.VoxelCar.Camera.Configuration;
using CJ.VoxelCar.Camera.Systems;
using Zenject;

namespace CJ.VoxelCar.Camera
{
    public class CameraModule : Installer<CameraModule>
    {
        public override void InstallBindings()
        {
            Container.Bind<CameraConfiguration>().FromScriptableObjectResource("CameraConfiguration").AsSingle();

            Container.Bind<MovementCameraSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<CameraSystemsExecutor>().AsSingle().NonLazy();
        }
    }
}

