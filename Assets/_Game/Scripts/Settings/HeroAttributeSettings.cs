using UnityEngine;

namespace TB_RPG_2D.Settings
{
    [CreateAssetMenu(fileName = "HeroAttributeSettings", menuName = "Settings/HeroAttribute")]
    public class HeroAttributeSettings : ScriptableObject
    {
        [field: SerializeField] public float LevelBaseHealthMultiplier { get; private set; } = .1f;
        [field: SerializeField] public float LevelBaseAttackPowerMultiplier { get; private set; } = .1f;
    }
}