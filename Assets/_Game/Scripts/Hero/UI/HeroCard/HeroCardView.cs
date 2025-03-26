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
        [SerializeField] private GameObject _selectedIndicator;
        
        public Action OnClick { get; set; }
        
        public void SetModel(HeroCardModel model)
        {
            _nameText.text = model.Name;
            _iconImage.sprite = model.Icon;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }

        public void Deselect()
        {
            _selectedIndicator.SetActive(false);
        }

        public void Select()
        {
            _selectedIndicator.SetActive(true);
        }
    }
}