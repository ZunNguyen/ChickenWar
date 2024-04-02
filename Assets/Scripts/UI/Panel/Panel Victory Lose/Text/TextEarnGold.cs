using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEarnGold : ProcessGold
{
    public float goldEarn;

    public virtual void InputGoldValue(float gold)
    {
        goldEarn = gold;
        PrintText(goldEarn);
    }

    protected override string ShortText(float value)
    {
        if (value < 1000)
        {
            return value.ToString();
        }
        if (value >= 1000 && value < 1000000)
        {
            return (value / 1000).ToString("n0") + "K";
        }
        if (value >= 1000000 && value < 1000000000)
        {
            return (value / 1000000).ToString("n0") + "M";
        }
        if (value >= 1000000000 && value < 1000000000000)
        {
            return (value / 1000000000).ToString("n0") + "B";
        }
        if (value >= 1000000000000 && value < 1000000000000000)
        {
            return (value / 1000000000000).ToString("n0") + "T";
        }
        return "";
    }
}
