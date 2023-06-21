using UnityEngine;
using UnityEngine.Events;

public class EnemyLux : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent OnCollectedEvent;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnInteract(Transform performer)
    {
        OnCollectedEvent?.Invoke();
    }
}
