using System.Runtime.CompilerServices;
using Sources.Scripts.Runtime.Models.Clients.Shooting.Bullets;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Sources.Scripts.Runtime.Models.Clients.Factories.FactoryMethods.BulletsFactoryMethods
{
    internal sealed class BulletFactoryMethod : IBulletFactoryMethod
    {
        private readonly Vector3 _position;
        private readonly Transform _parent;
        private readonly GameObject _prefab;

        public BulletFactoryMethod(Vector3 position, Transform parent, GameObject prefab)
        {
            _position = position;
            _parent = parent;
            _prefab = prefab;
        }

        public Bullet Create()
        {
            var gameObject = Object.Instantiate(_prefab, _position, Quaternion.identity, _parent);

            return gameObject.TryGetComponent(out Bullet bullet) ? bullet : null;
        }
    }
}