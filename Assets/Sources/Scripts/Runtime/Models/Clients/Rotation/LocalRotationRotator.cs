using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Sources.Scripts.Runtime.Models.Clients.Rotation
{
    internal sealed class LocalRotationRotator : IRotatable
    {
        private readonly Transform _transform;

        public LocalRotationRotator(Transform transform)
        {
            _transform = transform;
        }

        public void Rotate(Vector3 direction)
        {
            _transform.localRotation = Quaternion.Euler(direction);
        }
    }
}