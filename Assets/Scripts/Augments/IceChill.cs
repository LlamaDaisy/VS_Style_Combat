using UnityEngine;
namespace TheSummitCombat
{
    public class IceChill : ISpellAugment
    {
        float slowAmount;
        float slowDuration;

        public IceChill(float slow, float duration)
        {
            slowAmount = slow;
            slowDuration = duration;
        }
        public void ApplyAugment(AttackStats spellStats)
        {
            ModifyStats(spellStats);
        }
        public void ModifyStats(AttackStats spellStats)
        {
            spellStats.currentSlowEffect += slowAmount;
            spellStats.currentSlowDuration += slowDuration;
        }
        public void OnHit(EnemyStats enemyStats)
        {
            if (enemyStats != null)
            {
                Debug.Log("CHILLED");
                enemyStats.ApplyStatusEffect(new ChillEffect(slowDuration, slowAmount));
            }
        }
        public string GetName()
        {
            return "Chill";
        }

        public string GetDescription()
        {
            return "Slows enemies on hit";
        }

        public string GetFlavourText()
        {
            return "Chill baby chill";
        }

        public string GetStats(AttackStats spellStats)
        {
            return $"Slows enemies by: {slowAmount}";
        }
    }
}
