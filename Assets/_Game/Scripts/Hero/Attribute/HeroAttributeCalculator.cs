using TB_RPG_2D.Hero.Config;
using TB_RPG_2D.Settings;
using UnityEngine;

namespace TB_RPG_2D.Hero.Attribute
{
    public class HeroAttributeCalculator
    {
        private readonly HeroConfig _config;
        private readonly HeroAttributeSettings _settings;

        public HeroAttributeCalculator(HeroConfig config)
        {
            _config = config;
            _settings = SettingsProvider.Instance.HeroAttributeSettings;
        }

        public float CalculateHealth(int level)
        {
            return _config.BaseHealth * Mathf.Pow(1 + _settings.LevelHealthGrowthRate, level - 1);
        }

        public float CalculateAttackPower(int level)
        {
            return _config.BaseAttackPower * Mathf.Pow(1 + _settings.LevelAttackPowerGrowthRate, level - 1);
        }
    }
}