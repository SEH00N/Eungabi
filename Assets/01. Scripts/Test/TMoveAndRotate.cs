using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class TMoveAndRotate : MonoBehaviour
{
    [SerializeField] Transform cameraTrm;

    private void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        
        if(new Vector2(x, y).sqrMagnitude > 0)
        {
            transform.rotation = Quaternion.Euler(0, cameraTrm.localRotation.eulerAngles.y, 0);
            Vector3 dir = transform.forward * y + transform.right * x;

            transform.Translate(dir * Time.deltaTime * 5f);
        }
    }

    private void Rotation()
    {
        float x = Input.GetAxisRaw("ArrowHorizontal");
        float y = Input.GetAxisRaw("ArrowVertical");

        cameraTrm.Rotate(0, -x, 0, Space.World);
        cameraTrm.Rotate(y, 0, 0, Space.Self);
    }
}