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
    public event Action OnInteractKeyPress = null;

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
        InteractInput();
    }

    private void MovementInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        currentInputDirection = new Vector3(h, 0, v);

        OnMovementKeyPress?.Invoke(currentInputDirection);
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

    private void InteractInput()
    {
        if(Input.GetKeyDown(KeyCode.E))
            OnInteractKeyPress?.Invoke();
    }

    public Vector3 GetCurrentInputDirection() => currentInputDirection.normalized;
    public Vector3 GetMouseWorldPosition() 
    {
        Ray ray = DEFINE.MainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool result = Physics.Raycast(ray, out hit, DEFINE.MainCam.farClipPlane, DEFINE.GroundLayer);

        return (result ? hit.point : Vector3.zero);
    }
}
