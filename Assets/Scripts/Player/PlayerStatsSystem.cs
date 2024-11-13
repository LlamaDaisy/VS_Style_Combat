using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace TheSummitCombat
{
    public class PlayerStatsSystem : MonoBehaviour
    {
        [SerializeField] HealthStats playerStats;
        [SerializeField] TMP_Text playerHealth;
        [SerializeField] TMP_Text currentXP;
        [SerializeField] Slider XPSlider;

        // Start is called before the first frame update
        void Start()
        {
            UpdateUI();
            playerStats.currentHealth = playerStats.maxHealth;
            playerStats.currentXP = 0;
        }


        // Update is called once per frame
        void Update()
        {
            UpdateUI();
            PlayerDeath();
        }

        void UpdateUI()
        {
            playerHealth.text = playerStats.currentHealth.ToString();
            //currentXP.text = playerStats.currentXP.ToString();
            XPSlider.value = playerStats.currentXP / playerStats.maxXP;
        }

        void PlayerDeath()
        {
            if (playerStats.currentHealth <= 0)
            {
                Debug.Log("Player Dead");
            }
        }
    }
}