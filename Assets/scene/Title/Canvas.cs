using UnityEngine;
using System.Collections;

public class Canvas : MonoBehaviour {
	public GameObject select2;
	public GameObject select3;
	public GameObject select4;
	public GameObject yjrs;
	Title title;
	GameObject objtitle;
	bool IsOnce = false;
	// Use this for initialization
	void Start () {
		title = GameObject.Find("TitleManager").GetComponent<Title>();
		objtitle = GameObject.Find("start");
	}
	
	// Update is called once per frame
	void Update () {
		if(title.IsStart&&!IsOnce)
		{ 
			DestroyObject(objtitle);
			GameObject obj = (GameObject)Instantiate(select2, new Vector2(500f,250f), Quaternion.identity);
			obj.transform.parent = transform;
			obj = (GameObject)Instantiate(select3, new Vector2(500f, 170f), Quaternion.identity);
			obj.transform.parent = transform;
			obj = (GameObject)Instantiate(select4, new Vector2(500f, 90f), Quaternion.identity);
			obj.transform.parent = transform;
			obj = (GameObject)Instantiate(yjrs,new Vector2(370f, 258f), Quaternion.identity);
			obj.transform.parent = transform;
			IsOnce = true;

		}
	}
}
