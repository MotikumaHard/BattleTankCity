using UnityEngine;
using System.Collections;
using GamepadInput;

public class Tank : MonoBehaviour
{
    public float angl;
    float acs = 0;
    public int playerNo = 0;
    private float spd = 0;
    public GamePadManager pad;
    public bool A, B, X, Y, L, R = false;
    public bool IsStop = true;
    TankManager pearent;
    TankYatuManager TankYatu;

    // Use this for initialization
    void Start()
    {
        

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

        pad = GameObject.Find("PadManager").GetComponent<GamePadManager>();

        pearent = gameObject.transform.parent.gameObject.GetComponent<TankManager>();

        spd = pearent.TankSpeed;  
    }

    // Update is called once per frame
    void Update()
    {
        TankYatu = GameObject.Find("TankYatu").GetComponent<TankYatuManager>();
        var stick = pad.pad[playerNo].LeftStickAxis;
        float stickx = stick.x;
        float sticky = stick.y;

        if (stickx > 0.5f)
            stickx = 1.0f;

        if (sticky > 0.5f)
            sticky = 1.0f;


        A = pad.pad[playerNo].A;
        B = pad.pad[playerNo].B;
        X = pad.pad[playerNo].X;
        Y = pad.pad[playerNo].Y;
        L = pad.pad[playerNo].LeftShoulder;
        R = pad.pad[playerNo].RightShoulder;

        if(L || R || stickx > 0.1f || stickx < -0.1f || sticky > 0.1f || sticky < -0.1f)
        {
            IsStop = false;
        }
        else { IsStop = true; }

        //戦車の向きを変える
        transform.rotation = Quaternion.AngleAxis(angl, Vector3.back);

        if (TankYatu.IsPlay)
        {
            //向きの値に入力値を足す
            angl += ((stickx) * (pearent.TankTurning));
            

            //戦車前進
            var forward = this.transform.TransformDirection(Vector3.up);
            this.transform.position += forward * spd * Time.deltaTime * sticky;
        }
    }

    public void DmageHp(int attack)
    {
        pearent.DecreaseHP(attack);
    }

    public void Hiropon(int pon)
    {
        pearent.RecoveryHP(pon);
    }
}
