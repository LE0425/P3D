using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCtrl : MonoBehaviour
{

    public Transform player;
    public Transform men;

    public GameObject kaishiUI;

    public Button kaishiBtn;

    public bool kaishidianji;


    public Button tishi;

    public GameObject tishiCanvas;
    public int tishicount = 0;

    public Button duigou;

    public GameObject duigouCanvas;

    public Button jietu;
    public Button restart;
    public Button close;
    public int num = 0;
    public GameObject jiajucanvas;
    void Start()
    {
        
        kaishiBtn.onClick.AddListener(delegate
        {
            kaishidianji = true;
            kaishiUI.SetActive(false);
            jiajucanvas.SetActive(true);
            player.gameObject.SetActive(false);
        });

        tishi.onClick.AddListener(delegate
        {
            tishicount += 1;
            if (tishicount % 2 != 0)
            {
                tishiCanvas.SetActive(true);
            }
            else
            {
                tishiCanvas.SetActive(false);
            }
        });

        duigou.onClick.AddListener(delegate
        {
            duigouCanvas.SetActive(true);
        });

        jietu.onClick.AddListener(delegate
        {
            duigouCanvas.SetActive(false);
            num += 1;
            CaptureCamera(Camera.main, new Rect(0, 0, Screen.width, Screen.height));
        });

        restart.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Scene2");
        });

        close.onClick.AddListener(delegate
        {
            Application.Quit();
        });
    }

    void Update()
    {
        float dis = Vector3.Distance(player.position, men.position);
        
        if (dis <= 7 && kaishidianji == false)
        {
            men.rotation = Quaternion.Slerp(men.rotation, Quaternion.Euler(0, 90, 90), Time.deltaTime);
            kaishiUI.SetActive(true);
        }
        else
        {
            men.rotation = Quaternion.Slerp(men.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime);
            kaishiUI.SetActive(false);
        }
    }


    Texture2D CaptureCamera(Camera camera, Rect rect)
    {
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, -1);
         
        camera.targetTexture = rt;
        camera.Render();
         
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rect, 0, 0); 
        screenShot.Apply();
 
        camera.targetTexture = null;
        
        RenderTexture.active = null;  
        GameObject.Destroy(rt);
         
        byte[] bytes = screenShot.EncodeToPNG();

        string filename = Application.streamingAssetsPath + "/Screenshot" + num + ".png";

        System.IO.File.WriteAllBytes(filename, bytes);
        
        return screenShot;
    }

}
