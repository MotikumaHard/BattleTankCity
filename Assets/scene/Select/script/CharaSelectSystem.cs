using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GamepadInput;
using UnityEngine.SceneManagement; 

public class CharaSelectSystem : MonoBehaviour {
	
	public int playerNo = 0;
	public int tanknum = 0;
    public int charanum = 0;
	//最大選択戦車数
	public int MaxTanknum = 4;
    public int MaxCharanum = 4;
	bool slant = false;
	public string tankname = "";
	public TankMasterTable tanktable;
    public string charaname = "";
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
    bool IsTankDecision = false;
    bool IsCharaDecision = false;
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
            charaname = charatable.All[charanum].Name;
			if(!IsDecision)
			{
				if(-0.8< stick.x && stick.x <0.8 && slant)
				{
					slant = !slant;
				}

				if(stick.x > 0.8 && !slant)
				{
                    audioSources.clip = cursor; audioSources.Play();

                    if(!IsTankDecision)
                        tanknum++;
					if(tanknum > MaxTanknum-1)
						tanknum = 0;

                    if (!IsCharaDecision && IsTankDecision)
                        charanum++;
                    if (charanum > MaxCharanum - 1)
                        charanum = 0;

                    slant = !slant;
				}

				if(stick.x < -0.8 && !slant)
				{
                    audioSources.clip = cursor; audioSources.Play();
                    if (!IsTankDecision)
                        tanknum--;
					if(tanknum < 0)
						tanknum = MaxTanknum-1;

                    if (!IsCharaDecision && IsTankDecision)
                        charanum--;
                    if (charanum < 0)
                        charanum = MaxCharanum-1;

                    slant = !slant;
				}

				if(!IsDecision && !pushbutton && ButtonA)
				{
                    audioSources.clip = conpleted; audioSources.Play();

                    

                    if (IsTankDecision)
                    {
                        GameManager.Chara[playerNo] = charanum;
                        CompletedStanp = (GameObject)Instantiate(Completed, new Vector2(this.transform.position.x - 230f, this.transform.position.y + 120f), transform.rotation);
                        CompletedStanp.transform.parent = this.transform;
                        IsDecision = true;
                        manager.PushA();
                    }
                    else
                    {
                        GameManager.Tank[playerNo] = tanknum;
                        IsTankDecision= true;
                    }
                    
                }

				if(!IsDecision && !pushbutton && ButtonB && playerNo == 0)
				{
                    if (!IsTankDecision)
                    {
                        audioSources.clip = cancel; audioSources.Play();
                        Invoke("LoadTitle", 0.5f);
                    }
				}
			}

			if(!pushbutton && ButtonB)
			{
                if (IsDecision)
                {
                    audioSources.clip = cancel; audioSources.Play();
                    IsDecision = false;
                    Destroy(CompletedStanp);
                    manager.PushB();
                }else if(IsTankDecision)
                {
                    IsTankDecision = false;
                }
			}

			pushbutton = pad.pushbutton[playerNo];
		}
	}

    void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
