using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CharityList
{
    public List<CharityData> Charities = new List<CharityData>();
}


[System.Serializable]
public class CharityData
{
    public string Name;
    public string Description;
}
