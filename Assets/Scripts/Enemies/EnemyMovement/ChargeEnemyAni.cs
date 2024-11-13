using UnityEngine;
namespace TheSummitCombat
{
    public class ChargeEnemyAni : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] EnemyChargeAttack chargeAttack;

        void Update()
        {
            if (chargeAttack.isChargeReady)
            {
                animator.SetBool("startCharging", true);
            }

            else
            {
                animator.SetBool("startCharging", false);
            }
        }
    }
}
