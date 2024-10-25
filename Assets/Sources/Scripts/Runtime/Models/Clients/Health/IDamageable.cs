namespace Sources.Scripts.Runtime.Models.Clients.Health
{
    public interface IDamageable
    {
        int Health { get; }

        void TryGetDamage(int damage);
    }
}