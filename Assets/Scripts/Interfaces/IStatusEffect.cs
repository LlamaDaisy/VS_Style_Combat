using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TheSummitCombat
{

    public interface IStatusEffect
    {
        void Apply(EnemyStats enemyStats);
        void Remove(EnemyStats enemyStats);
        float GetDuration();
    }

    public abstract class StatusEffect : IStatusEffect
    {
        protected float duration;

        public StatusEffect(float duration)
        {
            this.duration = duration;
        }

        public abstract void Apply(EnemyStats enemyStats);
        public abstract void Remove(EnemyStats enemyStats);
        public float GetDuration()
        {
            return duration;
        }


    }
}
