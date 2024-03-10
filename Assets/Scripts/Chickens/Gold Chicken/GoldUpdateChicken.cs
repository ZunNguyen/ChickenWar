using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUpdateChicken : ProcessGold
{
    public virtual void GetValueText(int gold)
    {
        PrintText(gold);
    }
}
