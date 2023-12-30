using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPlayer : ProcessGold
{
    public float gold;

    private void Update()
    {
        PrintText(gold);
    }
}
