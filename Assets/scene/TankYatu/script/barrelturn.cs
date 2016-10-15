using UnityEngine;
using System.Collections;

public class barrelturn : MonoBehaviour {
    public float angl = 0;
    public KeyCode migi;
    public KeyCode hidari;
    Tank tank;
    TankYatuManager TankYatu;
    // Use this for initialization
    void Start () {
        tank = gameObject.transform.parent.gameObject.GetComponent<Tank>();
        TankYatu = GameObject.Find("TankYatu").GetComponent<TankYatuManager>();
    }
	
	// Update is called once per frame
	void Update () {

        var nangl = tank.angl+angl;
        transform.rotation = Quaternion.AngleAxis(nangl, Vector3.back);
        if (TankYatu.IsPlay)
        {
            if (tank.R || tank.L)
            {

                if (tank.R) //右を押した時の処理
                {
                    angl += 2;
                }

                if (tank.L) //左を押した時の処理
                {
                    angl -= 2;
                }
            }
        }
    }
}
