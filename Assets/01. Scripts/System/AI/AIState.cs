using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : MonoBehaviour
{
    protected List<AITransition> transitions;
    protected List<AIAction> actions;
    protected AIBrain aiBrain;

    public virtual void SetUp(Transform parentRoot)
    {
        aiBrain = parentRoot.GetComponent<AIBrain>();

        transitions = new List<AITransition>();
        GetComponentsInChildren<AITransition>(transitions);
        transitions.ForEach(t => t.SetUp(parentRoot));

        actions = new List<AIAction>();
        GetComponents<AIAction>();
        actions.ForEach(a => a.SetUp(parentRoot));
    }

    public abstract void OnStateEnter();
    public abstract void OnStateExit();
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
