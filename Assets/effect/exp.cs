using UnityEngine;
using System.Collections;

public class exp : MonoBehaviour {
    public AudioClip audioClip;
    AudioSource audioSource;
    // Use this for initialization
    void Start () {
        /*audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();*/
        Destroy(gameObject, 3);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
