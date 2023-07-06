using System.Collections.Generic;
using UnityEngine;

public class AIBrain : PoolableMono
{
    [SerializeField] protected AIState currentState = null;
    
    protected virtual void Awake()
    {
        List<AIState> states = new List<AIState>();
        transform.Find("AI").GetComponentsInChildren<AIState>(true, states);
        states.ForEach(state => state.SetUp(transform));
    }

    protected virtual void Update()
    {
        if(GameManager.Instance.GamePause == false)
            currentState?.UpdateState();
    }

    public void ChangeState(AIState state)
    {
        currentState?.OnStateExit?.Invoke();
        currentState = state;
        currentState?.OnStateEnter?.Invoke();
    }

    public override void Init()
    {
        
    }
}
