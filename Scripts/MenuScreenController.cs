using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuScreenController : MonoBehaviour
{
    public static string pageURL;
    public Button button;
    public static bool isEnabled = false;


    public static int mode = 0;
    private string getData;
    public static string[] teacherList;


    public void Start()
    {

        StartCoroutine(GetRequest());

        button = GameObject.FindGameObjectWithTag("TeacherMode").GetComponent<Button>();
        button.enabled = isEnabled;
    }

    public void StartGame()
    {
        mode = 0;
        SceneManager.LoadScene("Levels");
    }

    public void StartSub()
    {
        mode = 1;
        SceneManager.LoadScene("Levels");
    }

    public void StartNumbers()
    {
        mode = 2;
        SceneManager.LoadScene("Levels");
    }
    public void StartTeacher()
    {
        mode = 3;
        SceneManager.LoadScene("Main");

    }

    [RuntimeInitializeOnLoadMethod]
    public IEnumerator GetRequest()
    {
        string url = Application.absoluteURL;
        string[] words = url.Split('?');
        //string pretendURL = "https://cs95gbqvoi.execute-api.us-west-2.amazonaws.com/get_post_put/problems-get-post?Class_ID=9999";
        //UnityWebRequest www = UnityWebRequest.Get(pretendURL);
        UnityWebRequest www = UnityWebRequest.Get("https://cs95gbqvoi.execute-api.us-west-2.amazonaws.com/get_post_put/problems-get-post?" + words[1]);


        yield return www.SendWebRequest();

        while (!www.isDone)
        {
            yield return true;
        }

        if (www.isNetworkError)
        {
            print("Error");
            Debug.Log(www.error);


        }
        else
        {
            Debug.Log(www.responseCode);
            Debug.Log(www.downloadHandler.text);
            getData = www.downloadHandler.text;
            if (getData.StartsWith("{\"errorMessage\"") == false)
            {
                isEnabled = true;
                button.enabled = true;
               
            }
            if (isEnabled == false)
            {
                ColorBlock colors = button.colors;
                colors.normalColor = colors.disabledColor;
                button.colors = colors;
            }

            getData = getData.Substring(1, getData.Length - 2);
            teacherList = getData.Split(',');




        }
    }


}
