using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelScreenController : MonoBehaviour
{
    public static int selection = 0;
    public void Start()
    {
        return;
    }
    public void Level1()
    {
        selection = 1;
        SceneManager.LoadScene("Main");
    }

    public void Level2()
    {
        selection = 2;
        SceneManager.LoadScene("Main");
    }

    public void Level3()
    {
        selection = 3;
        SceneManager.LoadScene("Main");
    }
    public void Level4()
    {
        selection = 4;
        SceneManager.LoadScene("Main");
    }
    public void Level5()
    {
        selection = 5;
        SceneManager.LoadScene("Main");
    }
    public void Level6()
    {
        selection = 6;
        SceneManager.LoadScene("Main");
    }
    public void Level7()
    {
        selection = 7;
        SceneManager.LoadScene("Main");
    }
    public void Level8()
    {
        selection = 8;
        SceneManager.LoadScene("Main");
    }
    public void Level9()
    {
        selection = 9;
        SceneManager.LoadScene("Main");
    }
    public void Leve10()
    {
        selection = 10;
        SceneManager.LoadScene("Main");
    }
    public void Back()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
