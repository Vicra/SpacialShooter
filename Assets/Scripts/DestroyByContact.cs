using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public int scoreValue;
    public GameController gameController;

    void Start()
    {
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
        
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
