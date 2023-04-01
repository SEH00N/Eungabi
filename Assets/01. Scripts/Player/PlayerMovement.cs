using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] float gravityScale = 1;

    private CharacterController charController = null;
    private PlayerAnimator playerAnimator = null;
    private Vector3 movementVelocity = Vector3.zero;
    public Vector3 MovementVelocity => movementVelocity;

    private float gravity = -9.81f;
    private float verticalVelocity = 0f;

    public bool IsActiveMove { get; set; }

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerAnimator = transform.Find("Model").GetComponent<PlayerAnimator>();
        IsActiveMove = true;
    }

    private void FixedUpdate()
    {
        if (IsActiveMove)
            CalculateSpeed();

        if (charController.isGrounded == false)
            verticalVelocity = gravity * gravityScale * Time.fixedDeltaTime;
        else
            verticalVelocity = gravity * 0.3f * Time.fixedDeltaTime;

        Vector3 move = movementVelocity + verticalVelocity * Vector3.up;
        charController.Move(move);
    }

    private void CalculateSpeed()
    {
        movementVelocity.Normalize();
        movementVelocity = Quaternion.Euler(0, -45f, 0) * movementVelocity;

        playerAnimator?.SetSpeed(movementVelocity.sqrMagnitude);

        movementVelocity *= moveSpeed * Time.fixedDeltaTime;
        if (movementVelocity.sqrMagnitude > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVelocity), Time.deltaTime * rotateSpeed);
    }

    public void StopImmediatly()
    {
        movementVelocity = Vector3.zero;
    }

    public void SetMovementVelocity(Vector3 value)
    {
        movementVelocity = value;
    }

    public void SetRotation(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        dir.y = transform.position.y;

        transform.rotation = Quaternion.LookRotation(dir);
    }
}