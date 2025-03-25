using System;
using TB_RPG_2D.Hero.Data;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI.HeroCard
{
    public class HeroCard : MonoBehaviour
    {
        [SerializeField] private HeroCardView _heroCardView;
        [SerializeField] private HeroCardLongPressController _heroCardLongPressController;

        private HeroCardModel _heroCardModel;
        public HeroData HeroData { get; private set; }

        private CardSelectionState _cardSelectionState;
        public Action<int, CardSelectionState> OnClick { get; set; }

        public void SetData(HeroData heroData)
        {
            HeroData = heroData;

            _heroCardModel = new HeroCardModel(heroData);

            _heroCardView.SetModel(_heroCardModel);
            _heroCardView.OnClick += OnHeroCardViewClicked;

            _heroCardLongPressController.Setup(heroData);
        }

        private void OnHeroCardViewClicked()
        {
            Debug.Log($"clicked on {_heroCardModel.Name} from controller");

            if (_cardSelectionState == CardSelectionState.NotSelectable)
            {
                Debug.Log($"Hero Card {_heroCardModel.Name} is not selectable");
                return;
            }

            OnClick?.Invoke(_heroCardModel.Id, _cardSelectionState);
        }

        public void Dispose()
        {
            _heroCardView.OnClick -= OnHeroCardViewClicked;
        }
    }
}