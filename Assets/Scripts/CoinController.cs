﻿using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	// Use this for initialization
    public int coinValue;
    private GameController gameController;
    private int movement;
    public float speed;
    
    // Use this for initialization
    
        
        
    
	void Start () {
        
        movement = Random.Range(0, 3);
        Destroy(gameObject, 10);
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

        if (other.tag == "Boundary" || other.tag == "Shot")
        {
            return;
        }
        
        
        gameController.AddCoins(coinValue);
        Destroy(gameObject);
    }
}