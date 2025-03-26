using TB_RPG_2D.EventSystem;
using TB_RPG_2D.EventSystem.Events;
using TB_RPG_2D.UI.Core;

namespace TB_RPG_2D.UI.Handler
{
    // TODO: can be event channel for event base activations
    public class BattleButtonActivationHandler : UIEntity
    {
        private EventBinding<HeroSelectionCompleteStateChangedEvent> _heroSelectionCompleteStateChangedEventBinding;
        public override void Init()
        {
            base.Init();
            
            _heroSelectionCompleteStateChangedEventBinding = new EventBinding<HeroSelectionCompleteStateChangedEvent>(OnHeroSelectionCompleteStateChanged);
            EventBus<HeroSelectionCompleteStateChangedEvent>.Subscribe(_heroSelectionCompleteStateChangedEventBinding);
        }

        private void OnHeroSelectionCompleteStateChanged(HeroSelectionCompleteStateChangedEvent heroSelectionCompleteStateChangedEvent)
        {
            gameObject.SetActive(heroSelectionCompleteStateChangedEvent.IsComplete);
        }

        public override void Dispose()
        {
            base.Dispose();
            EventBus<HeroSelectionCompleteStateChangedEvent>.Unsubscribe(
                _heroSelectionCompleteStateChangedEventBinding);
        }
    }
}
