using UnityEngine;

public class LoadingProgress : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] Transform playerTrm;
    
    [SerializeField, Range(0f, 1f)] float progress = 0f;

    private void Update()
    {
        playerTrm.position = Vector3.Lerp(startPos.position, endPos.position, progress);
    }

    public void SetProgress(float theta)
    {
        progress = theta;
    }
}
