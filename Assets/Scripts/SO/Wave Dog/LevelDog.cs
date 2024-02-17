using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelDog
{
    public GameObject dog;
    public int nums;
    public float timeDelay;
    public List<Index> indexs;

    public bool CheckDogInList(int index)
    {
        foreach(Index check in indexs)
        {
            if (check.line == index) return true;
        }
        return false;
    }
}
