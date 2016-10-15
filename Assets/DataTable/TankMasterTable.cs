using UnityEngine;
using System.Collections;

public class TankMasterTable : MasterTableBase<TankMaster>
{
	private static readonly string FilePath = "Tank";
	public void Load() { Load(FilePath); }
}

public class TankMaster : MasterBase
{
	public string ID { get; private set; }
	public string Name { get; private set; }
	public int Hp { get; private set; }
	public int Attack { get; private set; }
	public int Speed { get; private set; }
	public int Turning { get; private set; }
	public int Reload { get; private set; }
}