using System.Runtime.CompilerServices;
using Sources.Scripts.Runtime.Models.Clients.Detectables;
using Sources.Scripts.Runtime.Models.Clients.Health;
using Sources.Scripts.Runtime.Models.Clients.Shooting.Bullets;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Sources.Scripts.Runtime.Models.Clients.Shooting.Weapons
{
    internal sealed class Pistol : Weapon
    {
        private readonly IBullet _bullet;

        public Pistol(int damage, float delay, IBullet bullet) : base(damage, delay)
        {
            _bullet = bullet;
        }

        protected override async void Hit(Detectable<IDamageable> detectable)
        {
            var target = detectable.transform.position;
            target.y = 1;

            await _bullet.Fly(target);

            detectable.Value.GetDamage(Damage);
        }
    }
}