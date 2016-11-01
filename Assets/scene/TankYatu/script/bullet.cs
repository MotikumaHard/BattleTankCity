using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    public float speeds = 0.01f;
    public GameObject bakuha;
    public GameObject seHit;
    public GameObject seInjection;
    public GameObject seBrock;
    public AudioClip audioClip;
    AudioSource audioSource;
    public int attack;

    // Use this for initialization
    void Start()
    {
        {
            GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speeds;
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            Instantiate(seInjection, transform.position, transform.rotation);
        }
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {



    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player1" || c.tag == "Player2" || c.tag == "Player3" || c.tag == "Player4")
        {
            c.gameObject.GetComponent<Tank>().DmageHp(attack);
            Instantiate(seHit, transform.position, transform.rotation);
            Instantiate(bakuha, transform.position, transform.rotation);//爆発アニメーションの再生
            Destroy(gameObject);//自身の削除
        }
        else if (c.tag == "block")
        {
            c.gameObject.GetComponent<ItemDrop>().HiroponDrop();
            Destroy(c.gameObject);
            Instantiate(seBrock, transform.position, transform.rotation);
            Instantiate(bakuha, transform.position, transform.rotation);//爆発アニメーションの再生
            Destroy(gameObject);//自身の削除
        }
        else if (c.tag == "Unbreakable block")
        {
            Instantiate(seBrock, transform.position, transform.rotation);
            Instantiate(bakuha, transform.position, transform.rotation);//爆発アニメーションの再生
            Destroy(gameObject);
        }//自身の削除}
         //Destroy(c.gameObject);//自身の削除
    }
}
