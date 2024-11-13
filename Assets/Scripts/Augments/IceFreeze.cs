using UnityEngine;
namespace TheSummitCombat
{
    public class IceFreeze : ISpellAugment
    {
        float freezeDuration;

        public IceFreeze(float duration)
        {
            freezeDuration = duration;
        }
        public void ApplyAugment(AttackStats spellStats)
        {
            ModifyStats(spellStats);
        }
        public void ModifyStats(AttackStats spellStats)
        {
            spellStats.currentSlowDuration += freezeDuration;
        }
        public void OnHit(EnemyStats enemyStats)
        {
            if (enemyStats != null)
            {
                Debug.Log("FREEZE");
                enemyStats.ApplyStatusEffect(new FreezeEffect(freezeDuration));
            }
        }

        public string GetName()
        {
            return "Freeze";
        }

        public string GetDescription()
        {
            return "Freezes enemies on hit";
        }

        public string GetFlavourText()
        {
            return "Ice, Ice Baby";
        }

        public string GetStats(AttackStats spellStats)
        {
            return $"Freezes enemies for: {freezeDuration}";
        }

    }
}
