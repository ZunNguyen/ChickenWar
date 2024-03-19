using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGoldUpdate : ProcessGold
{
    public virtual void PrintMaxShield()
    {
        text.text = "Highest Shield";
    }
}
