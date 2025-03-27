using TB_RPG_2D.UI.Health;
using UnityEngine;

namespace TB_RPG_2D.Hero.Entity
{
    public class HeroEntity : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        
        
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
    }
}