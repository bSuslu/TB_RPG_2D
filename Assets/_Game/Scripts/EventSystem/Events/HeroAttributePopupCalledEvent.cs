using TB_RPG_2D.Hero.Data;
using UnityEngine;

namespace TB_RPG_2D.EventSystem.Events
{
    public class HeroAttributePopupCalledEvent : IEvent
    {
        public bool Activate;
        public HeroData HeroData;
        public Vector3 Position;
        public bool IsCalledFromWorldSpace;
        
        public HeroAttributePopupCalledEvent(bool activate, HeroData heroData, Vector3 position, bool isCalledFromWorldSpace)
        {
            Activate = activate;
            HeroData = heroData;
            Position = position;
            IsCalledFromWorldSpace = isCalledFromWorldSpace;
        }
        
    }
}