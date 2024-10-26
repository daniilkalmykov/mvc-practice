using Reflex.Attributes;
using Sources.Scripts.Runtime.Controllers.WeaponControllers;
using Sources.Scripts.Runtime.Models.Clients.Factories.FactoryMethods;
using Sources.Scripts.Runtime.Models.Clients.Factories.FactoryMethods.BulletsFactoryMethods;
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
        private WeaponController _weaponController;

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

            _weaponController = new PlayerWeaponController(weapon, _inputService, Camera.main);
        }
    }
}