using UnityEngine;
namespace TheSummitCombat
{
    public class EnemyChargeAttack : MonoBehaviour, IDamageable
    {
        GameObject player;
        [SerializeField] HealthStats playerStats;
        [SerializeField] HealthStats baseEnemyStats;
        private HealthStats instanceEnemyStats;
        Rigidbody2D rb;

        [Header("Chase Player")]
        float chaseDistance = 25f;

        [Header("Charge Attack")]
        float chargeSpeed = 15f;
        float chargeCooldown = 5f;
        float chargeDuration = 0.5f;
        float chargeUpTime = 1f;

        bool isCharging = false;
        public bool isChargeReady = false;
        float cooldownTimer = 0f;

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
        }

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            player = GameObject.FindGameObjectWithTag("Player");

            instanceEnemyStats = GetComponent<EnemyStats>().instanceEnemyStats;
        }

        void Update()
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (!isCharging && !isChargeReady)
            {
                cooldownTimer += Time.deltaTime;

                if (cooldownTimer >= chargeCooldown && distance < chaseDistance)
                {
                    StartChargeUp();
                    cooldownTimer = 0f;
                }
                else
                {
                    ChasePlayer();
                }
            }

        }

        void ChasePlayer()
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < chaseDistance)
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;
                rb.velocity = direction * instanceEnemyStats.movementSpeed;
            }

            else
            {
                rb.velocity = Vector2.zero;
            }

        }

        void StartChargeUp()
        {
            isChargeReady = true;
            rb.velocity = Vector2.zero;

            Invoke("ChargeAttack", chargeUpTime);
        }

        void ChargeAttack()
        {
            isChargeReady = false;
            isCharging = true;

            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * chargeSpeed;

            Invoke("StopCharge", chargeDuration);
        }

        void StopCharge()
        {
            rb.velocity = Vector2.zero;
            isCharging = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Damage(15);
            }
        }
        public void Damage(float damage)
        {
            playerStats.currentHealth -= damage;
        }
    }
}