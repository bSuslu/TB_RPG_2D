
using System.Collections.Generic;
using TB_RPG_2D.Hero.Data;
using TB_RPG_2D.Hero.UI.HeroCard.MVC;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI.HeroCard
{
    public class HeroCardManager : MonoBehaviour
    {
        [SerializeField] private HeroCardView _heroCardViewPrefab;
        [SerializeField] private Transform _parentTransform;

        private List<HeroCardController> _heroCardControllers = new ();
        
        
        private void Start()
        {
            SpawnHeroCards();
        }
        
        private void SpawnHeroCards()
        {
            foreach (var data in HeroDataManager.Instance.Datas)
            {
                HeroCardModel model = new HeroCardModel(data);

                HeroCardView view = Instantiate(_heroCardViewPrefab, _parentTransform);
                view.SetModel(new HeroCardModel(data));

                _heroCardControllers.Add(new HeroCardController(model, view));
            }
        }

        private void OnDestroy()
        {
            foreach (var controller in _heroCardControllers)
            {
                controller.Dispose();
            }
        }
    }
}