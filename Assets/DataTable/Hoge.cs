using UnityEngine;
using System.Collections;

public class Hoge : MonoBehaviour {
	void Start()
	{
		var tanktable = new TankMasterTable();
		tanktable.Load();



		foreach(var tankMaster in tanktable.All)
		{
			Debug.Log(tankMaster.Name);
		}
	}
}
