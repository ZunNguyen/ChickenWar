using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEarnGoldOffline : ProcessGold
{
    public float goldEarn;

    public virtual void InputGoldValue(float gold)
    {
        goldEarn = gold;
        PrintText(goldEarn);
    }
}
