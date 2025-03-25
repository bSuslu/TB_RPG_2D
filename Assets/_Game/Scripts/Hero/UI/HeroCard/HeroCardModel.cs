using TB_RPG_2D.Hero.Data;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI.HeroCard
{
    public class HeroCardModel
    {
        public int Id => _heroData.Id;
        public string Name => _heroData.Name;
        public Sprite Icon => _heroData.Icon;
        public bool IsUnlocked => _heroData.IsUnlocked;
        
        private readonly HeroData _heroData;
        
        public HeroCardModel(HeroData heroData)
        {
            _heroData = heroData;
        }
    }
}