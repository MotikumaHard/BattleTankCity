using UnityEngine;
using System.Collections;

public class Oneyjrs : MonoBehaviour {

    int point;
    RectTransform hoge;
    // Use this for initialization
    void Start()
    {
        hoge = this.gameObject.GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update () {
        point = GameObject.Find("RESULT").GetComponent<Result>().num;
        switch (point)
        {
            case 0:
                hoge.position = new Vector2(400f, 330f);
                break;
            case 1:
                hoge.position = new Vector2(365f, 270f);
                break;
            case 2:
                hoge.position = new Vector2(360f,210f);
                break;
        }
    }
}
