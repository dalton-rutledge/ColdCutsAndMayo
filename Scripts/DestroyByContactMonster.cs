using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactMonster : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public static bool addProb = false;
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
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Boundary")
        {
            return;
        }
        if (gameObject.GetComponent<GUIText>().text == GameController.correctAnswer)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(gameObject.GetComponent<GUIText>().text != GameController.correctAnswer || gameObject.tag == "BackBoundary")
        {
            print("HERE");
            addProb = true;
        }
      

    }
}
