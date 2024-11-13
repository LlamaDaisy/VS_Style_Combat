using UnityEngine;
using UnityEngine.InputSystem;
namespace TheSummitCombat
{
    public class Combat : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Vector2 movementVector;

        [SerializeField] private HealthStats playerStats;

        private MovementControls inputMap;
        [HideInInspector] public bool isMoving = false;

        private void Awake()
        {
            inputMap = new MovementControls();
        }

        private void OnEnable()
        {
            inputMap.Combat.Movement.performed += Movement;
            inputMap.Combat.Movement.canceled += Movement;
            inputMap.Combat.Dash.performed += Dash;

            inputMap.Combat.Enable();
        }

        private void OnDisable()
        {
            inputMap.Combat.Movement.performed -= Movement;
            inputMap.Combat.Movement.canceled -= Movement;
            inputMap.Combat.Dash.performed -= Dash;

            inputMap.Combat.Disable();
        }

        private void Movement(InputAction.CallbackContext context)
        {
            movementVector = context.ReadValue<Vector2>();
            rb.velocity = playerStats.movementSpeed * movementVector;
            isMoving = true;

            if (movementVector == Vector2.zero)
            {
                isMoving = false;
            }

        }

        private void Dash(InputAction.CallbackContext context)
        {
            if (movementVector == Vector2.zero)
            {
                return;
            }

            Vector3 distanceVector = movementVector * 2;
            Vector3 newPosition = transform.position + distanceVector;
            transform.position = newPosition;
        }

    }
}
