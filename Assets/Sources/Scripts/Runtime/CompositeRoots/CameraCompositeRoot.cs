using Reflex.Attributes;
using Sources.Scripts.Editor.Configs.CameraConfigs;
using Sources.Scripts.Runtime.Controllers.CameraControllers;
using Sources.Scripts.Runtime.Models.Clients.Rotation;
using Sources.Scripts.Runtime.Models.Services.InputService;

namespace Sources.Scripts.Runtime.CompositeRoots
{
    internal sealed class CameraCompositeRoot : CompositeRoot
    {
        private ICameraController _cameraController;
        private IInputService _inputService;
        private ICameraConfig _cameraConfig;

        private void Update()
        {
            _cameraController.Rotate();
        }

        [Inject]
        public void Construct(IInputService inputService, ICameraConfig cameraConfig)
        {
            _inputService = inputService;
            _cameraConfig = cameraConfig;
        }
        
        public override void Compose()
        {
            _cameraController =
                new FirstPersonViewCameraController(_inputService, new LocalRotationRotator(transform),
                    _cameraConfig.MinXRotation, _cameraConfig.MaxXRotation, _cameraConfig.Sensitivity);
        }
    }
}