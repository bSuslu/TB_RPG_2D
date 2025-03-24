using TB_RPG_2D.Hero.Config;

namespace TB_RPG_2D.Hero.Data
{
    public class HeroData
    {
        public int Id => _config.Id;
        public string Name => _config.Name;
        
        public int Health { get; private set; }
        public int Attack { get; private set; }
        public int Level { get; private set; }

        private readonly HeroConfig _config;
        
        public HeroData(HeroConfig config)
        {
            _config = config;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {Id})";
        }
    }
}