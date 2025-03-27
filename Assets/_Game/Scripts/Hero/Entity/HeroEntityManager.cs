using System.Collections.Generic;
using TB_RPG_2D.Hero.Data;
using TB_RPG_2D.Services;
using UnityEngine;

namespace TB_RPG_2D.Hero.Entity
{
    public class HeroEntityManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> _entityParents = new ();
        [SerializeField] private HeroEntity _heroEntityPrefab;

        private void Start()
        {
            CreateHeroEntities();
        }

        private void CreateHeroEntities()
        {
            List<int> entityIds = ServicesProvider.Instance.HeroSelectionService.SelectedHeroIds;
            for (int i = 0; i < entityIds.Count; i++)
            {
                HeroData data = HeroDataManager.Instance.GetHeroDataById(entityIds[i]);
                HeroEntity heroEntity = Instantiate(_heroEntityPrefab, _entityParents[i]);
                heroEntity.SetData(data);
            }
        }
    }
}