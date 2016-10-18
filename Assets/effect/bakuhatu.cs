using UnityEngine;
using System.Collections;

public class bakuhatu : MonoBehaviour {
    public GameObject exprotion;
    void Start()
    {
        Instantiate(exprotion, transform.position, transform.rotation);
    }
    void OnAnimationFinish()
    {
        Destroy(gameObject);
    }
    
}
