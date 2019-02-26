using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public GameObject hazard1;
    //public GameObject hazard2;
    //public GameObject hazard3;
    //public GameObject hazard4;
    //public GameObject hazard5;
    //public Vector3 spawnValues1;
    //public Vector3 spawnValues2;
    //public Vector3 spawnValues3;
    //public Vector3 spawnValues4;
    //public Vector3 spawnValues5;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        endGame();
       // StartCoroutine (SpawnWaves());

    }
    
    private void Update()
    {
        endGame();
        if (restart)
        {
            GameOver();
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    //IEnumerator SpawnWaves()
    //{
    //    //Quaternion spawnRotation = Quaternion.identity;
    //    //Instantiate(hazard1, spawnValues1, spawnRotation);
    //    //Instantiate(hazard2, spawnValues2, spawnRotation);
    //    //Instantiate(hazard3, spawnValues3, spawnRotation);
    //    //Instantiate(hazard4, spawnValues4, spawnRotation);
    //    //Instantiate(hazard5, spawnValues5, spawnRotation);
    //    //yield return new WaitForSeconds(0);

    //    while (!gameOver)
    //    {

    //        yield return new WaitForSeconds(0);

    //        if (hazard1.tag == "GreenMonster" && hazard1 == null)
    //        {
    //            gameOver = true;
    //            restartText.text = "Press 'R' for Restart";
    //            restart = true;
    //            break;
    //        }
    //    }
                 
            
        
    //}

        private void endGame()
    {
       GameObject green =  GameObject.FindWithTag("GreenMonster");
        GameObject blue = GameObject.FindWithTag("BlueMonster");
        GameObject orange = GameObject.FindWithTag("OrangeMonster");
        GameObject purple = GameObject.FindWithTag("PurpleMonster");
        GameObject red = GameObject.FindWithTag("RedMonster");

        if(green == null && blue == null && orange == null && purple == null && red == null)
        {
            gameOver = true;
            restartText.text = "Press 'R' for Restart";
            restart = true;
         
        }
  
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

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
