using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankHP : MonoBehaviour {
    Slider slider;
    GameObject parent;
    float MaxHP;
    float NowHP;
    TankManager tankmanager;
    bool Isfirst = true ;
    public Image chara;
    public GameObject flag;
    bool Isflag = false;
    // Use this for initialization
    void Start () {
        parent = gameObject.transform.parent.gameObject;
        slider = this.GetComponent<Slider>();
        var tank = ("Tank" + (parent.GetComponent<TankUIManaer>().playerNo + 1));
 
        tankmanager = GameObject.Find(tank).GetComponent<TankManager>();

        Sprite sp = Resources.Load<Sprite>("Chara/"+tankmanager.CharaID);

        chara.sprite = sp;

    }
	
	// Update is called once per frame
	void Update () {
        if (Isfirst)
        {
            MaxHP = tankmanager.TankHP;
            Isfirst = false;
        }
        NowHP = tankmanager.TankHP;
        slider.value = (NowHP / MaxHP);

        if(NowHP == 0 && !Isflag)
        {
            var pos = new Vector2(transform.position.x -40,transform.position.y + 50);
            GameObject obj = (GameObject)Instantiate(flag,pos,transform.rotation);
            obj.transform.parent = this.transform;

            Isflag = true;
        }
    }
}
