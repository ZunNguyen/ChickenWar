using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Mission
{
    public string missionIndex;
    public float mission;
    public float prize;

    public Mission()
    {
    }

    public Mission(string _missionIndex, float _mission, float _prize)
    {
        missionIndex = _missionIndex;
        mission = _mission;
        prize = _prize;
    }
}
