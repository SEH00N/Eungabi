using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIState : MonoBehaviour
{
    public UnityEvent OnStateEnter = null;
    public UnityEvent OnStateExit = null;

    protected List<AITransition> transitions;
    protected List<AIAction> actions;
    protected AIBrain aiBrain;

    public virtual void SetUp(Transform parentRoot)
    {
        aiBrain = parentRoot.GetComponent<AIBrain>();

        transitions = new List<AITransition>();
        GetComponentsInChildren<AITransition>(true, transitions);
        transitions.ForEach(t => t.SetUp(parentRoot));

        actions = new List<AIAction>();
        GetComponents<AIAction>(actions);
        actions.ForEach(a => a.SetUp(parentRoot));
    }

    public virtual void UpdateState()
    {
        foreach (AIAction a in actions)
            a.TakeAction();

        foreach(AITransition t in transitions)
        {
            if(t.CheckDecisions())
            {
                aiBrain.ChangeState(t.NextState);
                break;
            }
        }
    }
}
