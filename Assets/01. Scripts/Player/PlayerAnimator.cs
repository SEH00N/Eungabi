using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator = null;

    private int speedHash = Animator.StringToHash("Speed");
    private int onSwingHash = Animator.StringToHash("OnSwing");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed) => animator.SetFloat(speedHash, speed);
    public void ToggleSwingTrigger(bool value)
    {
        if(value)
            animator.SetTrigger(onSwingHash);
        else
            animator.ResetTrigger(onSwingHash);
    }
}
