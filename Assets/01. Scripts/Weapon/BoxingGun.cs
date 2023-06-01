using UnityEngine;

public class BoxingGun : Weapon
{
    private Animator animator = null;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected override void ActiveWeapon()
    {
        animator.SetBool("OnAttack", true);
    }

    public void OnAnimationEnd()
    {
        animator.SetBool("OnAttack", false);
    }

    public void OnAnimationEvent()
    {
        Debug.Log("받아랏");
    }
}
