using UnityEngine;
using System.Collections;

public class CharaMasterTable : MasterTableBase<CharaMaster>
{
    private static readonly string FilePath = "Chara";
    public void Load() { Load(FilePath); }
}

public class CharaMaster : MasterBase
{
    public string ID { get; private set; }
    public string Name { get; private set; }
    public int Hp { get; private set; }
    public int Attack { get; private set; }
    public int Speed { get; private set; }
    public int Turning { get; private set; }
    public int Reload { get; private set; }
}