using TB_RPG_2D.Hero.Data;
using TMPro;
using UnityEngine;

namespace TB_RPG_2D.Hero.UI
{
    public class HeroAttributePopup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _heroNameStatText;
        [SerializeField] private TextMeshProUGUI _heroHealthStatText;
        [SerializeField] private TextMeshProUGUI _heroAttackPowerStatText;
        [SerializeField] private TextMeshProUGUI _heroExperienceStatText;
        [SerializeField] private TextMeshProUGUI _heroLevelStatText;
        

        private void SetTexts(HeroData heroData)
        {
            _heroNameStatText.text = "Name: " + heroData.Name;
            _heroHealthStatText.text = "Health: " + heroData.Health;
            _heroAttackPowerStatText.text = "Attack Power: " + heroData.AttackPower;
            _heroExperienceStatText.text = "Experience: " + heroData.Experience;
            _heroLevelStatText.text = "Level: " + heroData.Level;
        }
    }
}