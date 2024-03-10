using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGoldUpdate : ProcessGold
{
    public int goldUpgrade = 200;

    private void Update()
    {
        PrintText(goldUpgrade);
    }
}
