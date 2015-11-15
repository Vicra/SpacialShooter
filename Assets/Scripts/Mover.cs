using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    public float speed;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
	}
    

     
	
	
}
