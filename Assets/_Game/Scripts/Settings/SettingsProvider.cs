using TB_RPG_2D.Singleton;
using UnityEngine;

namespace TB_RPG_2D.Settings
{
    public class SettingsProvider : Singleton<SettingsProvider>
    {
        [field: SerializeField] public HeroCollectionSettings HeroCollectionSettings { get; private set; }
    }
}