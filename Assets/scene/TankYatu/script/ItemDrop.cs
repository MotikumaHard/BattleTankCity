using UnityEngine;
using System.Collections;

public class ItemDrop : MonoBehaviour {
    public GameObject Hiropon;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void HiroponDrop() {
        int ran = Random.Range(0, 9);
        if (ran == 0)
        {
            Instantiate(Hiropon, transform.position, transform.rotation);
        }
    }
}
