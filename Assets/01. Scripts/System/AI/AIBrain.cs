using System.Collections.Generic;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    [SerializeField] protected AIState currentState = null;
    
    protected virtual void Awake()
    {
        List<AIState> states = new List<AIState>();
        transform.Find("AI").GetComponentsInChildren<AIState>(states);
        states.ForEach(state => state.SetUp(transform));
    }

    protected virtual void Update()
    {
        currentState?.UpdateState();
    }

    public void ChangeState(AIState state)
    {
        currentState?.OnStateExit();
        currentState = state;
        currentState?.OnStateEnter();
    }
}
