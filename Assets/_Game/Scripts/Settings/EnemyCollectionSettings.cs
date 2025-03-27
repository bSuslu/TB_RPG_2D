using TB_RPG_2D.Enemy.Config;
using UnityEngine;

namespace TB_RPG_2D.Settings
{
    [CreateAssetMenu(fileName = "EnemyCollectionSettings", menuName = "Settings/EnemyCollection")]
    public class EnemyCollectionSettings : ScriptableObject
    {
        [field: SerializeField] public EnemyConfig[] Configs { get; private set; }
        [field: SerializeField] public int EnemyAmountInBattle { get; private set; }

        
    }
}