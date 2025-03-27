using System.Collections.Generic;
using System.Linq;
using TB_RPG_2D.Settings;
using TB_RPG_2D.Singleton;
using UnityEngine;

namespace TB_RPG_2D.Enemy.Data
{
    public class EnemyDataManager: MonoSingleton<EnemyDataManager>
    {
        public List<EnemyData> Datas { get; private set; } = new();

        public EnemyDataManager()
        {
            PopulateDatas();
        }

        private void PopulateDatas()
        {
            var configs = SettingsProvider.Instance.EnemyCollectionSettings.Configs;

            foreach (var config in configs)
            {
                Datas.Add(new EnemyData(config));
            }
        }
        
        public EnemyData GetRandomEnemyData () => Datas[Random.Range(0, Datas.Count)];
        public EnemyData GetEnemyDataById(int id) => Datas.FirstOrDefault(x => x.Id == id);
    }
}