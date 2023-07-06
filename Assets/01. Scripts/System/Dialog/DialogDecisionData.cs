using UnityEngine.Events;

[System.Serializable]
public class DialogDecisionData
{
    public string decisionName;
    public bool hadDecision;
    public UnityEvent PositiveDecisionEvent;
    public UnityEvent NegativeDecisionEvent;
}