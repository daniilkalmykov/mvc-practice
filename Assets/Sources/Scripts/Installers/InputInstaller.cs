using Reflex.Core;
using Sources.Scripts.Models.Services.InputService;
using UnityEngine;

namespace Sources.Scripts.Installers
{
    internal sealed class InputInstaller : MonoBehaviour, IInstaller
    {
        private IInputService _inputService;

        private void Update()
        {
            _inputService?.OnUpdated();
        }

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            _inputService = new PCInput();
        }
    }
}