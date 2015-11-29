using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

    public int typeOfMovement;
    public float movementSpeed;

    void Update()
    {
        Vector3 currentPosition = transform.position;
        if (typeOfMovement == 1)//izquierda
        {
            transform.position += new Vector3(movementSpeed, 0, 0);
        }
        else if (typeOfMovement == 2)//diagonal izq abajo
        {
            transform.position += new Vector3(-0.25f, -0.05f, 0);
        }
        else if (typeOfMovement == 3)//diagonal izq arriba
        {
            transform.position += new Vector3(-0.25f, 0.05f, 0);
        }
        
    }
}
