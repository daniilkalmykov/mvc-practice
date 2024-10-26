using Sources.Scripts.Runtime.Models.Clients.Shooting.Weapons;

namespace Sources.Scripts.Runtime.Controllers.WeaponControllers
{
    public abstract class WeaponController
    {
        protected WeaponController(Weapon weapon)
        {
            Weapon = weapon;
        }

        protected Weapon Weapon { get; }

        public void OnUpdated()
        {
            Weapon?.OnUpdated();
        }
    }
}