using TB_RPG_2D.Hero.Data;
using TB_RPG_2D.Services;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI.HeroCard
{
    public class HeroCard : MonoBehaviour
    {
        [SerializeField] private HeroCardView _heroCardView;
        [SerializeField] private HeroCardLongPressController _heroCardLongPressController;
        
        public HeroData HeroData { get; private set; }
        
        private HeroCardModel _heroCardModel;
        private HeroSelectionService _heroSelectionService;
        private bool _isSelected;

        public void SetData(HeroData heroData)
        {
            HeroData = heroData;
            _heroSelectionService = ServicesProvider.Instance.HeroSelectionService;
            
            _heroCardModel = new HeroCardModel(heroData);
            
            _heroCardView.SetModel(_heroCardModel);
            _heroCardView.OnClick += OnHeroCardViewClicked;

            _heroCardLongPressController.Setup(heroData);
        }

        private void OnHeroCardViewClicked()
        {
            if (!_heroCardModel.IsUnlocked)
                return;

            if (_heroCardLongPressController.IsLongPressActive)
                return;

            if (_isSelected)
            {
                _heroSelectionService.DeselectHeroCard(this);
                Deselect();
            }
            else if (_heroSelectionService.TryAddHeroCardToSelection(this))
            {
                Select();
            }
        }

        private void Deselect()
        {
            _isSelected = false;
        }

        private void Select()
        {
            _isSelected = true;
        }

        public void Dispose()
        {
            _heroCardView.OnClick -= OnHeroCardViewClicked;
        }
    }
}