using UnityEngine;
using System.Collections;

public class TankManager : MonoBehaviour {

    public GameObject[] Tank = new GameObject[4];
    int playerNo = 0;
    string tanktag;
    float angle = 0;
    public TankMaster TankData;
    public int TankHP;
    public int TankAttack;
    public float TankSpeed;
    public float TankTurning;
    public float TankRe;

    public GameObject seDeath;
    public GameObject bakuhatu;
    TankYatuManager TankYatu;
    GameObject obj;
    bool IsSurvival = false;
    public bool IsPlay = false;

	// Use this for initialization
	void Start () {

        TankYatu = GameObject.Find("TankYatu").GetComponent<TankYatuManager>();

        switch (this.gameObject.transform.tag)
        {
            case "Player1":
                playerNo = 0;
                angle = 90;
                tanktag = "Player1";
                break;
            case "Player2":
                playerNo = 1;
                angle = -90;
                tanktag = "Player2";
                break;
            case "Player3":
                playerNo = 2;
                angle = 90;
                tanktag = "Player3";
                break;
            case "Player4":
                playerNo = 3;
                angle = -90;
                tanktag = "Player4";
                break;
        }

        if (playerNo < (GameManager.playNo)) {
            TankMasterTable tanktable;
            tanktable = new TankMasterTable();
            tanktable.Load();

            CharaMasterTable charatable;
            charatable = new CharaMasterTable();
            charatable.Load();

            IsSurvival = true;
            CharaMaster CharaData = charatable.All[GameManager.Chara[playerNo]];
            TankData = tanktable.All[GameManager.Tank[playerNo]];
            TankHP = (TankData.Hp + CharaData.Hp) * 10;
            TankAttack = (TankData.Attack+CharaData.Attack);
            TankTurning = (TankData.Turning + CharaData.Turning);
            TankSpeed = (TankData.Speed + CharaData.Speed);
            TankRe = (TankData.Reload + CharaData.Reload)/3 * 2;

            obj = (GameObject)Instantiate(Tank[GameManager.Tank[playerNo]], transform.position, Quaternion.identity);
            obj.transform.parent = this.transform;
            obj.tag = (tanktag);
            obj.layer = LayerMask.NameToLayer((playerNo + 1) + "p");
            var tankobj = obj.GetComponent<Tank>();
            tankobj.angl = angle;
        }
    }

    // Update is called once per frame
    void Update () {
        if(IsSurvival)
        {
            if(TankYatu.Survival == 1)
            {
                TankYatu.Settlement(playerNo);
            }
        }
	}

    public void DecreaseHP(int attack)
    {
        TankHP = TankHP - attack;
        if (TankHP < 0)
        {
            TankHP = 0;
            Instantiate(bakuhatu, obj.transform.position, transform.rotation);
            Instantiate(seDeath, obj.transform.position, transform.rotation);
            Destroy(obj);
            TankYatu.Death();
            IsSurvival = false;

        }
    }
}
