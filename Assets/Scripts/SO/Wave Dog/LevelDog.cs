using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelDog
{
    public int levelDog;
    public string nameDog;
    public int nums;
    public float timeDelay;
    public string indexLine;
    public List<Index> indexs;

    public LevelDog(int _levelDog, string _nameDog, int _nums, float _timeDelay, string _indexLine)
    {
        indexs = new List<Index>();
        levelDog = _levelDog;
        nameDog = _nameDog;
        nums = _nums;
        timeDelay = _timeDelay;
        indexLine = _indexLine;
    }

    public bool CheckDogInList(int index)
    {
        foreach(Index check in indexs)
        {
            if (check.line == index) return true;
        }
        return false;
    }
}
