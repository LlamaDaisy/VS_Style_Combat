using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TheSummitCombat
{
    public class EnemyStats : MonoBehaviour, IDamageable
    {
        [SerializeField] HealthStats baseEnemyStats;
        [SerializeField] AttackStats baseEnemyAttackStats;
        public HealthStats instanceEnemyStats;
        public AttackStats instanceEnemyAttackStats;
        [SerializeField] GameObject xpDrop;
        [SerializeField] Slider healthSlider;
        private float orginalSpeed;

        List<IStatusEffect> activeStatusEffects = new List<IStatusEffect>();
        List<ISpellAugment> activeAugments = new List<ISpellAugment>();

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
        }

        public void Awake()
        {
            instanceEnemyStats = Instantiate(baseEnemyStats);
        }
        void Start()
        {
            instanceEnemyStats.currentHealth = instanceEnemyStats.maxHealth;
            orginalSpeed = instanceEnemyStats.movementSpeed;
            UpdateStats();
        }

        void Update()
        {
            UpdateStats();

            if (instanceEnemyStats.currentHealth <= 0)
            {
                EnemyDeath();
            }
        }

        void UpdateStats()
        {
            healthSlider.value = instanceEnemyStats.currentHealth / instanceEnemyStats.maxHealth;
        }

        public void Damage(float damage)
        {
            instanceEnemyStats.currentHealth -= damage;
        }

        void EnemyDeath()
        {
            Instantiate(xpDrop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        public void ApplyStatusEffect(IStatusEffect effect)
        {
            if (!activeStatusEffects.Contains(effect))
            {
                activeStatusEffects.Add(effect);
                effect.Apply(this);
                StartCoroutine(RemoveEffect(effect));
            }

            /*        activeStatusEffects.Add(effect);
                    effect.Apply(this);
                    StartCoroutine(RemoveEffect(effect));*/
            //Debug.Log("current movespeed " + instanceEnemyStats.movementSpeed);
        }

        public void ApplyAugment(ISpellAugment augment)
        {
            if (!activeAugments.Contains(augment))
            {
                activeAugments.Add(augment);
                augment.ApplyAugment(instanceEnemyAttackStats);
            }
        }

        public void ResetStats()
        {
            instanceEnemyAttackStats.ResetStatsToBase();
            foreach (var augment in activeAugments)
            {
                augment.ModifyStats(instanceEnemyAttackStats);
            }
        }

        private IEnumerator RemoveEffect(IStatusEffect effect)
        {
            yield return new WaitForSeconds(effect.GetDuration());
            effect.Remove(this);
            activeStatusEffects.Remove(effect);
        }

        public void AdjustMoveSpeed(float newSpeed)
        {
            instanceEnemyStats.movementSpeed = newSpeed;
        }

        public void ResetMoveSpeed()
        {
            instanceEnemyStats.movementSpeed = orginalSpeed;
        }
    }
}
