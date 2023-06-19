using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<GameManager>();

            return null;
        }
    }

    private void Awake()
    {
        if(instance != null)
            return;

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
