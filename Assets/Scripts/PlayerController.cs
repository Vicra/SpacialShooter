using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {
    
    //**SHOTS GAMEOBJECTS
    public GameObject shot;
    public GameObject upShot;
    public GameObject downShot;

    //***SHOT POSITIONS
    private Vector3 shot1Position;
    private Vector3 shot2Position;
    private Vector3 shotUpPosition;
    private Vector3 shotDownPosition;

    //**COMPONENTS
    private Rigidbody2D rigidBody;
    private AudioSource audioSource;
    public Transform shotSpawn;
    
	//**LOGIC
    public float movementSpeed;
    public Boundary boundary;//area to keep ship inside camera

    //**FIRE LOGIC
    public float fireRate;
    private float nextFire;
    private int fireType;

    //**UPGRADES
    public GameObject shield;

    //**FILE
    private string fileName;
    FileInfo file; 

	void Start () {
        fileName = "shoot";
        file = new FileInfo(Application.dataPath + "\\" + fileName + ".txt");
        LoadShot();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        shot1Position = new Vector3(shotSpawn.position.x, shotSpawn.position.y + 0.25f, shotSpawn.position.z);
        shot2Position = new Vector3(shotSpawn.position.x, shotSpawn.position.y - 0.25f, shotSpawn.position.z);
        shotUpPosition= new Vector3(shotSpawn.position.x, shotSpawn.position.y + 0.3f, shotSpawn.position.z);
        shotDownPosition = new Vector3(shotSpawn.position.x, shotSpawn.position.y - 0.3f, shotSpawn.position.z);


        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (fireType == 1)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
            else if (fireType == 2)
            {
                Instantiate(shot, shot1Position, shotSpawn.rotation);
                Instantiate(shot, shot2Position, shotSpawn.rotation);
            }
            else if (fireType == 3)
            {
                Instantiate(upShot, shotUpPosition, shotSpawn.rotation);
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                Instantiate(downShot, shotDownPosition, shotSpawn.rotation);
            }
            else if (fireType == 4)
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
            transform.Translate(touchDeltaPosition.x * movementSpeed, touchDeltaPosition.y * movementSpeed, 0);
        }
        
	}
    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidBody.velocity = movement * 6;
        rigidBody.position = new Vector2(
            Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rigidBody.position.y, boundary.yMin, boundary.yMax)
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
    public void SaveShot(int newFireType)
    {
        try
        {
            StreamWriter writer;
            if (!file.Exists)
            {
                writer = file.CreateText();
            }
            else
            {
                file.Delete();
                writer = file.CreateText();
            }
            writer.WriteLine(newFireType.ToString());
            writer.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

    }

    void LoadShot()
    {
        try
        {
            if (file.Exists)
            {
                StreamReader reader = File.OpenText(Application.dataPath + "\\" + fileName + ".txt");
                string savedFireType = reader.ReadLine();
                fireType = Int32.Parse(savedFireType);
                reader.Close();
            }
            else {
                fireType = 1;
                SaveShot(1);
            } 
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
