using UnityEngine;
using System.Collections;

public class SE : MonoBehaviour {
    AudioSource audio;
    // Use this for initialization
    void Start () {
        Invoke("hogehoge", 4);

    }

    void hogehoge()
    {
        Destroy(gameObject);
    }
}
