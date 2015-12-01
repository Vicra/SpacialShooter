using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject[] shots;
    private int movementType;

    //FIRE LOGIC
    public float fireRate;
    private float nextFire;

    //GAMEOBJECT COMPONENTS
    public Transform shotSpawn;
    GameObject shot;

    //CIRCULAR MOTION 
    public float degreesPerSecond = -65.0f;
    Vector3 vectorAngle;
    Vector3 centerCircle;

    public float movementSpeed;

	void Start () {
        centerCircle = new Vector3(8, 0, 0);
        shot = shots[Random.Range(0, shots.Length)];
        movementType = Random.Range(0, 3);
        vectorAngle = (transform.position - centerCircle) / 1.02f;
	}
	
	// Update is called once per frame
	void Update () {
        //INSTANTIATE SHOT
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        
        //MOVEMENT CODE
        switch (movementType)
        {
            case 1:
                MoveCircular();
                break;
            case 2:
                MoveHorizontal();
                break;
            default:
                MoveLeft();
                break;
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyShot"  || 
            other.tag == "Boundary"   || 
            other.tag == "Coin"       || 
            other.tag == "DoubleShot" || 
            other.tag == "TripleShot" ||
            other.tag == "Enemy"      || 
            other.tag == "FourShot")
        {
            return;
        }
        if (other.tag == "Shot" || other.tag == "Player")
        {
           
            Destroy(gameObject);
        }
    }
    private void MoveLeft()
    {
        transform.position += new Vector3(-movementSpeed, 0, 0);
    }

    private void MoveHorizontal()
    {
        vectorAngle = (transform.position - centerCircle) / 1.02f;
        centerCircle += new Vector3(-movementSpeed, 0, 0);
        vectorAngle = Quaternion.AngleAxis(degreesPerSecond * Time.deltaTime, Vector3.forward) * vectorAngle;
        transform.position = centerCircle + vectorAngle;
    }

    private void MoveCircular()
    {
        vectorAngle = Quaternion.AngleAxis(degreesPerSecond * Time.deltaTime, Vector3.forward) * vectorAngle;
        transform.position = centerCircle + vectorAngle;
    }
}
