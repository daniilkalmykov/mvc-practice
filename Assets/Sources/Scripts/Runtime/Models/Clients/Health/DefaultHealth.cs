using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Sources.Scripts.Runtime.Models.Clients.Health
{
    internal sealed class DefaultHealth : IDamageable
    {
        public DefaultHealth(int health)
        {
            Health = health;
        }

        public int Health { get; private set; }

        public void GetDamage(int damage)
        {
            if (damage <= 0)
                throw new Exception($"Damage can't be equal to {damage}");

            Health -= damage;
        }
    }
}