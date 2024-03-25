using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelDog
{
    public int levelDog;
    public string nameDog;
    public float scaleValue;
    public int nums;
    public int hpDog;
    public int damageDog;
    public float timeDelay;
    public string indexLine;

    public LevelDog(int _levelDog, string _nameDog, float _scaleValue, int _nums, int _hpDog, int _damageDog, float _timeDelay, string _indexLine)
    {
        levelDog = _levelDog;
        nameDog = _nameDog;
        scaleValue = _scaleValue;
        nums = _nums;
        hpDog = _hpDog;
        damageDog = _damageDog;
        timeDelay = _timeDelay;
        indexLine = _indexLine;
    }
}
