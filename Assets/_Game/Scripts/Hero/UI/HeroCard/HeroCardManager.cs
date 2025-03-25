using System.Collections.Generic;
using TB_RPG_2D.Hero.Data;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI.HeroCard
{
    public class HeroCardManager : MonoBehaviour
    {
        [SerializeField] private HeroCard _heroCardPrefab;
        [SerializeField] private Transform _parentTransform;

        private readonly List<HeroCard> _heroCards = new ();
        
        private void Start()
        {
            SpawnHeroCards();
        }
        private void SpawnHeroCards()
        {
            foreach (var data in HeroDataManager.Instance.Datas)
            {
                HeroCard card = Instantiate(_heroCardPrefab, _parentTransform);
                card.SetData(data);
                _heroCards.Add(card);
            }
        }
        private void OnDestroy()
        {
            foreach (var controller in _heroCards)
            {
                controller.Dispose();
            }
        }
    }
}