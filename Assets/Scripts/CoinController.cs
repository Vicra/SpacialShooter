using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

    public int coinValue;
    private GameController gameController;
    private PlayerController playerController;
    private int movement;
    public float speed;
    public float lifeTime;
    
	void Start () {
        
        movement = Random.Range(0, 3);
        if(lifeTime!= 0)
            Destroy(gameObject, lifeTime);

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (gameControllerObject != null && playerControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
	}

	void Update () {
        if (movement == 0)
            transform.Translate(-speed, 0, 0);
        else if (movement == 1)
            transform.Translate(-speed / 2f, -speed / 2.5f, 0);
        else
            transform.Translate(-speed / 2f, speed / 2.5f, 0);
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        // lo usan coins, y los upgrades
        if (other.tag == "Boundary" || 
            other.tag == "Shot" || 
            other.tag =="Coin" || 
            other.tag == "DoubleShot" || 
            other.tag == "TripleShot" || 
            other.tag =="FourShot")
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
            else if (gameObject.tag == "IncreaseLife")
                playerController.IncreaseHealth(10);
            Destroy(gameObject);
        }
        
        
    }
}
