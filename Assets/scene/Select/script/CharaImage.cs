using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharaImage : MonoBehaviour {

    public Sprite[] sp = new Sprite[4];
    Image thisSprite;
    CharaSelectSystem system;
    // Use this for initialization
    void Start()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        system = parent.GetComponent<CharaSelectSystem>();
        thisSprite = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        thisSprite.sprite = sp[system.charanum];
    }
}
