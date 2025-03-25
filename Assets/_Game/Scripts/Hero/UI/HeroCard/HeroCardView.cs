using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TB_RPG_2D.Hero.UI.HeroCard
{
    public class HeroCardView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Image _iconImage;
        
        public Action OnClick { get; set; }
        
        public void SetModel(HeroCardModel model)
        {
            _nameText.text = model.Name;
            _iconImage.sprite = model.Icon;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"clicked on {_nameText.text} from view");
            OnClick?.Invoke();
        }
    }
}