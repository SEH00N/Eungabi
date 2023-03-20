using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // private event Action player
    private PlayerMovement movement = null;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement.SetMovementVelocity(new Vector3(x, 0, y));
    }
}
