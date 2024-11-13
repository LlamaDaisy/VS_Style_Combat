using System.Collections;
using UnityEngine;
namespace TheSummitCombat
{
    public class TestEnemyProjectile : MonoBehaviour
    {
        [SerializeField] AttackStats enemyAttack;
        [SerializeField] HealthStats playerStats;

        [SerializeField] Transform spawnPos;
        float timer;
        float fireDistance = 10;
        GameObject playerTarget;

        void Start()
        {
            playerTarget = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            float distance = Vector2.Distance(transform.position, playerTarget.transform.position);

            if (distance < fireDistance)
            {
                timer += Time.deltaTime;

                if (timer > enemyAttack.attackFireRate)
                {
                    AttackProjectile();
                    timer = 0;
                }
            }
        }


        void AttackProjectile()
        {
            GameObject projectileAttack = EnemyProjectileObjectPool.SharedInstance.GetPooledObject();

            if (projectileAttack != null)
            {
                projectileAttack.transform.position = spawnPos.transform.position;
                projectileAttack.SetActive(true);

                Vector2 direction = (playerTarget.transform.position - spawnPos.position).normalized;

                Rigidbody2D rb = projectileAttack.GetComponent<Rigidbody2D>();
                DealDamage attack = projectileAttack.GetComponent<DealDamage>();

                if (rb != null)
                {
                    rb.velocity = direction * enemyAttack.attackSpeed;
                }

                StartCoroutine(attack.AttackLifetime());

            }
        }
    }
}
