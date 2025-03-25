using TB_RPG_2D.EventSystem;
using TB_RPG_2D.EventSystem.Events;
using TB_RPG_2D.Hero.Data;
using TB_RPG_2D.UI.Core;
using TB_RPG_2D.UI.Helper;
using TMPro;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI
{
    // TODO: Instantiate in scene by SceneService base or ScenePool base
    public class HeroStatsPopup : UIEntity
    {
        // TODO: make generic string stats
        [SerializeField] private TextMeshProUGUI _heroNameStatText;
        [SerializeField] private TextMeshProUGUI _heroHealthStatText;
        [SerializeField] private TextMeshProUGUI _heroAttackPowerStatText;
        [SerializeField] private TextMeshProUGUI _heroExperienceStatText;
        [SerializeField] private TextMeshProUGUI _heroLevelStatText;

        private EventBinding<HeroStatsPopupCalledEvent> _heroStatsPopupCalledEventBinding;

        public override void Init( )
        {
            base.Init();
            _heroStatsPopupCalledEventBinding = new EventBinding<HeroStatsPopupCalledEvent>(OnHeroStatsPopupCalled);
            EventBus<HeroStatsPopupCalledEvent>.Subscribe(_heroStatsPopupCalledEventBinding);
        }

        private void OnHeroStatsPopupCalled(HeroStatsPopupCalledEvent heroStatsPopupCalledEvent)
        {
            if (heroStatsPopupCalledEvent.Activate)
            {
                Activate(heroStatsPopupCalledEvent.HeroData, heroStatsPopupCalledEvent.Position,
                    heroStatsPopupCalledEvent.IsCalledFromWorldSpace);
            }
            else
            {
                Deactivate();
            }
        }

        private void Activate(HeroData heroData, Vector3 popupPosition, bool isWorldToScreenPoint)
        {
            SetTexts(heroData);
            SetPosition(popupPosition, isWorldToScreenPoint);
            gameObject.SetActive(true);
        }

        private void SetPosition(Vector3 popupPosition, bool isWorldToScreenPoint)
        {
            if (isWorldToScreenPoint)
            {
                transform.localPosition = UIHelper.WorldToUILocalPosition(popupPosition, _uiEntityManager.Canvas, _uiEntityManager.Camera);
            }
            else
            {
                transform.position = popupPosition;
            }
        }

        private void SetTexts(HeroData heroData)
        {
            _heroNameStatText.text = "Name: " + heroData.Name;
            _heroHealthStatText.text = "Health: " + heroData.Health;
            _heroAttackPowerStatText.text = "Attack Power: " + heroData.AttackPower;
            _heroExperienceStatText.text = "Experience: " + heroData.Experience;
            _heroLevelStatText.text = "Level: " + heroData.Level;
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }
        
        public override void Dispose()
        {
            EventBus<HeroStatsPopupCalledEvent>.Unsubscribe(_heroStatsPopupCalledEventBinding);
        }
    }
}