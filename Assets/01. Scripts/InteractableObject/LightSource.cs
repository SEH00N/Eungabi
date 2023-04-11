using UnityEngine;

public abstract class LightSource : MonoBehaviour, IInteractable
{
    public abstract void OnInteract(GameObject performer);
}
