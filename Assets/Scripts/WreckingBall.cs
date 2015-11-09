using UnityEngine;
using System.Collections;

public class WreckingBall : MonoBehaviour {

    Rigidbody wreckingBall;
	// Use this for initialization
	void Start () {
        wreckingBall = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            wreckingBall.AddForce(-transform.forward * 100);
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            wreckingBall.AddForce(transform.forward * 100);
        }
    }
}
