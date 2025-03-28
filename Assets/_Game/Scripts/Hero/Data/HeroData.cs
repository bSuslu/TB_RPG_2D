using TB_RPG_2D.Hero.Attribute;
using TB_RPG_2D.Hero.Config;
using TB_RPG_2D.Hero.PersistentData;
using TB_RPG_2D.Settings;
using UnityEngine;

namespace TB_RPG_2D.Hero.Data
{
    public class HeroData
    {
        public int Id => _config.Id;
        public string Name => _config.Name;
        public Sprite Icon => _config.Icon;

        public float Health { get; private set; }
        public float AttackPower { get; private set; }
        
        public int Experience { get; private set; }
        public int Level { get; private set; }
        public bool IsUnlocked => Level > 0;

        private readonly HeroConfig _config;
        
        // TODO: inject and update methods
        private readonly HeroAttributeCalculator _attributeCalculator;

        public HeroData(HeroConfig config, bool isUnlocked = false)
        {
            _config = config;
            _attributeCalculator = new HeroAttributeCalculator(_config);
            Experience = 0;
            Level = isUnlocked ? 1 : 0;
        }

        public HeroData(HeroConfig config, HeroPersistentData heroPersistentData)
        {
            _config = config;
            _attributeCalculator = new HeroAttributeCalculator(_config);
            Experience = heroPersistentData.Experience;
            Level = heroPersistentData.Level;
            CalculateLevelDependentAttributes();
        }

        private void CalculateLevelDependentAttributes()
        {
            Health = _attributeCalculator.CalculateHealth(Level);
            AttackPower = _attributeCalculator.CalculateAttackPower(Level);
        }

        public override string ToString()
        {
            if (Level == 0)
            {
                return $"{Name} (ID: {Id})";
            }
            
            return $"{Name} (ID: {Id} Level: {Level} Health: {Health} Attack: {AttackPower})";
        }
    }
}