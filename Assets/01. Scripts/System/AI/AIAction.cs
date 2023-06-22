using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIBrain aiBrain;

    public virtual void SetUp(Transform parentRoot)
    {
        aiBrain = parentRoot.GetComponent<AIBrain>();
    }

    public abstract void TakeAction();
}
