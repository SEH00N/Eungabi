using UnityEngine;
using UnityEngine.Events;

public class EnemyLux : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent<Vector3, Vector3> OnCollectedEvent;
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
        {
            Vector3 normal = (performer.position - transform.position).normalized;
            normal.y = 0;
            OnCollectedEvent?.Invoke(transform.position, normal);
        }
    }
}
