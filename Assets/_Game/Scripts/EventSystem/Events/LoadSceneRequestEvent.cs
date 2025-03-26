using TB_RPG_2D.Scene;

namespace TB_RPG_2D.EventSystem.Events
{
    public class LoadSceneRequestEvent : IEvent
    {
        public GameScene Scene { get; set; }
        
        public LoadSceneRequestEvent(GameScene scene)
        {
            Scene = scene;
        }
    }
}