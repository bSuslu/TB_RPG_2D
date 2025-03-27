using System.Collections.Generic;
using TB_RPG_2D.EventSystem;
using TB_RPG_2D.EventSystem.Events;
using TB_RPG_2D.Settings;

namespace TB_RPG_2D.Services
{
    public class HeroSelectionService
    {
        public readonly List<int> SelectedHeroIds = new();

        private readonly int _requiredHeroCountForBattle;

        public HeroSelectionService()
        {
            _requiredHeroCountForBattle = SettingsProvider.Instance.HeroSelectionSettings.RequiredHeroCountForBattle;
        }

        public bool TrySelect(int heroId)
        {
            if (SelectedHeroIds.Count >= _requiredHeroCountForBattle)
                return false;

            SelectedHeroIds.Add(heroId);

            bool isSelectionComplete = SelectedHeroIds.Count == _requiredHeroCountForBattle;
            if (isSelectionComplete)
            {
                EventBus<HeroSelectionCompleteStateChangedEvent>.Publish(
                    new HeroSelectionCompleteStateChangedEvent(true));
            }

            return true;
        }

        public void Deselect(int heroId)
        {
            bool wasSelectionComplete = SelectedHeroIds.Count == _requiredHeroCountForBattle;
            SelectedHeroIds.Remove(heroId);

            if (wasSelectionComplete)
            {
                EventBus<HeroSelectionCompleteStateChangedEvent>.Publish(
                    new HeroSelectionCompleteStateChangedEvent(false));
            }
        }
    }
}