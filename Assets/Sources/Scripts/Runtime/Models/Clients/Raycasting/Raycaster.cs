using UnityEngine;

namespace Sources.Scripts.Runtime.Models.Clients.Raycasting
{
    public static class Raycaster<T> where T : MonoBehaviour
    {
        public static T RaycastByComponent(Vector3 origin, Vector3 target)
        {
            if (Physics.Raycast(origin, target, out var hit) == false)
                return default;

            return hit.transform.TryGetComponent(out T t) ? t : default;
        }
    }
}