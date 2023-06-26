using UnityEngine;

public abstract class AIAction : MonoBehaviour
{

    public virtual void SetUp(Transform parentRoot)
    {
    }

    public abstract void TakeAction();
}
