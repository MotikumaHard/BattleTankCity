using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class TankName : MonoBehaviour {
	CharaSelectSystem system;
	Text thisText;
    bool Ischara = false;
	// Use this for initialization
	void Start () {
		GameObject parent = gameObject.transform.parent.parent.gameObject;
		system = parent.GetComponent<CharaSelectSystem>();
		thisText = this.gameObject.GetComponent<Text>();

        if (this.gameObject.tag == "Player")
        {
            Ischara = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Ischara)
        { thisText.text = system.charaname; }
        else
            {
                thisText.text = system.tankname;
            }
        }
}
