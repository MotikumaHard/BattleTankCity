using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GamepadInput;
using UnityEngine.SceneManagement; 

public class CharaSelectSystem : MonoBehaviour {
	
	public int playerNo = 0;
	public int tanknum = 0;
	//最大選択戦車数
	public int MaxTanknum = 4;
	bool slant = false;
	public string tankname = "";
    public string charaname = "";
	public TankMasterTable tanktable;
    public CharaMasterTable charatable;
	public GamePadManager pad;
    public GameObject Completed;
	CharaSelectManager manager;

    public AudioClip cursor;
    public AudioClip conpleted;
    public AudioClip cancel;

    GameObject CompletedStanp;
    AudioSource audioSources;

    bool IsPlay = false;
	bool IsDecision = false;
	bool pushbutton = false;

	// Use this for initialization
	void Start () {
        audioSources = gameObject.GetComponent<AudioSource>();
        switch (this.gameObject.transform.tag)
		{
			case "Player1":playerNo = 0;
			break;
			case "Player2": playerNo = 1;
			break;
			case "Player3": playerNo = 2;
			break;
			case "Player4": playerNo = 3;
			break;
		}

		if(playerNo < GameManager.playNo)
			IsPlay = true;

		pad = GameObject.Find("PadManager").GetComponent<GamePadManager>();
		manager = GameObject.Find("SelectManager").GetComponent<CharaSelectManager>();

		tanktable = new TankMasterTable();
		tanktable.Load();

        charatable = new CharaMasterTable();
        charatable.Load();
	}
	
	// Update is called once per frame
	void Update () {
		if(IsPlay){
			var stick = pad.pad[playerNo].LeftStickAxis;
			var ButtonA = pad.pad[playerNo].A;
			var ButtonB = pad.pad[playerNo].B;

			tankname = tanktable.All[tanknum].Name;
			if(!IsDecision)
			{
				if(-0.8< stick.x && stick.x <0.8 && slant)
				{
					slant = !slant;
				}

				if(stick.x > 0.8 && !slant)
				{
                    audioSources.clip = cursor; audioSources.Play();
                    tanknum++;
					if(tanknum > MaxTanknum-1)
						tanknum = 0;
					slant = !slant;
				}

				if(stick.x < -0.8 && !slant)
				{
                    audioSources.clip = cursor; audioSources.Play();
                    tanknum--;
					if(tanknum < 0)
					{
						tanknum = MaxTanknum-1;
					}

					slant = !slant;
				}

				if(!IsDecision && !pushbutton && ButtonA)
				{
                    audioSources.clip = conpleted; audioSources.Play();
                    IsDecision = true;
					GameManager.Tank[playerNo] = tanknum;
                    CompletedStanp =(GameObject)Instantiate(Completed, new Vector2(this.transform.position.x-230f,this.transform.position.y +120f), transform.rotation);
                    CompletedStanp.transform.parent = this.transform;
                    manager.PushA();
				}

				if(!IsDecision && !pushbutton && ButtonB && playerNo == 0)
				{
                    audioSources.clip = cancel; audioSources.Play();
                    Invoke("LoadTitle",0.5f);
				}
			}

			if(IsDecision && !pushbutton && ButtonB)
			{
                audioSources.clip = cancel; audioSources.Play();
                IsDecision =false;
                Destroy(CompletedStanp);
				manager.PushB();
			}

			pushbutton = pad.pushbutton[playerNo];
		}
	}

    void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
