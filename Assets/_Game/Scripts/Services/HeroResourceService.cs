using System.Collections.Generic;
using TB_RPG_2D.Hero.PersistentData;

namespace TB_RPG_2D.Services
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
                    Experience = 0,
                    Level = 10,
                },
                new HeroPersistentData()
                {
                    Id = 1,
                    Experience = 1,
                    Level = 20,
                },
                new HeroPersistentData()
                {
                    Id = 2,
                    Experience = 2,
                    Level = 30,
                }
            };
        }
    }
}