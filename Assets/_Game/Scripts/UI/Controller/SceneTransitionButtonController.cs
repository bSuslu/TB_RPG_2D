using TB_RPG_2D.EventSystem;
using TB_RPG_2D.EventSystem.Events;
using TB_RPG_2D.Scene;
using UnityEngine;
using UnityEngine.UI;

namespace TB_RPG_2D.UI.Controller
{
    public class SceneTransitionButton : MonoBehaviour
    {
        [SerializeField] private GameScene _scene;
        [SerializeField] private Button _button;
        
        protected void Awake()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        protected void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void OnButtonClicked()
        {
            EventBus<LoadSceneRequestEvent>.Publish(new LoadSceneRequestEvent(_scene));
        }
    }
}