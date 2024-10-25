using Reflex.Core;
using Sources.Scripts.Editor.Configs.CameraConfigs;
using UnityEngine;

namespace Sources.Scripts.Runtime.Installers
{
    internal sealed class ConfigsInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private CameraConfig _cameraConfig;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(_cameraConfig, typeof(ICameraConfig));
        }
    }
}