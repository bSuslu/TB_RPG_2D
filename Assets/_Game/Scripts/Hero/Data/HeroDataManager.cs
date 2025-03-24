using TB_RPG_2D.Hero.Config;
using UnityEngine;

namespace TB_RPG_2D.Hero.Data
{
    public class HeroDataManager : MonoBehaviour
    {
        [SerializeField] private HeroConfig[] _configs;
        
        private HeroData[] _heroes;
        
        private void Start()
        {
            _heroes = new HeroData[_configs.Length];
            for (int i = 0; i < _configs.Length; i++)
            {
                _heroes[i] = new HeroData(_configs[i]);
                Debug.Log(_heroes[i].ToString());
            }
        }
    }
}