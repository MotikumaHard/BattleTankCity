using UnityEngine;
using System.Collections;

public class StartCall : MonoBehaviour {
    Animator _anim;
    AnimatorStateInfo animInfo;
    TankYatuManager TankYatu;
    // Use this for initialization
    void Start () {
        TankYatu = GameObject.Find("TankYatu").GetComponent<TankYatuManager>();
    }
	
	// Update is called once per frame
	void Update () {



        _anim = GetComponent<Animator>();
        animInfo = _anim.GetCurrentAnimatorStateInfo(0);

        if (animInfo.normalizedTime > 1.0f)
        {
            TankYatu.IsPlay = true;
            Destroy(this.gameObject);
        }
    }
}
