//SO that hold attack stats for both enemy and player attacks, manages the application of augments to attacks.
using UnityEngine;
namespace TheSummitCombat
{

    [CreateAssetMenu(menuName = "Attack Stats")]
    public class AttackStats : ScriptableObject
    {
        [Header("Base Stats")]
        [SerializeField] public float attackDamage;
        [SerializeField] public float attackFireRate;
        [SerializeField] public float attackSpeed;
        [SerializeField] public float attackRange;
        [SerializeField] public float attackLifetime;

        [Header("Ice Effects")]
        [SerializeField] public float slowEffect;
        [SerializeField] public float slowDuration;

        [HideInInspector]
        [SerializeField] public float currentSlowEffect;
        [HideInInspector]
        [SerializeField] public float currentSlowDuration;

        [Header("Fire Effects")]
        [SerializeField] public float dotDamage;
        [SerializeField] public float dotDuration;

        [HideInInspector]
        [SerializeField] public float currentDotDamage;
        [HideInInspector]
        [SerializeField] public float currentDotDuration;

        [Header("Shock Effects")]
        [SerializeField] public float bonusDamage;
        [SerializeField] public float bonusDamageDuration;

        [HideInInspector]
        [SerializeField] public float currentBonusDamage;
        [HideInInspector]
        [SerializeField] public float currentBonusDgDuration;

        private void OnEnable()
        {
            ResetStatsToBase();
        }

        public void ResetStatsToBase()
        {
            currentSlowEffect = slowEffect;
            currentSlowDuration = slowDuration;

            currentDotDamage = dotDamage;
            currentDotDuration = dotDuration;

            currentBonusDamage = bonusDamage;
            currentBonusDgDuration = bonusDamageDuration;
        }

        public void ApplyAugment(ISpellAugment augment)
        {
            augment.ModifyStats(this);
        }
    }
}
