using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Boundary")
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
