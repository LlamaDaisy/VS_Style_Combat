//FIRE - Burn effect that DOT.
using System.Collections;
using UnityEngine;
namespace TheSummitCombat
{
    public class BurnEffect : StatusEffect
    {
        private float dps;
        private bool isBurning;
        private Coroutine burnCoroutine;

        public BurnEffect(float duration, float dps) : base(duration)
        {
            this.dps = dps;
            isBurning = false;
        }
        public override void Apply(EnemyStats enemyStats)
        {
            if (!isBurning)
            {
                isBurning = true;
                burnCoroutine = enemyStats.StartCoroutine(ApplyBurn(enemyStats));
            }
        }

        private IEnumerator ApplyBurn(EnemyStats enemyStats)
        {
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += 1f;
                enemyStats.Damage(dps);
                yield return new WaitForSeconds(1f);
            }

            isBurning = false;
        }

        public override void Remove(EnemyStats enemyStats)
        {
            if (burnCoroutine != null)
            {
                enemyStats.StopCoroutine(burnCoroutine);
            }
            isBurning = false;
        }
    }
}