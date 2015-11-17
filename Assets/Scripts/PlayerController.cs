using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	// Use this for initialization
    public float speed;
    public Boundary boundary;
    private Rigidbody2D rb;

    public GameObject shot;
    public GameObject upShot;
    public GameObject downShot;
    public Transform shotSpawn;
    private AudioSource audioSource;
    public GameObject shield;

    public float fireRate;
    private float nextFire;

    int fireType;
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();

        //I need to load here from the file, if he has purchased any shot to start with it
        fireType = 0;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 shot1Position = new Vector3(shotSpawn.position.x, shotSpawn.position.y + 0.25f, shotSpawn.position.z);
        Vector3 shot2Position = new Vector3(shotSpawn.position.x, shotSpawn.position.y - 0.25f, shotSpawn.position.z);
        Vector3 shotUpPosition= new Vector3(shotSpawn.position.x, shotSpawn.position.y + 0.3f, shotSpawn.position.z);
        Vector3 shotDownPosition = new Vector3(shotSpawn.position.x, shotSpawn.position.y - 0.3f, shotSpawn.position.z);


        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (fireType == 0)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
            else if (fireType == 1)
            {
                Instantiate(shot, shot1Position, shotSpawn.rotation);
                Instantiate(shot, shot2Position, shotSpawn.rotation);
            }
            else if (fireType == 2)
            {
                Instantiate(upShot, shotUpPosition, shotSpawn.rotation);
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                Instantiate(downShot, shotDownPosition, shotSpawn.rotation);
            }
            else if (fireType == 3)
            {
                Instantiate(upShot, shotUpPosition, shotSpawn.rotation);
                Instantiate(shot, shot1Position, shotSpawn.rotation);
                Instantiate(shot, shot2Position, shotSpawn.rotation);
                Instantiate(downShot, shotDownPosition, shotSpawn.rotation);
            }
            
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            transform.Translate(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);
        }
        
	}
    void FixedUpdate()//alksd
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * 6;
        rb.position = new Vector2(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax)
        );
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        
        
    }
    public void UpdateShot(int shotType)
    {
        fireType = shotType;
    }

    void AddShield()
    {
        //Instantiate(shield, transform.position, transform.rotation);
    }
}
