using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankUIManaer : MonoBehaviour {
    public string Tankname;
    TankMaster TankData;
    public int playerNo = 0;
    // Use this for initialization
    void Awake () {

        

        switch (this.gameObject.transform.tag)
        {
            case "Player1":
                playerNo = 0;
                break;
            case "Player2":
                playerNo = 1;
                break;
            case "Player3":
                playerNo = 2;
                break;
            case "Player4":
                playerNo = 3;
                break;
        }

        if (playerNo > (GameManager.playNo - 1 ))
        {
            Destroy(this.gameObject);
        }

            TankMasterTable tanktable;
        tanktable = new TankMasterTable();
        tanktable.Load();
        TankData = tanktable.All[GameManager.Tank[playerNo]];
        Tankname = TankData.Name;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
