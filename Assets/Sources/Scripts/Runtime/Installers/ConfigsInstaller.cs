using Reflex.Core;
using Sources.Scripts.Editor.Configs.CameraConfigs;
using Sources.Scripts.Editor.Configs.WeaponConfigs;
using UnityEngine;

namespace Sources.Scripts.Runtime.Installers
{
    internal sealed class ConfigsInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private PistolConfig _pistolConfig;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(_pistolConfig, typeof(IWeaponConfig));
            containerBuilder.AddSingleton(_cameraConfig, typeof(ICameraConfig));
        }
    }
}