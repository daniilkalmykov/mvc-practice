using UnityEngine;

namespace Sources.Scripts.Editor.Configs.WeaponConfigs
{
    [CreateAssetMenu(fileName = "PistolConfig", menuName = "Configs/Weapons", order = 51)]
    internal sealed class PistolConfig : ScriptableObject, IWeaponConfig 
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float Delay { get; private set; }
    }
}