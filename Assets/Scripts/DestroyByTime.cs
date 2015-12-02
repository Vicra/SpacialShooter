using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	// Use this for initialization
    public float time;
	void Start () {
        if (time == 0 )
            Destroy(gameObject, 0.8f);
        Destroy(gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
