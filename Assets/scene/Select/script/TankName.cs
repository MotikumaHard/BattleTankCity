using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class TankName : MonoBehaviour {
	CharaSelectSystem system;
	Text thisText;
	// Use this for initialization
	void Start () {
		GameObject parent = gameObject.transform.parent.parent.gameObject;
		system = parent.GetComponent<CharaSelectSystem>();
		thisText = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		thisText.text = system.tankname;
	}
}
