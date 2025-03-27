using TB_RPG_2D.Enemy.Config;
using UnityEngine;

namespace TB_RPG_2D.Enemy.Data
{
    public class EnemyData
    {
        public int Id => _enemyConfig.Id;
        public string Name => _enemyConfig.Name;
        public float Health => _enemyConfig.BaseHealth; 
        public float AttackPower => _enemyConfig.BaseAttackPower;
        public Sprite Icon => _enemyConfig.Icon;
        
        private readonly EnemyConfig _enemyConfig;

        public EnemyData(EnemyConfig enemyConfig)
        {
            _enemyConfig = enemyConfig;
        }
    }
}