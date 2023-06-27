using UnityEngine;
using UnityEngine.Events;

public class EnemyLux : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent OnCollectedEvent;
    private EnemyHealth enemyHealth = null;

    private void Awake()
    {
        enemyHealth = transform.parent.GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnInteract(Transform performer)
    {
        enemyHealth.OnDamage(1);

        if(enemyHealth.CurrentHP > 0)
            OnCollectedEvent?.Invoke();
    }
}
