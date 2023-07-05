using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }

    public bool GamePause { get; set; }

    private void Awake()
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 120;
        if(instance != null)
            return;

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
