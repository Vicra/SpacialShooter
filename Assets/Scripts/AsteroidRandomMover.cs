using UnityEngine;
using System.Collections;

public class AsteroidRandomMover : MonoBehaviour {
    public float speed;
	// Use this for initialization
    private Rigidbody2D rb;
	void Start () {
        rb  = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-speed, 0, 0);
	}
}
