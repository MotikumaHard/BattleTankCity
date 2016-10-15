using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class CharaSelectManager : MonoBehaviour {

	int DeciNum = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(DeciNum == GameManager.playNo)
		{
			Invoke("Load",1.0f);
		}
	}

	public void PushA()
	{
		DeciNum++;
	}

	public void PushB()
	{
		DeciNum--;
	}

	void Load()
	{
		SceneManager.LoadScene("tankyatu");
	}

}
