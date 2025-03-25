using TB_RPG_2D.EventSystem;
using TB_RPG_2D.EventSystem.Events;
using TB_RPG_2D.Hero.Data;
using TB_RPG_2D.UI.Controller;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI.HeroCard
{
    public class HeroCardLongPressController: MonoBehaviour
    {
        [SerializeField] private LongPressDetector _longPressDetector;
        [SerializeField] private Transform _popupPositionTransform;
        public bool IsLongPressActive { get; private set; }

        private HeroData _data;
        
        private void Awake()
        {
            _longPressDetector.OnLongPressed += HeroCardOnLongPressed;
            _longPressDetector.OnLongPressReleased += HeroCardOnLongPressReleased;
        }
        private void OnDestroy()
        {
            _longPressDetector.OnLongPressed -= HeroCardOnLongPressed;
            _longPressDetector.OnLongPressReleased -= HeroCardOnLongPressReleased;
        }
        
        public void Setup(HeroData heroData)
        {
            _data = heroData;
        }
        
        private void HeroCardOnLongPressed()
        {
            if (!_data.IsUnlocked)
                return;
            
            EventBus<HeroStatsPopupCalledEvent>.Publish(new HeroStatsPopupCalledEvent
                (true, _data, _popupPositionTransform.position,false));
            
            IsLongPressActive = true;
        }
        
        private void HeroCardOnLongPressReleased()
        {
            if (!_data.IsUnlocked)
                return;
            
            EventBus<HeroStatsPopupCalledEvent>.Publish(new HeroStatsPopupCalledEvent
                (false, _data, _popupPositionTransform.position,false));
            IsLongPressActive = false;
        }
    }
}