using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GamepadInput;

public class GamePadManager :MonoBehaviour{
	public List<GamepadState> pad = new List<GamepadState>();
	public bool[] pushbutton = new bool[4];
	void Start()
	{
		pad.Add(GamePad.GetState(GamePad.Index.One));
		pad.Add(GamePad.GetState(GamePad.Index.Two));
		pad.Add(GamePad.GetState(GamePad.Index.Three));
		pad.Add(GamePad.GetState(GamePad.Index.Four));
	}
	void Update()
	{
		pad.Clear();

		pad.Add(GamePad.GetState(GamePad.Index.One));
		pad.Add(GamePad.GetState(GamePad.Index.Two));
		pad.Add(GamePad.GetState(GamePad.Index.Three));
		pad.Add(GamePad.GetState(GamePad.Index.Four));

		for(int i = 0;i < 4;i++){
			if(pad[i].A || pad[i].B || pad[i].X || pad[i].Y){
				pushbutton[i] = true;
			}
			else { pushbutton[i] = false;}
		}
	}
}
