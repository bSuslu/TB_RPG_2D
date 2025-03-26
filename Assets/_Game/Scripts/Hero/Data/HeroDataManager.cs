using System.Collections.Generic;
using System.Linq;
using TB_RPG_2D.Services;
using TB_RPG_2D.Settings;
using TB_RPG_2D.Singleton;

namespace TB_RPG_2D.Hero.Data
{
    public class HeroDataManager : MonoSingleton<HeroDataManager>
    {
        public List<HeroData> Datas { get; private set; } = new();
        
        private void Start()
        {
            PopulateDatas();
        }
        
        private void PopulateDatas()
        {
            var configs = SettingsProvider.Instance.HeroCollectionSettings.Configs;
            var persistentDatas = ServicesProvider.Instance.HeroResourceService.PersistentDatas;
            
            int initialUnlockedHeroCount = SettingsProvider.Instance.HeroCollectionSettings.InitialUnlockedHeroCount;
            
            
            for (int i = 0; i < configs.Length; i++)
            {
                bool isUnlocked = i < initialUnlockedHeroCount;
                var persistentData = persistentDatas.FirstOrDefault(x => x.Id == configs[i].Id);
                HeroData heroData = persistentData == null ? new HeroData(configs[i], isUnlocked) : new HeroData(configs[i], persistentData);
                Datas.Add(heroData);
            }
        }
    }
}