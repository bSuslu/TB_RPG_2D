using System;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI.HeroCard.MVC
{
    public class HeroCardController : IDisposable
    {
        private readonly HeroCardView _heroCardView;
        private readonly HeroCardModel _heroCardModel;
        private CardSelectionState _cardSelectionState;

        public Action<int, CardSelectionState> OnClick { get; set; }

        public HeroCardController(HeroCardModel heroCardModel, HeroCardView heroCardView)
        {
            _heroCardModel = heroCardModel;
            _heroCardView = heroCardView;

            _heroCardView.OnClick += OnHeroCardViewClicked;
        }

        private void OnHeroCardViewClicked()
        {
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