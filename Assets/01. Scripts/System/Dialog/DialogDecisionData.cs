using UnityEngine.Events;

[System.Serializable]
public class DialogDecisionData
{
    public bool hadDecision;
    public UnityEvent PositiveDecisionEvent;
    public UnityEvent NegativeDecisionEvent;
}