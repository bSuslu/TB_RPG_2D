using UnityEngine;

namespace TB_RPG_2D.Enemy.Config
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public float BaseHealth { get; private set; }
        [field: SerializeField] public float BaseAttackPower { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}