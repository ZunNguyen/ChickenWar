using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderData;

[Serializable]
public class Phase
{
    public int phase;
    public int sumPhase;
    public List<LevelDog> levelDogs;

    public Phase(int _phase)
    {
        levelDogs = new List<LevelDog>();
        phase = _phase;
    }

    public virtual int GetSumDogPhase()
    {
        sumPhase = 0;
        foreach (LevelDog levelDog in levelDogs)
        {
            sumPhase = sumPhase + levelDog.nums * levelDog.indexs.Count;
        }
        return sumPhase;
    }
}