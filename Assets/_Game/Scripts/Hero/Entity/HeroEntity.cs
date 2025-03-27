using TB_RPG_2D.Hero.Data;
using TB_RPG_2D.UI.Health;
using UnityEngine;

namespace TB_RPG_2D.Hero.Entity
{
    public class HeroEntity : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void SetData(HeroData heroData)
        {
            _spriteRenderer.sprite = heroData.Icon;
            _healthBar.SetMaxHealth(heroData.Health);
            _healthBar.SetCurrentHealth(heroData.Health);
        }
    }
}