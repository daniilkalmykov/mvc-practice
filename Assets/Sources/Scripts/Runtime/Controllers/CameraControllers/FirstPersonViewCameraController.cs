using Sources.Scripts.Runtime.Models.Clients.Rotation;
using Sources.Scripts.Runtime.Models.Services.InputService;
using UnityEngine;

namespace Sources.Scripts.Runtime.Controllers.CameraControllers
{
    internal sealed class FirstPersonViewCameraController : ICameraController
    {
        private readonly IInputService _inputService;
        private readonly IRotatable _rotatable;
        
        private float _rotationX = 0f;
        private float _rotationY = 0f;

        public FirstPersonViewCameraController(IInputService inputService, IRotatable rotatable)
        {
            _inputService = inputService;
            _rotatable = rotatable;
        }

        public void Rotate()
        {
            var mouseX = _inputService.MouseX;
            var mouseY = _inputService.MouseY;
            
            mouseX *= Time.deltaTime;
            mouseY *= Time.deltaTime;

            _rotationX -= mouseY;
            _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

            _rotationY += mouseX;

            _rotatable.Rotate(new Vector3(_rotationX, _rotationY, 0f));
        }
    }
}