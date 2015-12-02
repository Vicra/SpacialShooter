using UnityEngine;
using System.Collections;

public class ShotSpawn : MonoBehaviour {

    private AudioSource audioSource;
	void Start () {
	
	}
	
	// Update is called once per frame
	public void PlayAudio () {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
	}
}
