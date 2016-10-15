using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    public GameObject bullet;
    public float utuwait;
    private bool utu= true;
    public KeyCode shootkye;
    Tank tank;
    int attack;
    float turning;
    TankManager manager;
    TankYatuManager TankYatu;

    // Use this for initialization
    void Start()
    {
        
        tank = gameObject.transform.parent.parent.gameObject.GetComponent<Tank>();
        manager = gameObject.transform.parent.parent.parent.gameObject.GetComponent<TankManager>();
        attack = manager.TankData.Attack;
        turning = (10.0f-manager.TankRe) / 7;
        utuwait = (3.5f - (manager.TankRe*0.5f));
    }


	// Update is called once per frame
	void Update () {
        {
            TankYatu = GameObject.Find("TankYatu").GetComponent<TankYatuManager>();

            if (TankYatu.IsPlay)
            {
                if (tank.A)
                {
                    if (utu)
                    {
                        // 弾をプレイヤーと同じ位置/角度で作成
                        var obj = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
                        var objbullet = obj.GetComponent<bullet>();
                        objbullet.attack = attack;
                        obj.layer = LayerMask.NameToLayer((tank.playerNo + 1) + "pbullet");
                        utu = false;
                        StartCoroutine("sleep");

                    }
                }
            }
        }
    }
    IEnumerator sleep()
    {

        Debug.Log("開始");

        yield return new WaitForSeconds(utuwait); 
        utu = true;
        Debug.Log("撃てます");


    }
}
