using UnityEngine;
namespace TheSummitCombat
{
    public class XPDrop : MonoBehaviour
    {
        [SerializeField] HealthStats playerStats;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerStats.currentXP += 25;
                Destroy(gameObject);
            }
        }
    }
}
