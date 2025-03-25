using UnityEngine;

namespace TB_RPG_2D.Settings
{
    [CreateAssetMenu(fileName = "HeroSelectionSettings", menuName = "Settings/HeroSelection")]
    public class HeroSelectionSettings : ScriptableObject
    {
        [field: SerializeField] public int RequiredHeroCountForBattle { get; private set; } = 3;
    }
}