using System;

namespace Sources.Scripts.Runtime.Models.Clients.Health
{
    internal sealed class DefaultHealth : IDamageable
    {
        public DefaultHealth(int health)
        {
            Health = health;
        }

        public int Health { get; private set; }

        public void TryGetDamage(int damage)
        {
            if (damage <= 0)
                throw new Exception($"Damage can't be {damage}");

            Health -= damage;
        }
    }
}