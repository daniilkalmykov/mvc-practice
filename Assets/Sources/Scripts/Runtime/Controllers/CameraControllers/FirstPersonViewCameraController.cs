using System.Runtime.CompilerServices;
using Sources.Scripts.Runtime.Models.Clients.Rotation;
using Sources.Scripts.Runtime.Models.Services.InputService;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-CSharp")]

namespace Sources.Scripts.Runtime.Controllers.CameraControllers
{
    internal sealed class FirstPersonViewCameraController : ICameraController
    {
        private readonly IInputService _inputService;
        private readonly IRotatable _rotatable;
        private readonly float _minXRotation;
        private readonly float _maxXRotation;
        private readonly float _sensitivity;

        private float _rotationX;
        private float _rotationY;

        public FirstPersonViewCameraController(IInputService inputService, IRotatable rotatable, float minXRotation,
            float maxXRotation, float sensitivity)
        {
            _inputService = inputService;
            _rotatable = rotatable;
            _minXRotation = minXRotation;
            _maxXRotation = maxXRotation;
            _sensitivity = sensitivity;
        }

        public void Rotate()
        {
            var mouseX = _inputService.MouseX;
            var mouseY = _inputService.MouseY;

            mouseX *= Time.deltaTime * _sensitivity;
            mouseY *= Time.deltaTime * _sensitivity;

            _rotationX -= mouseY;
            _rotationX = Mathf.Clamp(_rotationX, _minXRotation, _maxXRotation);

            _rotationY += mouseX;

            _rotatable.Rotate(new Vector3(_rotationX, _rotationY, 0f));
        }
    }
}