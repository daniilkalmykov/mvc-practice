using JetBrains.Annotations;
using UnityEngine;

namespace Sources.Scripts.Runtime.Models.Clients.Raycasting
{
    public static class Raycaster<T>  where T : MonoBehaviour
    {
        [CanBeNull]
        public static T RaycastByComponent(Vector3 origin, Vector3 target)
        {
            if (Physics.Raycast(origin, target, out var hit) == false)
                return null;

            return hit.transform.TryGetComponent(out T t) ? t : null;
        }
    }
}