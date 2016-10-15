using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Yjrspoint : MonoBehaviour {
	
	int point;
	RectTransform hoge;
	// Use this for initialization
	void Start () {
		
		hoge = this.gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		point = GameObject.Find("TitleManager").GetComponent<Title>().num;
		switch(point)
		{
			case 2: hoge.position = new Vector2(370f, 258f);
					break;
			case 3: hoge.position = new Vector2(370f, 167f);
					break;
			case 4: hoge.position = new Vector2(370f, 87f);
					break;
		}
	}
}
