using UnityEngine;
using System.Collections;

public class Mover1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        Vector3 currentPosition = transform.position;
        transform.position += new Vector3(0.25f, 0.05f,0);
    }
}
