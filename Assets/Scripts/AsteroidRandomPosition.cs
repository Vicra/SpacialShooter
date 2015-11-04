using UnityEngine;
using System.Collections;

public class AsteroidRandomPosition : MonoBehaviour {
    public float fireRate;
    private float nextFire;

    public GameObject asteroid;
    public Transform shotSpawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //Instantiate(asteroid, shotSpawn.position, shotSpawn.rotation);
        }
	}
}
