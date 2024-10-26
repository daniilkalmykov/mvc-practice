using Reflex.Attributes;
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
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Vector3 _position;
        
        private IInputService _inputService;
        private IWeaponController _weaponController;

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
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public override void Compose()
        {
            IFactoryMethod<IBullet> factoryMethod = new BulletFactoryMethod(_position, null, _bullet.gameObject);

            Weapon weapon = new Pistol(10, 1, factoryMethod.Create());

            _weaponController = new WeaponController(weapon);
        }

        private void OnShootButtonClicked()
        {
            var screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f);

            if (Camera.main == null) 
                return;
            
            var ray = Camera.main.ScreenPointToRay(screenCenter);

            if (Raycaster<Detectable<IDamageable>>.Raycast(ray, out var detectable))
                _weaponController.Shoot(detectable);
        }
    }
}