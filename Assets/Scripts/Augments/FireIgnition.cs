//an augment that sets enemies on fire, dealing DOT
using UnityEngine;
namespace TheSummitCombat
{
    public class FireIgnition : ISpellAugment
    {
        private float damagePerSec;
        private float duration;

        public FireIgnition(float dps, float dur)
        {
            damagePerSec = dps;
            duration = dur;
        }
        public void ApplyAugment(AttackStats spellStats)
        {
            ModifyStats(spellStats);
        }
        public void ModifyStats(AttackStats spellStats)
        {
            spellStats.currentDotDamage += damagePerSec;
            spellStats.currentDotDuration += duration;
        }
        public void OnHit(EnemyStats enemyStats)
        {
            if (enemyStats != null)
            {
                Debug.Log("BURN");
                enemyStats.ApplyStatusEffect(new BurnEffect(duration, damagePerSec));
            }
        }

        public string GetName()
        {
            return "Ignition";
        }

        public string GetDescription()
        {
            return "Deals fire damage over time";
        }

        public string GetFlavourText()
        {
            return "Burn baby burn";
        }

        public string GetStats(AttackStats spellStats)
        {
            return $"Deal {damagePerSec} for {duration} seconds";
        }
    }
}
