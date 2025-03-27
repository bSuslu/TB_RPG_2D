using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TB_RPG_2D.UI.Health
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _healthText;

        private float _maxHealth;
        
        public void SetMaxHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
        }
        
        public void SetCurrentHealth(float health)
        {
            _slider.value = health / _maxHealth;
            _healthText.text = $"{health:0.0} / {_maxHealth:0.0}";
        }
    }
}