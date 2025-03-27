using TB_RPG_2D.Hero.Data;
using UnityEngine;

namespace TB_RPG_2D.Hero.Entity
{
    public class HeroEntity : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void SetData(HeroData heroData)
        {
            _spriteRenderer.sprite = heroData.Icon;
        }
    }
}