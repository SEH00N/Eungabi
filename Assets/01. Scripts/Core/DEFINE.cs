using UnityEngine;

public class DEFINE
{
    public const int GroundLayer = 1 << 6;
    public const int LuxLayer = 1 << 8;
    public const int EnemyLayer = 1 << 9;

    private static Camera mainCam = null;
    public static Camera MainCam {
        get {
            if(mainCam == null)
                mainCam = Camera.main;

            return mainCam;
        }
    }

    private static Transform playerTrm = null;
    public static Transform PlayerTrm {
        get {
            if(playerTrm == null)
                playerTrm = GameObject.FindGameObjectWithTag("Player")?.transform;

            return playerTrm;
        }
    }
}