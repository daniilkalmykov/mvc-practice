using Reflex.Core;
using Sources.Scripts.Runtime.Models.Services.InputService;
using UnityEngine;

namespace Sources.Scripts.Runtime.Installers
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

            containerBuilder.AddSingleton(_inputService, typeof(IInputService));
        }
    }
}