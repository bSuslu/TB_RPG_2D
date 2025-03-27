using System.Collections.Generic;
using System.Linq;
using TB_RPG_2D.Enemy.Data;
using TB_RPG_2D.Settings;
using UnityEngine;

namespace TB_RPG_2D.Enemy.Entity
{
    public class EnemyEntityManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> _entityParents = new ();
        [SerializeField] private EnemyEntity _enemyEntityPrefab;

        private void Start()
        {
            CreateHeroEntities();
        }

        private void CreateHeroEntities()
        {
            List<EnemyData> datas = EnemyDataManager.Instance.Datas
                .OrderBy(_ => Random.value)
                .Take(SettingsProvider.Instance.EnemyCollectionSettings.EnemyAmountInBattle)
                .ToList();
            
            for (int i = 0; i < datas.Count; i++)
            {
                EnemyEntity entity = Instantiate(_enemyEntityPrefab, _entityParents[i]);
                entity.SetData(datas[i]);
            }
        }
    }
}