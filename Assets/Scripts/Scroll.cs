using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        gameObject.GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
    