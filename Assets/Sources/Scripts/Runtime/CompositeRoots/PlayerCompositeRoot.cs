using Reflex.Attributes;
using Sources.Scripts.Editor.Configs.WeaponConfigs;
using Sources.Scripts.Runtime.Controllers.WeaponControllers;
using Sources.Scripts.Runtime.Models.Clients.Detectables;
using Sources.Scripts.Runtime.Models.Clients.Factories.FactoryMethods;
using Sources.Scripts.Runtime.Models.Clients.Factories.FactoryMethods.BulletsFactoryMethods;
using Sources.Scripts.Runtime.Models.Clients.Health;
using Sources.Scripts.Runtime.Models.Clients.Raycasting;
using Sources.Scripts.Runtime.Models.Clients.Shooting.Bullets;
using Sources.Scripts.Runtime.Models.Clients.Shooting.Weapons;
using Sources.Scripts.Runtime.Models.Services.InputService;
using UnityEngine;

namespace Sources.Scripts.Runtime.CompositeRoots
{
    internal sealed class PlayerCompositeRoot : CompositeRoot
    {
        [SerializeField] private Bullet _defaultBullet;
        [SerializeField] private Vector3 _position;

        private IInputService _inputService;
        private IWeaponController _weaponController;
        private Bullet _instantiatedBullet;
        private IWeaponConfig _weaponConfig;

        private void OnEnable()
        {
            _inputService.ShootButtonClicked += OnShootButtonClicked;
        }

        private void OnDisable()
        {
            _inputService.ShootButtonClicked -= OnShootButtonClicked;
        }

        private void Update()
        {
            _weaponController.OnUpdated();
        }

        [Inject]
        public void Construct(IInputService inputService, IWeaponConfig weaponConfig)
        {
            _inputService = inputService;
            _weaponConfig = weaponConfig;
        }

        public override void Compose()
        {
            IFactoryMethod<Bullet> factoryMethod = new BulletFactoryMethod(_position, null, _defaultBullet.gameObject);

            _instantiatedBullet = factoryMethod.Create();
            Weapon weapon = new Pistol(_weaponConfig.Damage, _weaponConfig.Delay, _instantiatedBullet);

            _weaponController = new WeaponController(weapon);
        }

        private void OnShootButtonClicked()
        {
            var screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f);

            if (Camera.main == null)
                return;

            var ray = Camera.main.ScreenPointToRay(screenCenter);

            if (Raycaster<Detectable<IDamageable>>.Raycast(ray, out var detectable) == false)
                return;

            if (_weaponController.CanShoot() == false)
                return;
            
            _instantiatedBullet.transform.localPosition = _position;

            _instantiatedBullet.gameObject.SetActive(true);
            _weaponController.Shoot(detectable);
        }
    }
}