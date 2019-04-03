using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Random = UnityEngine.Random;
using System;
using Amazon;
using System.Security.Cryptography;
using System.Text;



public class GameController : MonoBehaviour
{
    public GUIText scoreText;
    public GUIText TimerText;
    public GUIText gameOverText;
    public GUIText QuestionText;
    public GUIText redMonsterText;
    public GUIText purpleMonsterText;
    public GUIText blueMonsterText;
    public GUIText greenMonsterText;
    public GUIText orangeMonsterText;
    public GUIText shotsText;

    public int nullMonster = 0;
    public static string correctAnswer;

    private bool gameOver;
    private bool restart;
    public static bool outOfShots;
    private int score;

    //private string[] questions = { " 4 + 5 =", " 1 + 3 = ", " 2 + 5 = ", " 1 + 1 = ", " 7 + 1 = ", "" };
    private string[] questions = new string[6];
    private string[] answers = new string[6];
    private int[] random = { 0, 1, 2, 3, 4 };
    private List<GameObject> monsters = new List<GameObject>();

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int numShots;
    public static int shotsLeft = 8;
    private int numMonsters = 0;
    private string putString;
    private float timePlayed = 0.0f;
    private int seconds;
    private string levelsWon = "0";
    private string levelsLost = "0";
    public static List<string> wrongProblems = new List<string>();



    private void Start()
    {

        if (MenuScreenController.mode == 0)
        {
            questions[0] = " 4 + 5 =";
            questions[1] = " 1 + 3 =";
            questions[2] = " 2 + 5 =";
            questions[3] = " 1 + 1 =";
            questions[4] = " 7 + 1 =";
            questions[5] = "";
            answers[0] = "9";
            answers[1] = "4";
            answers[2] = "7";
            answers[3] = "2";
            answers[4] = "8";
            answers[5] = "";
        }
        if (MenuScreenController.mode == 1)
        {
            questions[0] = " 9 - 5 =";
            questions[1] = " 3 - 1 =";
            questions[2] = " 7 - 0 =";
            questions[3] = " 2 - 2 =";
            questions[4] = " 6 - 3 =";
            questions[5] = "";
            answers[0] = "4";
            answers[1] = "2";
            answers[2] = "7";
            answers[3] = "0";
            answers[4] = "3";
            answers[5] = "";
        }

        if (MenuScreenController.mode == 2)
        {
            questions[0] = " 395 (1's place)";
            questions[1] = " 204 (100's place)";
            questions[2] = " 153 (100's place)";
            questions[3] = " 1000 (10's place)";
            questions[4] = " 1234 (1's place)";
            questions[5] = "";
            answers[0] = "5";
            answers[1] = "2";
            answers[2] = "1";
            answers[3] = "0";
            answers[4] = "4";
            answers[5] = "";
        }

        gameOver = false;
        restart = false;
        outOfShots = false;
        gameOverText.text = "";
        int seconds = (int)(timePlayed % 60);
        TimerText.text = "Time: " + seconds;
        score = 0;
        numShots = 0;
        shotsLeft = 8;
        random = ShuffleArray(random);
        FindMonsters();
        ShowQuestion();
        CheckAdd();
        UpdateScore();
        UpdateShots();
        endGame();

        dataController = FindObjectOfType<DataController>();
       // currentRoundData = dataController.GetCurrentRoundData();
       // questionPool = currentRoundData.questions;
       // timeRemaining = currentRoundData.timeLimitInSeconds;
        questionIndex = 0;
        isRoundActive = true;

    }

    private void ShowQuestion()
    {
        //int oneIndex ;
        nullMonster = 0;
        for (int i = 0; i< monsters.Count; i++){
            
            if (monsters[i] == null)
            {
                nullMonster += 1;
            }

        }


        QuestionText.text = questions[nullMonster];
        correctAnswer = answers[nullMonster];

        redMonsterText.text = answers[random[0]];
        purpleMonsterText.text = answers[random[1]];
        blueMonsterText.text = answers[random[2]];
        greenMonsterText.text = answers[random[3]];
        orangeMonsterText.text = answers[random[4]];

        if(monsters[0] != null)
        {
            monsters[0].GetComponent<GUIText>().text = greenMonsterText.text;
        }
        if (monsters[1] != null)
        {
            monsters[1].GetComponent<GUIText>().text = blueMonsterText.text;
        }
        if (monsters[2] != null)
        {
            monsters[2].GetComponent<GUIText>().text = orangeMonsterText.text;
        }
        if (monsters[3] != null)
        {
            monsters[3].GetComponent<GUIText>().text = purpleMonsterText.text;
        }
        if (monsters[4] != null)
        {
            monsters[4].GetComponent<GUIText>().text = redMonsterText.text;
        }

    }

