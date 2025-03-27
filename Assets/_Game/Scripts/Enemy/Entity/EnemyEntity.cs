using TB_RPG_2D.Enemy.Data;
using TB_RPG_2D.UI.Health;
using UnityEngine;

namespace TB_RPG_2D.Enemy.Entity
{
    public class EnemyEntity : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void SetData(EnemyData enemyData)
        {
            _spriteRenderer.sprite = enemyData.Icon;
            _healthBar.SetMaxHealth(enemyData.Health);
            _healthBar.SetCurrentHealth(enemyData.Health);
        }
    }
}