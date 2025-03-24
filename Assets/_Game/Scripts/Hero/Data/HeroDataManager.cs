using System.Collections.Generic;
using System.Linq;
using TB_RPG_2D.Services;
using TB_RPG_2D.Settings;
using UnityEngine;

namespace TB_RPG_2D.Hero.Data
{
    public class HeroDataManager : MonoBehaviour
    {
        public List<HeroData> Datas { get; private set; } = new();
        
        private void Start()
        {
            PopulateDatas();
            LogDatas();
        }

        private void LogDatas()
        {
            foreach (var data in Datas)
            {
                Debug.Log(data.ToString());
            }
        }

        private void PopulateDatas()
        {
            var configs = SettingsProvider.Instance.HeroCollectionSettings.Configs;
            var persistentDatas = ServicesProvider.Instance.HeroResourceService.PersistentDatas;
            
            for (int i = 0; i < configs.Length; i++)
            {
                var persistentData = persistentDatas.FirstOrDefault(x => x.Id == configs[i].Id);
                Datas[i] = persistentData == null ? new HeroData(configs[i]) : new HeroData(configs[i], persistentData);
                Debug.Log(Datas[i].ToString());
            }
        }
    }
}