using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldHPText : ProcessGold
{
    public virtual void Print(int value_1, int value_2)
    {
        //if (value_2 == 0) return;
        string printValue = ShortText(value_1) + "|" + ShortText(value_2);
        text.text = printValue;
    }
}
