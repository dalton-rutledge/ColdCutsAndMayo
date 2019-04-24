using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactMonster : MonoBehaviour
{
    public static bool addProb = false;

    public AudioSource clip;
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;


    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Boundary")
        {
            return;
        }
        //If game object is the correct answer
        if (gameObject.GetComponent<GUIText>().text == GameController.correctAnswer)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        //Else if the game object is not the correct answer
        else if(gameObject.GetComponent<GUIText>().text != GameController.correctAnswer || gameObject.tag == "BackBoundary")
        {
            addProb = true;
            clip.Play();
          


        }
      

    }
}
