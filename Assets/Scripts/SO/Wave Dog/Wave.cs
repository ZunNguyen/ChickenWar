using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Wave
{
    public int wave;
    public int sum;
    public List<Phase> phases;

    public Wave(int _wave)
    {
        phases = new List<Phase>();
        wave = _wave;
    }

    public virtual int GetSumDogWave()
    {
        sum = 0;
        foreach (Phase phase in phases)
        {
            sum += phase.GetSumDogPhase();
        }
        return sum;
    }
}