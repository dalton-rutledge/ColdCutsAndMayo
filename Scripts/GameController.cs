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

    public static string correctAnswer;
    public static bool outOfShots;
    public static int shotsLeft;
    public static List<string> wrongProblems = new List<string>();

    private bool gameOver;
    private bool restart;
    //public string getData;
    private int score;
    public int nullMonster = 0;

    private string[] questions = new string[6];
    private string[] answers = new string[6];
    private string[] teacherList;
    private int[] random = { 0, 1, 2, 3, 4 };
    private List<GameObject> monsters = new List<GameObject>();

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int numShots;
    private int numMonsters = 0;
    private string putString;
    private float timePlayed = 0.0f;
    private int seconds;
    private string levelsWon = "0";
    private string levelsLost = "0";
   



    private void Start()
    {

        // Addition Levels
        if (MenuScreenController.mode == 0)
        {
            if (LevelScreenController.selection == 1)
            {
                shotsLeft = 8;
                questions[0] = " 1 + 1 =";
                questions[1] = " 2 + 1 =";
                questions[2] = " 0 + 1 =";
                questions[3] = " 3 + 1 =";
                questions[4] = " 4 + 1 =";
                questions[5] = "";
                answers[0] = "2";
                answers[1] = "3";
                answers[2] = "1";
                answers[3] = "4";
                answers[4] = "5";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 2)
            {
                shotsLeft = 8;
                questions[0] = " 2 + 2 =";
                questions[1] = " 2 + 3 =";
                questions[2] = " 1 + 5 =";
                questions[3] = " 2 + 1 =";
                questions[4] = " 6 + 1 =";
                questions[5] = "";
                answers[0] = "4";
                answers[1] = "5";
                answers[2] = "6";
                answers[3] = "3";
                answers[4] = "7";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 3)
            {
                shotsLeft = 8;
                questions[0] = " 3 + 2 =";
                questions[1] = " 4 + 3 =";
                questions[2] = " 1 + 5 =";
                questions[3] = " 2 + 6 =";
                questions[4] = " 9 + 1 =";
                questions[5] = "";
                answers[0] = "5";
                answers[1] = "7";
                answers[2] = "6";
                answers[3] = "8";
                answers[4] = "10";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 4)
            {
                shotsLeft = 8;
                questions[0] = " 7 + 2 =";
                questions[1] = " 5 + 3 =";
                questions[2] = " 10 + 5 =";
                questions[3] = " 1 + 6 =";
                questions[4] = " 9 + 2 =";
                questions[5] = "";
                answers[0] = "9";
                answers[1] = "8";
                answers[2] = "15";
                answers[3] = "7";
                answers[4] = "11";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 5)
            {
                shotsLeft = 7;
                questions[0] = " 10 + 2 =";
                questions[1] = " 5 + 6 =";
                questions[2] = " 10 + 5 =";
                questions[3] = " 3 + 6 =";
                questions[4] = " 9 + 4 =";
                questions[5] = "";
                answers[0] = "12";
                answers[1] = "11";
                answers[2] = "15";
                answers[3] = "9";
                answers[4] = "13";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 6)
            {
                shotsLeft = 7;
                questions[0] = " 11 + 4 =";
                questions[1] = " 5 + 8 =";
                questions[2] = " 7 + 5 =";
                questions[3] = " 3 + 7 =";
                questions[4] = " 8 + 3 =";
                questions[5] = "";
                answers[0] = "15";
                answers[1] = "13";
                answers[2] = "12";
                answers[3] = "10";
                answers[4] = "11";
                answers[5] = "";
            }

            if (LevelScreenController.selection == 7)
            {
                shotsLeft = 7;
                questions[0] = " 11 + 10 =";
                questions[1] = " 4 + 15 =";
                questions[2] = " 12 + 5 =";
                questions[3] = " 3 + 11 =";
                questions[4] = " 17 + 3 =";
                questions[5] = "";
                answers[0] = "21";
                answers[1] = "19";
                answers[2] = "17";
                answers[3] = "14";
                answers[4] = "20";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 8)
            {
                shotsLeft = 6;
                questions[0] = " 11 + 15 =";
                questions[1] = " 15 + 6 =";
                questions[2] = " 8 + 12 =";
                questions[3] = " 7 + 11 =";
                questions[4] = " 7 + 22 =";
                questions[5] = "";
                answers[0] = "26";
                answers[1] = "21";
                answers[2] = "20";
                answers[3] = "18";
                answers[4] = "29";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 9)
            {
                shotsLeft = 6;
                questions[0] = " 11 + 20 =";
                questions[1] = " 18 + 6 =";
                questions[2] = " 6 + 23 =";
                questions[3] = " 20 + 20 =";
                questions[4] = " 17 + 20 =";
                questions[5] = "";
                answers[0] = "31";
                answers[1] = "24";
                answers[2] = "29";
                answers[3] = "40";
                answers[4] = "37";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 10)
            {
                shotsLeft = 5;
                questions[0] = " 20 + 30 =";
                questions[1] = " 15 + 27 =";
                questions[2] = " 30 + 17 =";
                questions[3] = " 23 + 11 =";
                questions[4] = " 53 + 7 =";
                questions[5] = "";
                answers[0] = "50";
                answers[1] = "42";
                answers[2] = "47";
                answers[3] = "34";
                answers[4] = "60";
                answers[5] = "";
            }

        }
        // Subtraction Levels
        if (MenuScreenController.mode == 1)
        {
            if (LevelScreenController.selection == 1)
            {
                shotsLeft = 8;
                questions[0] = " 1 - 1 =";
                questions[1] = " 3 - 0 =";
                questions[2] = " 2 - 1 =";
                questions[3] = " 4 - 2 =";
                questions[4] = " 5 - 1 =";
                questions[5] = "";
                answers[0] = "0";
                answers[1] = "3";
                answers[2] = "1";
                answers[3] = "2";
                answers[4] = "4";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 2)
            {
                shotsLeft = 8;
                questions[0] = " 5 - 4 =";
                questions[1] = " 3 - 3 =";
                questions[2] = " 2 - 0 =";
                questions[3] = " 4 - 1 =";
                questions[4] = " 5 - 1 =";
                questions[5] = "";
                answers[0] = "1";
                answers[1] = "0";
                answers[2] = "2";
                answers[3] = "3";
                answers[4] = "4";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 3)
            {
                shotsLeft = 8;
                questions[0] = " 6 - 2 =";
                questions[1] = " 3 - 0 =";
                questions[2] = " 7 - 1 =";
                questions[3] = " 7 - 3 =";
                questions[4] = " 4 - 3 =";
                questions[5] = "";
                answers[0] = "4";
                answers[1] = "3";
                answers[2] = "6";
                answers[3] = "4";
                answers[4] = "1";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 4)
            {
                shotsLeft = 8;
                questions[0] = " 9 - 2 =";
                questions[1] = " 7 - 3 =";
                questions[2] = " 8 - 6 =";
                questions[3] = " 6 - 3 =";
                questions[4] = " 9 - 8 =";
                questions[5] = "";
                answers[0] = "7";
                answers[1] = "4";
                answers[2] = "2";
                answers[3] = "3";
                answers[4] = "1";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 5)
            {
                shotsLeft = 7;
                questions[0] = " 11 - 2 =";
                questions[1] = " 10 - 3 =";
                questions[2] = " 15 - 7 =";
                questions[3] = " 13 - 11 =";
                questions[4] = " 11 - 8 =";
                questions[5] = "";
                answers[0] = "9";
                answers[1] = "7";
                answers[2] = "8";
                answers[3] = "2";
                answers[4] = "3";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 6)
            {
                shotsLeft = 7;
                questions[0] = " 11 - 2 =";
                questions[1] = " 10 - 3 =";
                questions[2] = " 15 - 7 =";
                questions[3] = " 13 - 11 =";
                questions[4] = " 11 - 8 =";
                questions[5] = "";
                answers[0] = "9";
                answers[1] = "7";
                answers[2] = "8";
                answers[3] = "2";
                answers[4] = "3";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 7)
            {
                shotsLeft = 7;
                questions[0] = " 15 - 5 =";
                questions[1] = " 10 - 7 =";
                questions[2] = " 17 - 3 =";
                questions[3] = " 16 - 11 =";
                questions[4] = " 13 - 7 =";
                questions[5] = "";
                answers[0] = "10";
                answers[1] = "3";
                answers[2] = "14";
                answers[3] = "5";
                answers[4] = "6";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 8)
            {
                shotsLeft = 6;
                questions[0] = " 19 - 5 =";
                questions[1] = " 18 - 13 =";
                questions[2] = " 13 - 6 =";
                questions[3] = " 15 - 13 =";
                questions[4] = " 16 - 7 =";
                questions[5] = "";
                answers[0] = "14";
                answers[1] = "5";
                answers[2] = "7";
                answers[3] = "2";
                answers[4] = "9";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 9)
            {
                shotsLeft = 6;
                questions[0] = " 20 - 5 =";
                questions[1] = " 22 - 13 =";
                questions[2] = " 25 - 18 =";
                questions[3] = " 15 - 2 =";
                questions[4] = " 28 - 7 =";
                questions[5] = "";
                answers[0] = "15";
                answers[1] = "9";
                answers[2] = "7";
                answers[3] = "13";
                answers[4] = "21";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 10)
            {
                shotsLeft = 5;
                questions[0] = " 30 - 11 =";
                questions[1] = " 40 - 20 =";
                questions[2] = " 35 - 18 =";
                questions[3] = " 25 - 2 =";
                questions[4] = " 29 - 7 =";
                questions[5] = "";
                answers[0] = "19";
                answers[1] = "20";
                answers[2] = "17";
                answers[3] = "23";
                answers[4] = "22";
                answers[5] = "";
            }
        }
        // Number Places Levels
        if (MenuScreenController.mode == 2)
        {
            if(LevelScreenController.selection == 1)
            {
                shotsLeft = 8;
                questions[0] = " 12 (1's place)";
                questions[1] = " 15 (10's place)";
                questions[2] = " 53 (10's place)";
                questions[3] = " 34 (1's place)";
                questions[4] = " 19 (1's place)";
                questions[5] = "";
                answers[0] = "2";
                answers[1] = "1";
                answers[2] = "5";
                answers[3] = "4";
                answers[4] = "9";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 2)
            {
                shotsLeft = 8;
                questions[0] = " 15 (1's place)";
                questions[1] = " 204 (100's place)";
                questions[2] = " 163 (10's place)";
                questions[3] = " 70 (10's place)";
                questions[4] = " 123 (1's place)";
                questions[5] = "";
                answers[0] = "5";
                answers[1] = "2";
                answers[2] = "6";
                answers[3] = "7";
                answers[4] = "3";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 3)
            {
                shotsLeft = 8;
                questions[0] = " 156 (1's place)";
                questions[1] = " 804 (100's place)";
                questions[2] = " 993 (10's place)";
                questions[3] = " 505 (10's place)";
                questions[4] = " 721 (1's place)";
                questions[5] = "";
                answers[0] = "6";
                answers[1] = "8";
                answers[2] = "9";
                answers[3] = "0";
                answers[4] = "1";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 4)
            {
                shotsLeft = 8;
                questions[0] = " 988 (1's place)";
                questions[1] = " 236 (100's place)";
                questions[2] = " 541 (10's place)";
                questions[3] = " 676 (10's place)";
                questions[4] = " 236 (1's place)";
                questions[5] = "";
                answers[0] = "8";
                answers[1] = "2";
                answers[2] = "4";
                answers[3] = "7";
                answers[4] = "6";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 5)
            {
                shotsLeft = 7;
                questions[0] = " 567 (1's place)";
                questions[1] = " 934 (100's place)";
                questions[2] = " 163 (100's place)";
                questions[3] = " 609 (10's place)";
                questions[4] = " 482 (1's place)";
                questions[5] = "";
                answers[0] = "7";
                answers[1] = "9";
                answers[2] = "1";
                answers[3] = "0";
                answers[4] = "2";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 6)
            {
                shotsLeft = 7;
                questions[0] = " 962 (1's place)";
                questions[1] = " 670 (100's place)";
                questions[2] = " 329 (100's place)";
                questions[3] = " 148 (10's place)";
                questions[4] = " 659 (1's place)";
                questions[5] = "";
                answers[0] = "2";
                answers[1] = "6";
                answers[2] = "3";
                answers[3] = "4";
                answers[4] = "9";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 7)
            {
                shotsLeft = 7;
                questions[0] = " 368 (1's place)";
                questions[1] = " 489 (100's place)";
                questions[2] = " 970 (100's place)";
                questions[3] = " 367 (10's place)";
                questions[4] = " 951 (1's place)";
                questions[5] = "";
                answers[0] = "8";
                answers[1] = "4";
                answers[2] = "9";
                answers[3] = "6";
                answers[4] = "1";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 8)
            {
                shotsLeft = 6;
                questions[0] = " 543 (1's place)";
                questions[1] = " 509 (100's place)";
                questions[2] = " 821 (100's place)";
                questions[3] = " 794 (10's place)";
                questions[4] = " 290 (1's place)";
                questions[5] = "";
                answers[0] = "3";
                answers[1] = "5";
                answers[2] = "8";
                answers[3] = "9";
                answers[4] = "0";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 9)
            {
                shotsLeft = 6;
                questions[0] = " 901 (1's place)";
                questions[1] = " 857 (10's place)";
                questions[2] = " 321 (100's place)";
                questions[3] = " 874 (10's place)";
                questions[4] = " 342 (1's place)";
                questions[5] = "";
                answers[0] = "1";
                answers[1] = "5";
                answers[2] = "3";
                answers[3] = "7";
                answers[4] = "2";
                answers[5] = "";
            }
            if (LevelScreenController.selection == 10)
            {
                shotsLeft = 5;
                questions[0] = " 126 (1's place)";
                questions[1] = " 639 (10's place)";
                questions[2] = " 915 (100's place)";
                questions[3] = " 750 (10's place)";
                questions[4] = " 280 (1's place)";
                questions[5] = "";
                answers[0] = "6";
                answers[1] = "3";
                answers[2] = "9";
                answers[3] = "5";
                answers[4] = "0";
                answers[5] = "";
            }
        }
        // Teacher Questions
        if (MenuScreenController.mode == 3)
        {
            shotsLeft = 8;
            questions[0] = (string)MenuScreenController.teacherList.GetValue(0);
            questions[1] = (string)MenuScreenController.teacherList.GetValue(1);
            questions[2] = (string)MenuScreenController.teacherList.GetValue(2);
            questions[3] = (string)MenuScreenController.teacherList.GetValue(3);
            questions[4] = (string)MenuScreenController.teacherList.GetValue(4);
            questions[5] = "";
            answers[0] = (string)MenuScreenController.teacherList.GetValue(5);
            answers[1] = (string)MenuScreenController.teacherList.GetValue(6);
            answers[2] = (string)MenuScreenController.teacherList.GetValue(7);
            answers[3] = (string)MenuScreenController.teacherList.GetValue(8);
            answers[4] = (string)MenuScreenController.teacherList.GetValue(9);
            answers[5] = "";
        }

        gameOver = false;
        restart = false;
        outOfShots = false;
        gameOverText.text = "";
        seconds = (int)(timePlayed % 60);
        TimerText.text = "Time: " + seconds;
        score = 0;
        numShots = 0;
        random = ShuffleArray(random);
        FindMonsters();
        ShowQuestion();
        CheckAdd();
        UpdateScore();
        UpdateShots();
        endGame();

        questionIndex = 0;
        isRoundActive = true;

    }

    private void ShowQuestion()
    {
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
        //Set text to non-null monsters
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


        UnityWebRequest www = UnityWebRequest.Put("https://cs95gbqvoi.execute-api.us-west-2.amazonaws.com/get_post_put/student-details?" + words[1], putString);
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
