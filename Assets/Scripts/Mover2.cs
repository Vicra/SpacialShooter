using UnityEngine;
using System.Collections;

public class Mover2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        transform.position += new Vector3(0.25f, -0.05f, 0);
    }
}
