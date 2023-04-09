using System;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    [SerializeField] State currentState = null;
    private Dictionary<StateFlag, State> stateDictionary = new Dictionary<StateFlag, State>();

    private void Awake()
    {
        Transform stateArchive = transform.Find("State");
        foreach(StateFlag stateType in Enum.GetValues(typeof(StateFlag)))
        {
            State state = stateArchive.GetComponent($"{stateType}State") as State;
            if(state == null)
            {
                Debug.LogWarning($"There is no script about {stateType} state");
                continue;
            }

            state.SetUp(transform.root);
            stateDictionary.Add(stateType, state);
        }
    }

    private void Start()
    {
        ChangeState(StateFlag.Normal);
    }

    private void Update()
    {
        currentState?.UpdateState();
    }

    public void ChangeState(StateFlag targetState)
    {
        if(stateDictionary.ContainsKey(targetState) == false) 
        {
            Debug.LogWarning($"There is no script about {targetState} state");
            return;
        }

        currentState?.OnExitState();
        currentState = stateDictionary[targetState];

        currentState?.OnEnterState();
    }
}
