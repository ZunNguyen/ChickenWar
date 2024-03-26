using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelShield
{
    public float gold;
    public int hp;

    public LevelShield(float _gold, int _hp)
    {
        gold = _gold;
        hp = _hp;
    }
}
