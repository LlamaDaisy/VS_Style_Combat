using System.Collections;
using UnityEngine;
namespace TheSummitCombat
{
    public class DealDamage : MonoBehaviour, IDamageable
    {
        [SerializeField] HealthStats playerStats;
        [SerializeField] AttackStats enemyAttack;

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                //Debug.Log("Hit Player");
                Damage(5);
                StopAllCoroutines();
                gameObject.SetActive(false);
            }

            if (collision.CompareTag("PlayerAttack"))
            {
                StopAllCoroutines();
                gameObject.SetActive(false);
            }
        }

        public void Damage(float damage)
        {
            playerStats.currentHealth -= damage;
        }

        public IEnumerator AttackLifetime()
        {
            yield return new WaitForSeconds(enemyAttack.attackLifetime);
            gameObject.SetActive(false);
        }
    }
}
