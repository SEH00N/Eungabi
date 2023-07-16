using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] UnityEvent<Vector3, Vector3> OnDamageEvent;
    [SerializeField] UnityEvent OnStunEvent;
    [SerializeField] UnityEvent OnDieEvent;

    public int MaxHP => enemyData.MaxHP;
    public int CurrentHP => currentHP;

    [SerializeField]
    private EnemyDataSO enemyData = null;
    private int currentHP = 0;
    private int currentStunStack = 0;

    private void Awake()
    {
        Init();
    }

    public void OnDamage(int damage, Transform performer = null, Vector3 position = default, Vector3 normal = default)
    {
        if(currentStunStack < enemyData.StunTrigger)
        {
            currentStunStack++;
            OnDamageEvent?.Invoke(position, normal);
            Debug.Log($"{gameObject.name} : OnDamage");

            if(currentStunStack >= enemyData.StunTrigger)
            {
                OnStunEvent?.Invoke();
                currentStunStack = 0;
                Debug.Log($"{gameObject.name} : OnStun");
            }
        }
    }

    public void OnDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP <= 0)
            OnDieEvent?.Invoke();
    }

    public void Init(EnemyDataSO enemyData = null)
    {
        if(enemyData != null)
            this.enemyData = enemyData;

        currentHP = this.enemyData.MaxHP;
        currentStunStack = 0;
    }

    public void 빠빠이(EnemyAIBrain aiBrain)
    {
        //풀링으로 바꾸기
        PoolManager.Instance.Push(aiBrain);
    }
}
