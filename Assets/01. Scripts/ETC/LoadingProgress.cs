using UnityEngine;

public class LoadingProgress : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] Transform playerTrm;

    public void SetProgress(float theta)
    {
        playerTrm.position = Vector3.Lerp(startPos.position, endPos.position, theta);
    }
}
