using TB_RPG_2D.Hero.Config;
using UnityEngine;

namespace TB_RPG_2D.Test
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private HeroConfig[] _heroes;


        private void Awake()
        {
            foreach (var hero in _heroes)
            {
                Debug.Log(hero.ToString());
            }
        }
    }
}
