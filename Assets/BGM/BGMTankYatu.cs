using UnityEngine;
using System.Collections;

public class BGMTankYatu : MonoBehaviour {
    public int num = 8;
    public GameObject[] BGM = new GameObject[8];

	// Use this for initialization
	void Start () {
        int ran = Random.Range(0,8);
        Instantiate(BGM[ran]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
