using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimator playerAnimator = null;

    [SerializeField] Weapon mainWeapon = null;
    [SerializeField] Weapon subWeapon = null;

    private void Awake()
    {
        playerAnimator = transform.Find("Model").GetComponent<PlayerAnimator>();
    }

    public void ActiveMainWeapon()
    {
        if(mainWeapon.TryAticveWeapon())
            playerAnimator.ToggleAttack(true);
    }

    public void ActiveSubWeapon()
    {
        if(subWeapon.TryAticveWeapon())
            playerAnimator.ToggleSubAttack(true);
    }
}
