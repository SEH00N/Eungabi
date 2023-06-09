using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] UnityEvent<Vector3, Vector3> OnDamageEvent;
    [SerializeField] UnityEvent OnDieEvent;

    [SerializeField] int maxHP = 50;
    [SerializeField] private int currentHP = 0;

    public int MaxHP => maxHP;
    public int CurrentHP => currentHP;

    private StateHandler stateHandler = null;

    private void Awake()
    {
        stateHandler = GetComponent<StateHandler>();
    }

    private void Start()
    {
        currentHP = maxHP;

        Effect effect = PoolManager.Instance.Pop("HitEffect") as Effect;
        effect.transform.position = transform.position;
        effect.PlayEffects();
    }

    public void OnDamage(int damage, Transform performer = null, Vector3 position = default, Vector3 normal = default)
    {
        currentHP -= damage;
        OnDamageEvent?.Invoke(position, normal);

        if(currentHP <= 0)
            OnDieEvent?.Invoke();
        else
            stateHandler.ChangeState(StateFlag.Hit);
    }

    public void Revive()
    {
        currentHP = maxHP;
        stateHandler.ChangeState(StateFlag.Normal);
        // GetComponent<PlayerMovement>().enabled = false;
        // transform.position = (StageManager.Instance.Altars[DataManager.Instance.PlayerData.SpawnPointIdx].SpawnPosition.position);
    
        GetComponent<PlayerMovement>().MoveImmediatly(StageManager.Instance.Altars[DataManager.Instance.PlayerData.SpawnPointIdx].SpawnPosition.position - transform.position);
    }
}
