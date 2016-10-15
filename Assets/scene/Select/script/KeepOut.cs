using UnityEngine;
using System.Collections;

public class KeepOut : MonoBehaviour {
	int playerNo = 0;
	// Use this for initialization
	void Start () {
		switch(this.gameObject.transform.tag)
		{
			case "Player3": playerNo = 2;
			break;
			case "Player4": playerNo = 3;
			break;
		}

		if(playerNo < GameManager.playNo)
			Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
