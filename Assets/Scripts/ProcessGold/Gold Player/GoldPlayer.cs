using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldPlayer : ProcessGold
{
    protected static GoldPlayer instance;
    public static GoldPlayer Instance => instance;
    public int gold = 0;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }

    public virtual void AddGoldPlayer(int addGold)
    {
        gold += addGold;
        PrintText(gold);
    }

    public virtual void SubtractGoldPlayer(int subtractGold)
    {
        gold -= subtractGold;
        PrintText(gold);
    }
}