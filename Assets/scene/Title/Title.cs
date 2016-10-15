using UnityEngine;
using System.Collections;
using GamepadInput;
using UnityEngine.SceneManagement; 

public class Title : MonoBehaviour {
	GamepadState state;
	GamepadState pad1;
	//Vector2 stick1;
	bool slant = false;
	public int num = 2;
	public bool IsStart = false;
	public GamePadManager pad;
	public bool Isbutton = false;
    // Use this for initialization*/

    public AudioClip plessbutton;
    public AudioClip cursor;
    public AudioClip start;
    AudioSource audioSources;


    void Start () {
		pad = GameObject.Find("PadManager").GetComponent<GamePadManager>();
        audioSources = gameObject.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		//state = GamePad.GetState(GamePad.Index.One);
		var stick1 = pad.pad[0].LeftStickAxis;
		if(!IsStart)
		{
			if(pad.pad[0].A)
			{
                audioSources.clip = plessbutton;audioSources.Play();
				IsStart = !IsStart;
				Isbutton =true;
			}
		}

		if(!pad.pad[0].A)
		{
			Isbutton = false;
		}

		if (IsStart) { 
			if(stick1.y < -0.8 && !slant && num < 4)
			{
                audioSources.clip = cursor; audioSources.Play();
                slant = !slant;
				num ++;
			}

			if (stick1.y > 0.8 && !slant && num > 2)
			{
                audioSources.clip = cursor; audioSources.Play();
                slant = !slant;
				num--;
			}

			if(-0.8< stick1.y && stick1.y <0.8 && slant)
			{
				slant = !slant;
			}

			if (pad.pad[0].A && !Isbutton)
			{
                audioSources.clip = start; audioSources.Play();
                GameManager.playNo = num;
				Isbutton = !Isbutton;
				Invoke("LoadSelect",1.0f);

			}
		}
		//Examples();
	}

	void Examples()
	{
		/*GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.One);
		GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One);
		GamePad.GetTrigger(GamePad.Trigger.RightTrigger, GamePad.Index.One);
		*/

		state = GamePad.GetState(GamePad.Index.One);
		print("A: " + state.B);
	}

	void LoadSelect()
	{
		SceneManager.LoadScene("Select");
	}

}
