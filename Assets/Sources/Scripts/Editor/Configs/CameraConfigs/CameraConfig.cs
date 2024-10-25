using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Sources.Scripts.Editor.Configs.CameraConfigs
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Configs/Camera", order = 51)]
    internal sealed class CameraConfig : ScriptableObject, ICameraConfig
    {
        [field: SerializeField] public float Sensitivity { get; private set; }
        [field: SerializeField] public float MinXRotation { get; private set; }
        [field: SerializeField] public float MaxXRotation { get; private set; }
    }
}