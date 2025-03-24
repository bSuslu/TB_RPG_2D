using TB_RPG_2D.Settings;
using UnityEngine;

namespace TB_RPG_2D.Hero.Data
{
    public class HeroDataManager : MonoBehaviour
    {
        public HeroData[] Datas { get; private set; }
        
        private void Start()
        {
            var configs = SettingsProvider.Instance.HeroCollectionSettings.Configs;
            Datas = new HeroData[configs.Length];
            
            for (int i = 0; i < configs.Length; i++)
            {
                Datas[i] = new HeroData(configs[i]);
                Debug.Log(Datas[i].ToString());
            }
        }
    }
}