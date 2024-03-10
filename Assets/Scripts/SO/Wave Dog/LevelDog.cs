using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelDog
{
    public int levelDog;
    public string nameDog;
    public int nums;
    public int hpDog;
    public float timeDelay;
    public string indexLine;

    public LevelDog(int _levelDog, string _nameDog, int _nums, int _hpDog,float _timeDelay, string _indexLine)
    {
        levelDog = _levelDog;
        nameDog = _nameDog;
        nums = _nums;
        hpDog = _hpDog;
        timeDelay = _timeDelay;
        indexLine = _indexLine;
    }
}
