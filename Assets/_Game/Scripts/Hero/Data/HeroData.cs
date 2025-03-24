using TB_RPG_2D.Hero.Config;
using TB_RPG_2D.Hero.Resource;
using TB_RPG_2D.Settings;

namespace TB_RPG_2D.Hero.Data
{
    public class HeroData
    {
        public int Id => _config.Id;
        public string Name => _config.Name;

        public float Health { get; private set; }
        public float AttackPower { get; private set; }
        
        public int Level { get; private set; }

        private readonly HeroConfig _config;


        public HeroData(HeroConfig config)
        {
            _config = config;
        }

        public HeroData(HeroConfig config, HeroPersistentData heroPersistentData)
        {
            _config = config;

            Level = heroPersistentData.Level;
            CalculateLevelDependentAttributes();
        }

        private void CalculateLevelDependentAttributes()
        {
            Health = _config.BaseHealth + Level * SettingsProvider.Instance.HeroAttributeSettings.LevelBaseHealthMultiplier;
            AttackPower = _config.BaseAttackPower + Level * SettingsProvider.Instance.HeroAttributeSettings.LevelBaseAttackPowerMultiplier;
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