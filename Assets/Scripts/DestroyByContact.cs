using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public int scoreValue;
    private GameController gameController;
    int randomCoins;
    public GameObject coin;
    void Start()
    {
        randomCoins = Random.Range(0, 4);
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();

        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find gamee controller object");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Boundary" )
        {
            return;
        }
        for (int i = 0; i < randomCoins; i++)
        {
            Instantiate(coin, transform.position, transform.rotation);
        }


        Instantiate(explosion, transform.position, transform.rotation);
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
