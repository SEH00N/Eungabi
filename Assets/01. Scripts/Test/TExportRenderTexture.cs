using System;
using System.IO;
using UnityEngine;

public class TExportRenderTexture : MonoBehaviour
{
    [SerializeField] RenderTexture renderTexture = null;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            try {
                // Render Texture를 Texture2D로 변환
                Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
                RenderTexture.active = renderTexture;
                texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
                texture.Apply();
                RenderTexture.active = null;

                // Texture2D를 PNG 파일로 저장
                byte[] pngData = texture.EncodeToPNG();
                string filePath = Path.Join(Application.persistentDataPath, "us4dnt", "BG.png");
                File.WriteAllBytes(filePath, pngData);

                Debug.Log("Exported");

            } catch (Exception err) {
                Debug.Log(err.Message);
            }
        }

    }
}
