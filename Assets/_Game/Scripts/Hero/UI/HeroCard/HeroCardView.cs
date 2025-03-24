using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TB_RPG_2D.Hero.UI.HeroCard
{
    public class HeroCardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Image _iconImage;
        
        public void SetModel(HeroCardModel model)
        {
            _nameText.text = model.Name;
            _iconImage.sprite = model.Icon;
        }
    }
}