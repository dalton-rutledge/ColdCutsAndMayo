using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour
{
    public static string pageURL;


    public static int mode = 0;
    public void StartGame()
    {
        mode = 0;
        SceneManager.LoadScene("Main");
    }

    public void StartSub()
    {
        mode = 1;
        SceneManager.LoadScene("Main");
    }

    public void StartNumbers()
    {
        mode = 2;
        SceneManager.LoadScene("Main");
    }
    public void GetURL()
    {
        Application.ExternalCall("GetURL");
    }

    public void SetMyURL(string url)
    {
        pageURL = url;
    }
}
