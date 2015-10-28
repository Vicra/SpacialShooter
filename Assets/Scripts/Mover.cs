using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(gameObject,1.7f);
	}
	
	
}
