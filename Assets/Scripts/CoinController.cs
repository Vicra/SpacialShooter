using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	// Use this for initialization
    public int coinValue;
    private GameController gameController;
    private PlayerController playerController;
    private int movement;
    public float speed;
    
    // Use this for initialization
    
        
        
    
	void Start () {
        
        movement = Random.Range(0, 3);
        Destroy(gameObject, 10);
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (gameControllerObject != null && playerControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
            playerController = playerControllerObject.GetComponent<PlayerController>();

        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find gamee controller object");
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (movement == 0)
            transform.Translate(-speed, 0, 0);
        else if (movement == 1)
            transform.Translate(-speed / 3, -speed / 3, 0);
        else
            transform.Translate(-speed / 3, speed / 3, 0);
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        // lo usan coins, y los upgrades
        if (other.tag == "Boundary" || other.tag == "Shot" || other.tag =="Coin" || other.tag == "DoubleShot" || other.tag == "TripleShot" || other.tag =="FourShot")
        {
            return;
        }

        if (gameObject.tag == "Coin" && other.tag == "Player")
        {
            gameController.AddCoins(coinValue); 
            Destroy(gameObject);
        }
        
        if (other.tag == "Player")
        {
            if (gameObject.tag == "DoubleShot")
                playerController.UpdateShot(2);
            else if (gameObject.tag == "TripleShot")
                playerController.UpdateShot(3);
            else if (gameObject.tag == "FourShot")
                playerController.UpdateShot(4);
            //else if (gameObject.tag == "FourShot")
                //playerController.AddShield();
            Destroy(gameObject);
        }
        
        
    }
}
