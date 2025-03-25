using System;
using TB_RPG_2D.UI.Controller;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI.HeroCard.MVC
{
    public class HeroCardController : IDisposable
    {
        private readonly HeroCardView _heroCardView;
        private readonly HeroCardModel _heroCardModel;
        private readonly LongPressDetector _longPressDetector;
        private CardSelectionState _cardSelectionState;
        
        public Action<int, CardSelectionState> OnClick { get; set; }

        public HeroCardController(HeroCardModel heroCardModel, HeroCardView heroCardView)
        {
            _heroCardModel = heroCardModel;
            _heroCardView = heroCardView;
            _longPressDetector = _heroCardView.LongPressDetector;
            
            _heroCardView.OnClick += OnHeroCardViewClicked;
            _longPressDetector.OnLongPressed += OnLongPressed;
            _longPressDetector.OnLongPressReleased += OnLongPressReleased;
        }

        private void OnLongPressReleased()
        {
            throw new NotImplementedException();
        }

        private void OnLongPressed()
        {
            throw new NotImplementedException();
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
            _longPressDetector.OnLongPressed -= OnLongPressed;
            _longPressDetector.OnLongPressReleased -= OnLongPressReleased;
        }
    }
}