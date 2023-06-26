using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    [SerializeField] bool reverse;
    public bool Reverse => reverse;

    public virtual void SetUp(Transform parentRoot)
    {
    }

    public abstract bool MakeDecision();
}
