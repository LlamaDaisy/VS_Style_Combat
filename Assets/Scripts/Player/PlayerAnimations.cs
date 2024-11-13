using UnityEngine;
namespace TheSummitCombat
{

    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] Combat playerMovement;
        [SerializeField] Animator animator;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (playerMovement.isMoving)
            {
                animator.SetBool("isWalking", true);
            }

            else
            {
                animator.SetBool("isWalking", false);
            }
        }
    }
}