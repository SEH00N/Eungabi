using System;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private Dictionary<StateType, State> stateDictionary = new Dictionary<StateType, State>();
    private State currentState = null;

    private void Awake()
    {
        Transform stateArchive = transform.Find("State");
        foreach(StateType stateType in Enum.GetValues(typeof(StateType)))
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
        ChangeState(StateType.Normal);
    }

    private void Update()
    {
        currentState?.UpdateState();
    }

    public void ChangeState(StateType targetState)
    {
        currentState?.OnExitState();
        currentState = stateDictionary[targetState];

        currentState?.OnEnterState();
    }
}
