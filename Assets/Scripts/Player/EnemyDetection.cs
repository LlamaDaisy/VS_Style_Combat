//Detects the closest enemy to the player and manages player attacks.
using System.Collections.Generic;
using UnityEngine;

namespace TheSummitCombat
{
    public class EnemyDetection : MonoBehaviour
    {
        [SerializeField] AttackStats projectileStats;
        [SerializeField] HealthStats enemyStats;
        [SerializeField] PlayerLvlSystem playerLvlSystem;

        [SerializeField] Transform spawnPos;
        float timer;
        float fireDistance = 10;

        private GameObject FindClosestEnemy()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject closestEnemy = null;
            float shortestDistance = Mathf.Infinity;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }

        void Update()
        {
            GameObject enemyTarget = FindClosestEnemy();

            if (enemyTarget != null)
            {
                float distance = Vector2.Distance(transform.position, enemyTarget.transform.position);

                if (distance < fireDistance)
                {
                    timer += Time.deltaTime;

                    if (timer > projectileStats.attackFireRate)
                    {
                        ProjectileAttack(enemyTarget);
                        timer = 0f;
                    }
                }
            }

        }

        void ProjectileAttack(GameObject enemyTarget)
        {
            GameObject projectileAttack = PlayerObjectPool.SharedInstance.GetPooledObject();

            if (projectileAttack != null)
            {
                projectileAttack.transform.position = spawnPos.transform.position;
                projectileAttack.SetActive(true);

                Vector2 direction = (enemyTarget.transform.position - spawnPos.position).normalized;

                Rigidbody2D rb = projectileAttack.GetComponent<Rigidbody2D>();
                PlayerProjectileAttack projectileScript = projectileAttack.GetComponent<PlayerProjectileAttack>();

                var activeAugments = playerLvlSystem.GetActiveAugments();
                projectileScript.activeAugments = new List<ISpellAugment>(activeAugments);

                if (rb != null)
                {
                    rb.velocity = direction * projectileStats.attackSpeed;
                }

                StartCoroutine(projectileScript.AttackLifetime());
            }
        }


    }
}
