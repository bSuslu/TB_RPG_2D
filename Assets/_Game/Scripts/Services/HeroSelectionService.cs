using System.Collections.Generic;
using TB_RPG_2D.EventSystem;
using TB_RPG_2D.EventSystem.Events;
using TB_RPG_2D.Hero.UI.HeroCard;
using TB_RPG_2D.Settings;
using UnityEngine;

namespace TB_RPG_2D.Services
{
    public class HeroSelectionService
    {
        public List<HeroCard> SelectedHeroCards { get; } = new();

        private readonly int _requiredHeroCountForBattle;

        public HeroSelectionService()
        {
            _requiredHeroCountForBattle = SettingsProvider.Instance.HeroSelectionSettings.RequiredHeroCountForBattle;
        }

        public bool TryAddHeroCardToSelection(HeroCard heroCard)
        {
            if (SelectedHeroCards.Count >= _requiredHeroCountForBattle)
                return false;
            
            SelectedHeroCards.Add(heroCard);
            Debug.Log($"Hero card {heroCard.HeroData.Name} added to selection");

            bool isSelectionComplete = SelectedHeroCards.Count == _requiredHeroCountForBattle;

            if (isSelectionComplete)
            {
                EventBus<HeroSelectionCompleteStateChangedEvent>.Publish(
                    new HeroSelectionCompleteStateChangedEvent(true));
                
                Debug.Log("Hero selection complete");
            }
            return true;
        }


        public void DeselectHeroCard(HeroCard heroCard)
        {
            bool wasSelectionComplete = SelectedHeroCards.Count == _requiredHeroCountForBattle;
            SelectedHeroCards.Remove(heroCard);
            Debug.Log($"Hero card {heroCard.HeroData.Name} removed from selection");
            
            if (wasSelectionComplete)
            {
                EventBus<HeroSelectionCompleteStateChangedEvent>.Publish(
                    new HeroSelectionCompleteStateChangedEvent(false));
                
                Debug.Log("Hero selection incomplete");
            }
        }
    }
}