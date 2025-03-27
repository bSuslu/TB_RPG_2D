using TB_RPG_2D.Singleton;
using UnityEngine;

namespace TB_RPG_2D.Settings
{
    public class SettingsProvider : MonoSingleton<SettingsProvider>
    {
        [field: SerializeField] public HeroCollectionSettings HeroCollectionSettings { get; private set; }
        [field: SerializeField] public EnemyCollectionSettings EnemyCollectionSettings { get; private set; }
        [field: SerializeField] public HeroAttributeSettings HeroAttributeSettings { get; private set; }
        [field: SerializeField] public LongPressSettings LongPressSettings { get; private set; }
        [field: SerializeField] public HeroSelectionSettings HeroSelectionSettings { get; private set; }

    }
}