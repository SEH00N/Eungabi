using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected PlayerInput playerInput = null;
    protected PlayerMovement playerMovement = null;
    protected PlayerAnimator playerAnimator = null;
    protected StateHandler stateHandler = null;

    public abstract void OnEnterState();
    public abstract void UpdateState();
    public abstract void OnExitState();

    public virtual void SetUp(Transform root)
    {
        playerInput = root.GetComponent<PlayerInput>();
        playerMovement = root.GetComponent<PlayerMovement>();
        stateHandler = root.GetComponent<StateHandler>();
        playerAnimator = root.Find("Model").GetComponent<PlayerAnimator>();
    }
}