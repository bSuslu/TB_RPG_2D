using TB_RPG_2D.Settings;
using TMPro;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI
{
    public class TargetHeroCardSelectionPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textValue;


        private void Awake()
        {
            _textValue.text = SettingsProvider.Instance.HeroSelectionSettings.RequiredHeroCountForBattle.ToString();
        }
    }
}
