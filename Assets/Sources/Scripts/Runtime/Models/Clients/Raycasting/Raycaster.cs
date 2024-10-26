using JetBrains.Annotations;
using UnityEngine;

namespace Sources.Scripts.Runtime.Models.Clients.Raycasting
{
    public static class Raycaster<T> where T : MonoBehaviour
    {
        public static bool Raycast(Ray ray, out T t)
        {
            t = null;

            if (Physics.Raycast(ray, out var hit) == false)
                return false;

            if (hit.transform.TryGetComponent(out T component) == false)
                return false;

            t = component;

            return true;
        }
    }
}