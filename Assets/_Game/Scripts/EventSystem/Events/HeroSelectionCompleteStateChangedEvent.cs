namespace TB_RPG_2D.EventSystem.Events
{
    public class HeroSelectionCompleteStateChangedEvent : IEvent
    {
        public bool IsComplete { get; set; }

        public HeroSelectionCompleteStateChangedEvent(bool isComplete)
        {
            IsComplete = isComplete;
        }
    }
}