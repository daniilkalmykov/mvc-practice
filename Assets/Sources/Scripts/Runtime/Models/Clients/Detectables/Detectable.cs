using UnityEngine;

namespace Sources.Scripts.Runtime.Models.Clients.Detectables
{
    public abstract class Detectable<T> : MonoBehaviour
    {
        public void Init(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
    }
}