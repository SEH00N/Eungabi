using UnityEngine;

public class LoadSceneCallback : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneLoader.Instance.LoadSceneAsync(sceneName);
    }
}
