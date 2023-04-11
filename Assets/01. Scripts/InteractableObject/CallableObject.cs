using UnityEngine;

public abstract class CallableObject : MonoBehaviour, IInteractable
{


    public abstract void OnInteract(Transform performer);
    public void DisplayInterface()
    {
        //UI 띄우기
    }
}
