using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class BarSpeed : MonoBehaviour {
	CharaSelectSystem system;
	Slider slider;
	float nownum = 0;
	float innum = 0;
    bool Ischara = false;
    // Use this for initialization
    void Start()
    {
        GameObject parent = gameObject.transform.parent.parent.gameObject;
        system = parent.GetComponent<CharaSelectSystem>();
        slider = this.GetComponent<Slider>();

        if (this.gameObject.tag == "Player")
        {
            Ischara = true;

        }
    }

	// Update is called once per frame
	void Update () {
        if (Ischara)
        { innum = system.charatable.All[system.charanum].Speed; }
        else
        { innum = system.tanktable.All[system.tanknum].Speed; }
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
