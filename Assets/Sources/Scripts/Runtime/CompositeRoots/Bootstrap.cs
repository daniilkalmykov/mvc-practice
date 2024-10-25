using UnityEngine;

namespace Sources.Scripts.Runtime.CompositeRoots
{
    internal sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CompositeRoot[] _compositeRoots;

        private void Awake()
        {
            foreach (var compositeRoot in _compositeRoots)
                compositeRoot.Compose();
        }
    }
}