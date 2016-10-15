using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class BarTurning : MonoBehaviour {
	CharaSelectSystem system;
	Slider slider;
	float nownum = 0;
	float innum = 0;
	// Use this for initialization
	void Start () {
		GameObject parent = gameObject.transform.parent.parent.gameObject;
		system = parent.GetComponent<CharaSelectSystem>();
		slider = this.GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update () {
		innum = system.tanktable.All[system.tanknum].Turning;
		innum = innum/5;

		if(nownum != innum)
		{
			if(nownum < innum)
				nownum+=0.025f;
			if(nownum > innum)
				nownum-=0.025f;
		}

		slider.value = nownum;
	}
}
