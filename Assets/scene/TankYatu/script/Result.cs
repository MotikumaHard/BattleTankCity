using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GamepadInput;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {
    public GameObject[] winner = new GameObject[4];
    public GameObject resultPanel;
    public int num = 0;
    GamepadState state;
    GamepadState pad1;
    bool slant = false;
    public bool IsStart = false;
    public GamePadManager pad;
    public bool Isbutton = false;
    bool IsResult = false;
    bool IsSelect = false;


    // Use this for initialization
    void Start () {
        pad = GameObject.Find("PadManager").GetComponent<GamePadManager>();
    }
	
	// Update is called once per frame
	void Update () {
        var stick1 = pad.pad[0].LeftStickAxis;
        pad = GameObject.Find("PadManager").GetComponent<GamePadManager>();
        if (IsResult)
        {
            if(!pad.pushbutton[0] && !IsSelect)
            {
                if (stick1.y < -0.8 && !slant && num < 2)
                {
                    slant = !slant;
                    num++;
                }

                if (stick1.y > 0.8 && !slant && num > 0)
                {
                    slant = !slant;
                    num--;
                }

                if (-0.8 < stick1.y && stick1.y < 0.8 && slant)
                {
                    slant = !slant;
                }
            }
            if (pad.pad[0].A)
            {
                Debug.Log("aaa");
                Invoke("LoadSelect", 1.0f);
                IsSelect = true;

            }
        }
	}

    public void display(int player)
    {
        GameObject obj = (GameObject)Instantiate(winner[player], new Vector2(transform.position.x,transform.position.y+150f), transform.rotation);
        obj.transform.parent = this.transform;

        Invoke("Load", 1.0f);

    }

    void Load()
    {

        GameObject obj = (GameObject)Instantiate(resultPanel, transform.position, transform.rotation);
        obj.transform.parent = this.transform;
        IsResult = true;
    }

    void LoadSelect()
    {
        switch (num)
        {
            case 0: SceneManager.LoadScene("tankyatu");
                break;
            case 1:
                SceneManager.LoadScene("Select");
                break;
            case 2:
                SceneManager.LoadScene("Title");
                break;
        }
    }
}
