using Sources.Scripts.Runtime.Models.Clients.Detectables;
using Sources.Scripts.Runtime.Models.Clients.Health;

namespace Sources.Scripts.Runtime.Controllers.WeaponControllers
{
    public interface IWeaponController
    {
        void OnUpdated();
        void Shoot(Detectable<IDamageable> detectable);
    }
}