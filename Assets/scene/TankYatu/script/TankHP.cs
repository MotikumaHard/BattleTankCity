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
    }
}
