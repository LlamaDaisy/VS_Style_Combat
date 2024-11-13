//Manages the player attack, and applies selected augment on hit with enemy.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TheSummitCombat
{
    public class PlayerProjectileAttack : MonoBehaviour
    {
        [SerializeField] AttackStats playerProjectileAttack;
        public List<ISpellAugment> activeAugments = new List<ISpellAugment>();
        public ISpellAugment augment;

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag("Enemy"))
            {
                EnemyStats enemy = collision.GetComponent<EnemyStats>();

                if (enemy != null)
                {
                    enemy.Damage(playerProjectileAttack.attackDamage);
                    Debug.Log("Active Augments " + activeAugments.Count);

                    foreach (var augment in activeAugments)
                    {
                        if (augment == null)
                        {
                            Debug.LogWarning("found null augment in activeAugments!");
                        }

                        else
                        {
                            Debug.Log("Applying Augment: " + augment.GetName());
                            augment.OnHit(enemy);
                        }
                    }

                }

                StopAllCoroutines();
                gameObject.SetActive(false);
            }

            if (collision.CompareTag("EnemyAttack"))
            {
                StopAllCoroutines();
                gameObject.SetActive(false);
            }
        }

        public void AddAugment(ISpellAugment augment)
        {
            if (!activeAugments.Contains(augment))
            {
                activeAugments.Add(augment);
                augment.ApplyAugment(playerProjectileAttack);
                Debug.Log("Added Augment: " + augment.GetName());
            }
        }

        public IEnumerator AttackLifetime()
        {
            yield return new WaitForSeconds(playerProjectileAttack.attackLifetime);
            gameObject.SetActive(false);
        }
    }
}
