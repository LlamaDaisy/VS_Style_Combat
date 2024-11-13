//ICE - Freeze effect that "freezes" enemy for a few secs.
namespace TheSummitCombat
{
    public class FreezeEffect : StatusEffect
    {
        bool isFrozen;

        public FreezeEffect(float duration) : base(duration)
        {
            isFrozen = false;
        }
        public override void Apply(EnemyStats enemyStats)
        {
            if (!isFrozen)
            {
                enemyStats.AdjustMoveSpeed(0f);
                isFrozen = true;
            }
        }

        public override void Remove(EnemyStats enemyStats)
        {
            enemyStats.ResetMoveSpeed();
            isFrozen = false;
        }
    }
}
