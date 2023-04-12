using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // private event Action player
    private PlayerMovement playerMovement = null;
    private PlayerAttack playerAttack = null;

    public event Action<Vector3> OnMovementKeyPress = null;
    public event Action<AttackFlag> OnAttackKeyPress = null;
    public event Action OnRollingKeyPress = null;

    private Vector3 currentInputDirection = Vector3.zero;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        MovementInput();
        AttackInput();
        RollingInput();
    }

    private void MovementInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        currentInputDirection = new Vector3(h, 0, v);

        OnMovementKeyPress?.Invoke(currentInputDirection);
        //playerMovement.SetMovementVelocity(new Vector3(h, 0, v));
    }

    private void AttackInput()
    {
        if(Input.GetMouseButtonDown(0))
            OnAttackKeyPress?.Invoke(AttackFlag.BaseAttack);
        else if(Input.GetMouseButtonDown(1))
            OnAttackKeyPress?.Invoke(AttackFlag.SubAttack);
    }

    private void RollingInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            OnRollingKeyPress?.Invoke();
    }

    public Vector3 GetCurrentInputDirection() => currentInputDirection.normalized;
}
