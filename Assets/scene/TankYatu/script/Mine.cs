using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

    public int Damage;
    public GameObject bakuha;
    public GameObject seHit;
    bool IsHit = false;

	// Use this for initialization
	void Start () {
        Invoke("Setbool",2.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Setbool()
    {
        IsHit = true;
        var spRenderer = GetComponent<SpriteRenderer>();
        var color = spRenderer.color;
        color.a = 0.1f;
        spRenderer.color = color;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(IsHit){
            if (c.tag == "Player1" || c.tag == "Player2" || c.tag == "Player3" || c.tag == "Player4")
            {
                c.gameObject.GetComponent<Tank>().DmageHp(Damage);
                Instantiate(seHit, transform.position, transform.rotation);

                Instantiate(bakuha, transform.position, transform.rotation);//爆発アニメーションの再生
                Destroy(gameObject);//自身の削除
            }
        }

        //Destroy(c.gameObject);//自身の削除

    }
}
