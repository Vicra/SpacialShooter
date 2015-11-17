using UnityEngine;
using System.Collections;

public class AsteroidRandomMover : MonoBehaviour {
    public float speed;
    private float rawSpeed;


    private Rigidbody2D rb;
	void Start () {
        rawSpeed = Random.Range(2,3);
        rb  = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(-speed*rawSpeed, 0, 0);

	}
}
