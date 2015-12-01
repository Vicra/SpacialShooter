using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour {


    public GameObject player;
    public float sec;
    void Start()
    {
        //if (!gameObject.activeInHierarchy)
        //    gameObject.SetActive(true);
        //StartCoroutine(LateCall());
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = player.transform.position; 
	}
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(sec);
        gameObject.SetActive(false);
    }
    public void ActivateShield()
    {
        gameObject.SetActive(true);
        StartCoroutine(LateCall());
    }
    public void DeativateShield()
    {
        gameObject.SetActive(false);
    }
}
