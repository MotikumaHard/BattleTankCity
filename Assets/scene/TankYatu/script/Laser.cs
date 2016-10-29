using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
    Tank tank;
    TankYatuManager TankYatu;
    bool Isalfa = false;
    SpriteRenderer spRenderer;
    Color color;
    // Use this for initialization
    void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>();
        color = spRenderer.color;
        color.a = 0f;
        tank = gameObject.transform.parent.parent.gameObject.GetComponent<Tank>();
        TankYatu = GameObject.Find("TankYatu").GetComponent<TankYatuManager>();
    }

    // Update is called once per frame
    void Update () {
        if (tank.IsStop)
        {
            if(tank.X)
            {
                Isalfa = true;
            }else { Isalfa = false; }
        }
        else { Isalfa = false; }



        if(Isalfa)
        {

            color.a = 1.0f;

        }
        else
        {
            color.a = 0f;
        }
        spRenderer.color = color;
    }
}
