using TB_RPG_2D.Hero.Data;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI.HeroCard
{
    public class HeroCardManager : MonoBehaviour
    {
        [SerializeField] private HeroCardView _heroCardViewPrefab;
        [SerializeField] private Transform _parentTransform;
        
        private void SpawnHeroCards()
        {
            foreach (var data in HeroDataManager.Instance.Datas)
            {
                HeroCardModel model = new HeroCardModel(data);
                
                HeroCardView view = Instantiate(_heroCardViewPrefab, _parentTransform);
                view.SetModel(new HeroCardModel(data));
                
                HeroCardController controller = new HeroCardController(view, model);
            }
        }
    }
}