using TB_RPG_2D.Singleton;
using UnityEngine;

namespace TB_RPG_2D.Settings
{
    public class SettingsProvider : MonoSingleton<SettingsProvider>
    {
        [field: SerializeField] public HeroCollectionSettings HeroCollectionSettings { get; private set; }
        [field: SerializeField] public HeroAttributeSettings HeroAttributeSettings { get; private set; }
    }
}