using System.Collections;
using System.IO;
using UnityEngine;


public class SceenShoot : MonoBehaviour
{
    public bool ismobile = false;
    public RectTransform screenShotsize;
    public GameObject notificacao;
    // Start is called before the first frame update
    void Start()
    {
        if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            ismobile = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ScreenShot()
    {
        yield return new WaitForEndOfFrame();

        Vector3[] corners = new Vector3[4];
        screenShotsize.GetWorldCorners(corners);

        int width = ((int)corners[3].x - (int)corners[0].x);
        int height = ((int)corners[1].y - (int)corners[0].y);
        var startX = corners[0].x;
        var startY = corners[0].y;

        Texture2D texture = new Texture2D(width, height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
        texture.Apply();


        string name = "MyMonster_MonsterLab" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";

        //PC

        byte[] bytes = texture.EncodeToPNG();
        if (!ismobile)
            File.WriteAllBytes(Application.dataPath + "/../" + name, bytes);
        else
            NativeGallery.SaveImageToGallery(texture, "My Monsters", name);
        //File.WriteAllBytes(Application.dataPath + "/../Sceenshot.png", bytes);
        
        notificacao.SetActive(true);
        Destroy(texture);
    }

    public void TakeScreenShoot()
    {
        StartCoroutine("ScreenShot");
    }
}
