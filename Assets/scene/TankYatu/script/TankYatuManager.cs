using UnityEngine;
using System.Collections;

public class TankYatuManager : MonoBehaviour {

    int playerNo;
    public int Survival;
    public bool IsPlay = false;
    Result result;

    void Awake()
    {
        Survival = GameManager.playNo;
    }

    // Use this for initialization
    void Start () {
        result = GameObject.Find("RESULT").GetComponent<Result>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Death()
    {
        Survival--;
    }

    public void Settlement(int player)
    {
        Survival = 0;
        result.display(player);
        IsPlay = false;
    }
}
