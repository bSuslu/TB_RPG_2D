using TB_RPG_2D.Singleton;

namespace TB_RPG_2D.Services
{
    public class ServicesProvider : MonoSingleton<ServicesProvider>
    {
        public HeroResourceService HeroResourceService { get; private set; }
        public HeroSelectionService HeroSelectionService { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            HeroResourceService = new HeroResourceService();
            HeroSelectionService = new HeroSelectionService();
        }
    }
}