    private void Update()
    {
        ShowQuestion();
        StartCoroutine(UpdateShots());
        CheckAdd();
        numShots = PlayerController.numShots;
        DelMonsterText();
        if (gameOver == false)
        {
            timePlayed += Time.deltaTime;
            seconds = (int)(timePlayed % 60);
        }
        TimerText.text = "Time: " + seconds;
        endGame();
        if (restart)
        {
            GameOver();
            if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene("MenuScreen");
            }
        }
    }


    private void FindMonsters()
    {
        GameObject green = GameObject.FindWithTag("GreenMonster");
        GameObject blue = GameObject.FindWithTag("BlueMonster");
        GameObject orange = GameObject.FindWithTag("OrangeMonster");
        GameObject purple = GameObject.FindWithTag("PurpleMonster");
        GameObject red = GameObject.FindWithTag("RedMonster");

        monsters.Add(green);
        monsters.Add(blue);
        monsters.Add(orange);
        monsters.Add(purple);
        monsters.Add(red);

    }

    private void DelMonsterText()
    {
        if(monsters[0] == null)
        {
            greenMonsterText.text = "";
        }
        if (monsters[1] == null)
        {
            blueMonsterText.text = "";
        }
        if (monsters[2] == null)
        {
            orangeMonsterText.text = "";
        }
        if (monsters[3] == null)
        {
            purpleMonsterText.text = "";
        }
        if (monsters[4] == null)
        {
            redMonsterText.text = "";
        }
    }


    private void endGame()
    {
        GameObject green = monsters[0];
        GameObject blue = monsters[1];
        GameObject orange = monsters[2];
        GameObject purple = monsters[3];
        GameObject red = monsters[4];

        if (green == null && blue == null && orange == null && purple == null && red == null || outOfShots == true)
        {
            if (gameOver == false)
            {
                if(green == null && blue == null && orange == null && purple == null && red == null)
                {
                    levelsWon = "1";
                }
                else if (green != null || blue != null || orange != null || purple != null || red != null)
                {
                    levelsLost = "1";
                }

                StartCoroutine(MakeRequest());
            }
            gameOver = true;
            restart = true;
         
        }
  
    }

    private int[] ShuffleArray(int[] array)
    {
        System.Random r = new System.Random();
        for (int i = array.Length; i > 0; i--)
        {
            int j = r.Next(i);
            int k = array[j];
            array[j] = array[i - 1];
            array[i - 1] = k;
        }
        return array;
    }


    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    IEnumerator UpdateShots()
    {

        shotsLeft = shotsLeft - numShots;
        shotsText.text = "Shots Left: " + shotsLeft;
        if (shotsLeft < 1)
        {
            yield return new WaitForSeconds(1);
            outOfShots = true;
        }
    }

    private void WaitForSecondsRealtime(int v)
    {
        throw new NotImplementedException();
    }

    public void GameOver()
    {
        string text = "Game Over! @ Press 'N' for new level";
        text = text.Replace("@", System.Environment.NewLine);
        gameOverText.text = text;

        gameOver = true;
    }

    public void CheckAdd()
    {
        if(DestroyByContactMonster.addProb == true)
        {
            wrongProblems.Add(QuestionText.text);
            DestroyByContactMonster.addProb = false;
        }
    }

    public IEnumerator MakeRequest()
    {
        PutJson putObj = gameObject.AddComponent<PutJson>();
        putObj.Time_Played = seconds.ToString();
        putObj.Level_Wins = levelsWon;
        putObj.Level_Losses = levelsLost;

        putObj.Wrong_Probs = wrongProblems;
        putString = JsonUtility.ToJson(putObj);
        print(putString);
        print("URL:");
        //string pretendURL = "http://coldcuts.s3-website-us-west-2.amazonaws.com/studentData.html?Class_ID=9876&studentName=1&Student_Name=Dalton";
        string url = Application.absoluteURL;
        string[] words = url.Split('?');


        UnityWebRequest www = UnityWebRequest.Put("https://cs95gbqvoi.execute-api.us-west-2.amazonaws.com/get_post_put/student-details?"+words[1], putString);
        www.SetRequestHeader("content-type", "application/json");
        www.downloadHandler = new DownloadHandlerBuffer();
        wrongProblems.Clear();
        levelsWon = "0";
        levelsLost = "0";
        

      yield return www.SendWebRequest();
        if (www.isNetworkError)
        {
            print("Error");
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.responseCode);
            Debug.Log(www.downloadHandler.text);

        }
    }


}
