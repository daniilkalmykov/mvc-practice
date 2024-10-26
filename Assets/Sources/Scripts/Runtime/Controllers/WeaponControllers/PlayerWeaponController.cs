using System;
using System.Runtime.CompilerServices;
using Sources.Scripts.Runtime.Models.Clients.Detectables;
using Sources.Scripts.Runtime.Models.Clients.Health;
using Sources.Scripts.Runtime.Models.Clients.Raycasting;
using Sources.Scripts.Runtime.Models.Clients.Shooting.Weapons;
using Sources.Scripts.Runtime.Models.Services.InputService;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Sources.Scripts.Runtime.Controllers.WeaponControllers
{
    internal sealed class PlayerWeaponController : WeaponController, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly Camera _camera;

        public PlayerWeaponController(Weapon weapon, IInputService inputService, Camera camera) : base(weapon)
        {
            _inputService = inputService;
            _camera = camera;

            _inputService.ShootButtonClicked += OnShootButtonClicked;
        }

        public void Dispose()
        {
            _inputService.ShootButtonClicked -= OnShootButtonClicked;
        }

        private void OnShootButtonClicked()
        {
            var screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f);

            var ray = _camera.ScreenPointToRay(screenCenter);

            if (Raycaster<Detectable<IDamageable>>.Raycast(ray, out var detectable))
            {
                Weapon.Shoot(detectable);
            }
        }
    }
}