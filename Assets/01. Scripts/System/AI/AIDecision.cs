using System;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIBrain aiBrain;

    [SerializeField] bool isReverse;
    public bool IsReverse => isReverse;

    public virtual void SetUp(Transform parentRoot)
    {
        aiBrain = parentRoot.GetComponent<AIBrain>();
    }

    public abstract bool MakeDecision();
}
