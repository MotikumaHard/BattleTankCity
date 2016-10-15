using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankNameUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject parent = gameObject.transform.parent.gameObject;

        var thisText = this.gameObject.GetComponent<Text>();
        thisText.text = parent.GetComponent<TankUIManaer>().Tankname;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
