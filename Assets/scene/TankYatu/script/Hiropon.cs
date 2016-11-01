using UnityEngine;
using System.Collections;



public class Hiropon : MonoBehaviour
{
    public int Heal = 50;
    public GameObject serecovery;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player1" || c.tag == "Player2" || c.tag == "Player3" || c.tag == "Player4")
        {
            c.gameObject.GetComponent<Tank>().Hiropon(Heal);
            Instantiate(serecovery, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
