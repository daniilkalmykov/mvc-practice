using System.Runtime.CompilerServices;
using Sources.Scripts.Runtime.Models.Clients.Detectables;
using Sources.Scripts.Runtime.Models.Clients.Health;
using Sources.Scripts.Runtime.Models.Clients.Shooting.Weapons;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Sources.Scripts.Runtime.Controllers.WeaponControllers
{
    internal sealed class WeaponController : IWeaponController
    {
        private readonly Weapon _weapon;

        public WeaponController(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnUpdated()
        {
            _weapon.OnUpdated();
        }

        public bool CanShoot()
        {
            return _weapon.CanShoot();
        }
        
        public void Shoot(Detectable<IDamageable> detectable)
        {
            _weapon.Shoot(detectable);
        }
    }
}