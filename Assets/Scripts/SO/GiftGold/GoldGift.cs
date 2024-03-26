using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoldGift
{
    public int wave;
    public float gold;

    public GoldGift(int _wave, float _gold)
    {
        wave = _wave;
        gold = _gold;
    }
}
