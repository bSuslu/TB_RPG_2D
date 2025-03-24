using TB_RPG_2D.Hero.Resource;
using TB_RPG_2D.Singleton;

namespace TB_RPG_2D.Services
{
    public class ServicesProvider : Singleton<ServicesProvider>
    {
        public HeroResourceService HeroResourceService { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            HeroResourceService = new HeroResourceService();
        }
    }
}