using UnityEngine;
using System.Collections;

public class soujyu : MonoBehaviour
{
    public float angl ;
    float acs = 0;
    public float spd = 0;
    public KeyCode mae;
    public KeyCode usiro;
    public KeyCode migi;
    public KeyCode hidari;
    TankYatuManager TankYatu;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TankYatu = GameObject.Find("TankYatu").GetComponent<TankYatuManager>();

        if (TankYatu.IsPlay)
        {
            //戦車の横移動の処理


            //戦車の向きを変える
            transform.rotation = Quaternion.AngleAxis(angl, Vector3.back);

            //戦車前進
            var forward = this.transform.TransformDirection(Vector3.up);
            //ここまで

            if (Input.GetKey(migi)) //右を押した時の処理
            {
                angl++;
            }

            if (Input.GetKey(hidari)) //左を押した時の処理
            {
                angl--;
            }
            if (Input.GetKey(mae))
            {
                this.transform.position += forward * spd * Time.deltaTime;
            }
            if (Input.GetKey(usiro))
            {
                this.transform.position -= forward * spd * Time.deltaTime;
            }
        }
    }
}


    

