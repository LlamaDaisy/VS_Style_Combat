//ICE - chill effect that slows enemy movement
namespace TheSummitCombat
{
    public class ChillEffect : StatusEffect
    {
        private float slowAmount;
        private bool isSlowed;
        public ChillEffect(float duration, float slowAmount) : base(duration)
        {
            this.slowAmount = slowAmount;
            isSlowed = false;
        }
        public override void Apply(EnemyStats enemyStats)
        {
            if (!isSlowed)
            {
                enemyStats.AdjustMoveSpeed(enemyStats.instanceEnemyStats.movementSpeed - slowAmount);
                isSlowed = true;
            }
        }

        public override void Remove(EnemyStats enemyStats)
        {
            enemyStats.ResetMoveSpeed();
            isSlowed = false;
        }
    }
}
