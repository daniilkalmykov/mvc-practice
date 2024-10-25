using UnityEngine;

namespace Sources.Scripts.Runtime.Models.Clients.Rotation
{
    internal sealed class EulerAngelsRotation : IRotatable
    {
        private readonly Transform _transform;
        private readonly float _speed;

        public EulerAngelsRotation(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Rotation(Vector3 direction)
        {
            _transform.localRotation = Quaternion.Euler(direction * _speed);
        }
    }
}