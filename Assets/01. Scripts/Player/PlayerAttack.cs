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
            playerAnimator.ToggleSwing(true);
    }

    public void ActiveSubWeapon()
    {

    }
}
