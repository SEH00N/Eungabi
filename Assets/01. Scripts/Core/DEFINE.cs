using UnityEngine;

public class DEFINE
{
    public const int GroundLayer = 1 << 6;
    public const int LuxLayer = 1 << 8;

    private static Camera mainCam = null;
    public static Camera MainCam {
        get {
            if(mainCam == null)
                mainCam = Camera.main;

            return mainCam;
        }
    }
}