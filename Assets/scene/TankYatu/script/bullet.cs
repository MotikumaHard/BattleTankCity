﻿using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float speeds = 0.01f;
    public GameObject bakuha;
    public AudioClip audioClip;
    AudioSource audioSource;
    public int attack;

    // Use this for initialization
    void Start () {
        {
            GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speeds;
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
        }
        Destroy(gameObject, 3);
    }
	
	// Update is called once per frame
	void Update () {
       


    }
    void OnTriggerEnter2D(Collider2D c)
    {
        audioSource.Play();//爆発音の再生
        if (c.tag == "Player1"|| c.tag == "Player2"|| c.tag == "Player3"|| c.tag == "Player4")
        {
            c.gameObject.GetComponent<Tank>().DmageHp(attack*4);
        }
        else if(c.tag == "block")
        {
            Destroy(c.gameObject);
        }else { }
        //Destroy(c.gameObject);//自身の削除
        Instantiate(bakuha, transform.position, transform.rotation);//爆発アニメーションの再生
        Destroy(gameObject);//自身の削除
    }
}
