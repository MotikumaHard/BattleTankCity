using UnityEngine;
using System.Collections;

public class Syasen : MonoBehaviour {
    Tank tank;
    bool Isalfa = false;
    SpriteRenderer spRenderer;
    Color color;
    public GameObject pointR;
    public GameObject pointL;
    Vector2 posR;
    Vector2 posL;
    int fleam = 0;
    int f = -1;
    // Use this for initialization
    void Start () {
        spRenderer = GetComponent<SpriteRenderer>();
        color = spRenderer.color;
        color.a = 0f;
        tank = gameObject.transform.parent.parent.gameObject.GetComponent<Tank>();


    }
	
	// Update is called once per frame
	void Update () {

        if (tank.IsStop)
        {
            if (tank.X)
            {
                Isalfa = true;
            }
            else { Isalfa = false; }
            if(fleam > 0)fleam--;
        }
        else { Isalfa = false; if (fleam < 100) fleam++; }

        posL = pointL.transform.position;
        posR = pointR.transform.position;

        posR.x += 0.0009f*Mathf.Cos(transform.rotation.z/Mathf.PI);
        posL.x += -0.0009f * Mathf.Cos(transform.rotation.z / Mathf.PI);
        posR.y += 0.0009f * Mathf.Cos(transform.rotation.z / Mathf.PI);
        posL.y += -0.0009f * Mathf.Cos(transform.rotation.z / Mathf.PI);

        pointR.transform.position = posR;
        pointL.transform.position = posL;

        if (Isalfa)
        {

            color.a = 1.0f;

        }
        else
        {
            color.a = 0f;
        }
        //spRenderer.color = color;
    }
}
