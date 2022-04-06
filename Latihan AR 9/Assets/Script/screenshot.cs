using System.Collections;
using System.IO;
using UnityEngine;

public class screenshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        string name = "Screenshot_EpicApp" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        
        
        //MOBILE
        NativeGallery.SaveImageToGallery(texture, "Batik CLothes Simulator", name);

        Destroy(texture);
        
    }

    public void TakeScreenshot()
    {
        StartCoroutine("Screenshot");
    }
}