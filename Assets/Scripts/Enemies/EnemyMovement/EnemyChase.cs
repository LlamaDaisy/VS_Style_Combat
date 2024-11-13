using UnityEngine;
namespace TheSummitCombat
{
    public class EnemyChase : MonoBehaviour, IDamageable
    {
        GameObject player;
        [SerializeField] float chaseDistance;

        [SerializeField] HealthStats enemyStats;
        private HealthStats instanceEnemyStats;

        [SerializeField] HealthStats playerStats;

        Rigidbody2D rb;

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            instanceEnemyStats = GetComponent<EnemyStats>().instanceEnemyStats;

            rb = GetComponent<Rigidbody2D>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void FixedUpdate()
        {
            ChasePlayer();
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Damage(10);
            }
        }

        public void Damage(float damage)
        {
            playerStats.currentHealth -= damage;
        }
    }
}
