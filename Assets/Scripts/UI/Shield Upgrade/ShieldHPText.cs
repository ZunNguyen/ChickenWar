using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldHPText : ProcessGold
{
    public virtual void Print(float value_1, float value_2)
    {
        if (value_1 < 0) value_1 = 0;
        string printValue = ShortText(value_1) + "|" + ShortText(value_2);
        text.text = printValue;
    }
}
