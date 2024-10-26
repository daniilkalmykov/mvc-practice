using Sources.Scripts.Runtime.Models.Clients.Detectables;
using Sources.Scripts.Runtime.Models.Clients.Health;
using UnityEngine;

namespace Sources.Scripts.Runtime.CompositeRoots
{
    internal sealed class EnemyCompositeRoot : CompositeRoot
    {
        [SerializeField] private Detectable<IDamageable> _detectable;

        private IDamageable _damageable;

        private void Update()
        {
            Debug.LogError(_damageable.Health);
        }

        public override void Compose()
        {
            _damageable = new DefaultHealth(1);

            _detectable.Init(_damageable);
        }
    }
}