namespace TB_RPG_2D.Hero.UI.HeroCard
{
    public class HeroCardController
    {
        private HeroCardView _heroCardView;
        private HeroCardModel _heroCardModel;
        
        public HeroCardController(HeroCardView heroCardView, HeroCardModel heroCardModel)
        {
            _heroCardView = heroCardView;
            _heroCardModel = heroCardModel;
        }
    }
}