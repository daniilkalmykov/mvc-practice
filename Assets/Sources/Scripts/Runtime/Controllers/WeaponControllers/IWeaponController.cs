using Sources.Scripts.Runtime.Models.Clients.Detectables;
using Sources.Scripts.Runtime.Models.Clients.Health;

namespace Sources.Scripts.Runtime.Controllers.WeaponControllers
{
    public interface IWeaponController
    {
        void OnUpdated();
        bool CanShoot();
        void Shoot(Detectable<IDamageable> detectable);
    }
}