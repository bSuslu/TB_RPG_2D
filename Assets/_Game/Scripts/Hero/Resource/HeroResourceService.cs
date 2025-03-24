using System.Collections.Generic;

namespace TB_RPG_2D.Hero.Resource
{
    public class HeroResourceService
    {
        public List<HeroPersistentData> PersistentDatas { get; set; }

        public HeroResourceService()
        {
            PersistentDatas = GetHeroes();
        }

        private List<HeroPersistentData> GetHeroes()
        {
            return new List<HeroPersistentData>
            {
                new HeroPersistentData()
                {
                    Id = 0,
                    Level = 10,
                },
                new HeroPersistentData()
                {
                    Id = 1,
                    Level = 20,
                },
                new HeroPersistentData()
                {
                    Id = 2,
                    Level = 30,
                }
            };
        }
    }
}