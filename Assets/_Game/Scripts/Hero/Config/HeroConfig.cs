using UnityEngine;

namespace TB_RPG_2D.Hero.Config
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Config/Hero")]
    public class HeroConfig : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public float BaseHealth { get; private set; }
        [field: SerializeField] public float BaseAttackPower { get; private set; }


        public override string ToString()
        {
            return $"{Name} (ID: {Id} Health: {BaseHealth} Attack: {BaseAttackPower})";
        }
    }
}