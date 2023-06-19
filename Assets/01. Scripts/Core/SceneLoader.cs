using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance = null;
    public static SceneLoader Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<SceneLoader>();

            return instance;
        }
    }

    public Scene CurrentScene;
    private LoadingProgress loadingProgress;

    private void Awake()
    {
        if(instance != null)
            return;

        loadingProgress = transform.Find("LoadingProgress").GetComponent<LoadingProgress>();
    }

    public void AddSceneAsync(string name, Action callback = null) => StartCoroutine(LoadAsyncCoroutine(name, LoadSceneMode.Additive, callback));
    public void LoadSceneAsync(string name, Action callback = null) => StartCoroutine(LoadAsyncCoroutine(name, LoadSceneMode.Single, callback));

    private IEnumerator LoadAsyncCoroutine(string name, LoadSceneMode mode, Action callback)
    {
        loadingProgress?.gameObject.SetActive(true);
        AsyncOperation oper = SceneManager.LoadSceneAsync(name, mode);

        while(!oper.isDone)
        {
            loadingProgress?.SetProgress(oper.progress);
            yield return null;
        }

        loadingProgress?.gameObject.SetActive(false);
        yield return null;

        CurrentScene = SceneManager.GetActiveScene();

        callback?.Invoke();
    }
}
