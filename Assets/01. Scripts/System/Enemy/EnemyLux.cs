using UnityEngine;
using UnityEngine.Events;

public class EnemyLux : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent OnCollectedEvent;

    public void OnInteract(Transform performer)
    {
        OnCollectedEvent?.Invoke();
    }
}
