using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public int scoreValue;
    private GameController gameController;
    int randomCoins;
    public GameObject coin;

    

    //new code
    public GameObject[] upgrades; // shot upgrades, shield
    private GameObject randomUpgrade;
    private cameraShake camShake;
    void Start()
    {
        //adding new code
        randomUpgrade = upgrades[Random.Range(0, upgrades.Length)];

        randomCoins = Random.Range(0, 4);
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameObject camShakeControllerObject = GameObject.FindWithTag("MainCamera");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
            camShake = camShakeControllerObject.GetComponent<cameraShake>();

        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find gamee controller object");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Boundary" || other.tag == "Coin" || other.tag == "DoubleShot" || other.tag == "TripleShot" || other.tag == "FourShot")
        {
            return;
        }
        camShake.Shake();   
        for (int i = 0; i < randomCoins; i++)
        {
            Instantiate(coin, transform.position, transform.rotation);
        }
        if(randomCoins == 1)
            Instantiate(randomUpgrade, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            gameController.gameOverText.text = "Game Over Press R to restart";
            gameController.GameOver();

        }
        Instantiate(explosion, transform.position, transform.rotation);
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
