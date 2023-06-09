using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] float gravityScale = 1;

    private CharacterController characterController = null;
    private PlayerAnimator playerAnimator = null;

    private Vector3 movementDir = Vector3.zero;
    public Vector3 MovementDir => movementDir;

    private Quaternion lookDirection = Quaternion.identity;

    private Vector3 movementVelocity = Vector3.zero;

    private float gravity = -9.81f;
    private float verticalVelocity = 0f;

    public bool IsActiveMove { get; set; }
    public bool IsActiveRotate { get; set; }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimator = transform.Find("Model").GetComponent<PlayerAnimator>();
        IsActiveMove = true;
        IsActiveRotate = true;
    }

    private void FixedUpdate()
    {
        if (IsActiveMove)
            CalculateSpeed();

        if (characterController.isGrounded == false)
            verticalVelocity = gravity * gravityScale * Time.fixedDeltaTime;
        else
            verticalVelocity = gravity * 0.3f * Time.fixedDeltaTime;

        Vector3 move = movementVelocity + verticalVelocity * Vector3.up;
        characterController.Move(move);
    }

    private void CalculateSpeed()
    {
        movementVelocity = Quaternion.Euler(0, -45f, 0) * movementDir.normalized;

        playerAnimator?.SetSpeed(movementDir.sqrMagnitude);

        movementVelocity *= moveSpeed * Time.fixedDeltaTime;
        
        // if (movementDir.sqrMagnitude > 0)
        //     lookDir = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVelocity), 0.5f);
            
        // transform.rotation = Quaternion.Lerp(transform.rotation, lookDir, Time.fixedDeltaTime * rotateSpeed);
        if (IsActiveRotate)
        {
            if(movementDir.sqrMagnitude > 0)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVelocity), Time.fixedDeltaTime * rotateSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection, Time.fixedDeltaTime * rotateSpeed);
        }
    }

    public void StopImmediatly()
    {
        movementDir = Vector3.zero;
        movementVelocity = Vector3.zero;
        playerAnimator?.SetSpeed(0f);
    }

    public void SetMovementDirection(Vector3 value) => movementDir = value;
    public void SetMovementVelocity(Vector3 value) => movementVelocity = value;
    public void MoveImmediatly(Vector3 target) => characterController.Move(target);

    public void SetRotationImmediatly(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        dir.y = 0;

        transform.rotation = Quaternion.LookRotation(dir);
    }

    public void SetRotation(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        dir.y = 0;

        lookDirection = Quaternion.LookRotation(dir);
    }
}