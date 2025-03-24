using TB_RPG_2D.Hero.Config;
using UnityEngine;

namespace TB_RPG_2D.Settings
{
    [CreateAssetMenu(fileName = "HeroCollectionSettings", menuName = "Settings/HeroCollection")]
    public class HeroCollectionSettings : ScriptableObject
    {
        [field: SerializeField] public int InitialUnlockedHeroCount { get; private set; } = 3;
        [field: SerializeField] public HeroConfig[] Configs { get; private set; }
    }
}